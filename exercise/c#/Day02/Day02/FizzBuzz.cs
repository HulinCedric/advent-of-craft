namespace Day02;

public static class FizzBuzz
{
    public static string Convert(int input)
    {
        if (input <= 0)
        {
            throw new OutOfRangeException();
        }
        else
        {
            if (input > 100)
            {
                throw new OutOfRangeException();
            }
            else
            {
                if (input % 3 == 0 &&
                    input % 5 == 0)
                {
                    return "FizzBuzz";
                }

                if (input % 3 == 0)
                {
                    return "Fizz";
                }

                if (input % 5 == 0)
                {
                    return "Buzz";
                }

                return input.ToString();
            }
        }
    }
}