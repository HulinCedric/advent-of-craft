﻿namespace Day10;

public static class FizzBuzz
{
    private const int Min = 0;
    private const int Max = 100;
    private const int Fizz = 3;
    private const int Buzz = 5;
    private const int Fizz_Buzz = 15;

    public static string Convert(int input)
        => IsOutOfRange(input)
               ? throw new OutOfRangeException()
               : ConvertSafely(input);

    private static string ConvertSafely(int input)
        => input switch
        {
            _ when Is(Fizz_Buzz, input) => "FizzBuzz",
            _ when Is(Fizz, input) => "Fizz",
            _ when Is(Buzz, input) => "Buzz",
            _ => input.ToString()
        };

    private static bool Is(int divisor, int input) => input % divisor == 0;

    private static bool IsOutOfRange(int input) => input is <= Min or > Max;
}