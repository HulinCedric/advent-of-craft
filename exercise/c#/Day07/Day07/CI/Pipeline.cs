using Day07.CI.Dependencies;

namespace Day07.CI;

public class Pipeline(IConfig config, IEmailer emailer, ILogger log)
{
    public void Run(Project project)
    {
        var testsPassed = RunTests(project);

        var deploySuccessful = RunDeployment(project, testsPassed);

        RunSendEmailSummary(testsPassed, deploySuccessful);
    }

    private bool RunTests(Project project)
    {
        bool testsPassed;
        if (project.HasTests())
        {
            if (project.RunTests() == "success")
            {
                testsPassed = StepPassed("Tests passed");
            }
            else
            {
                testsPassed = StepFailed("Tests failed");
            }
        }
        else
        {
            testsPassed = StepPassed("No tests");
        }

        return testsPassed;
    }

    private bool RunDeployment(Project project, bool testsPassed)
    {
        bool deploySuccessful;
        if (testsPassed)
        {
            if (project.Deploy() == "success")
            {
                deploySuccessful = StepPassed("Deployment successful");
            }
            else
            {
                deploySuccessful = StepFailed("Deployment failed");
            }
        }
        else
        {
            deploySuccessful = StepFailed();
        }

        return deploySuccessful;
    }

    private void RunSendEmailSummary(bool testsPassed, bool deploySuccessful)
    {
        if (config.SendEmailSummary())
        {
            log.Info("Sending email");
            if (testsPassed)
            {
                if (deploySuccessful)
                {
                    emailer.Send("Deployment completed successfully");
                }
                else
                {
                    emailer.Send("Deployment failed");
                }
            }
            else
            {
                emailer.Send("Tests failed");
            }
        }
        else
        {
            log.Info("Email disabled");
        }
    }

    private bool StepPassed(string message)
    {
        log.Info(message);
        return true;
    }

    private bool StepFailed(string message = "")
    {
        if (!string.IsNullOrWhiteSpace(message))
        {
            log.Error(message);
        }

        return false;
    }
}