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
                log.Info("Tests passed");
                testsPassed = true;
            }
            else
            {
                log.Error("Tests failed");
                testsPassed = false;
            }
        }
        else
        {
            log.Info("No tests");
            testsPassed = true;
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
                log.Info("Deployment successful");
                deploySuccessful = true;
            }
            else
            {
                log.Error("Deployment failed");
                deploySuccessful = false;
            }
        }
        else
        {
            deploySuccessful = false;
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
}