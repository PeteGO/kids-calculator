using System;

public class InputParser
{
    public static (bool isValid, string message) Validate(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return (false, "The sum is blank.");

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == '+' || input[i] == '-' || input[i] == '*' || input[i] == '/')
            {
                if (i == 0) return (false, "The sum must start with a number.");
                if (i == input.Length - 1) return (false, "The sum must end with a number.");

                var leftPart = input.Substring(0, i).Trim(' ');
                var rightPart = input.Substring(i + 1, input.Length - i - 1).Trim(' ');

                Console.WriteLine($"Parsed operator as '{input[i]}', left part as '{leftPart}' and right part as '{rightPart}'.");

                if (!int.TryParse(leftPart, out var num1)) return (false, "The left part of the sum is not a valid whole number.");
                if (!int.TryParse(rightPart, out var num2)) return (false, "The right part of the sum is not a valid whole number.");

                return (true, "");
            }
        }

        return (false, "The sum must have an operator (i.e. +, -, *, /).");
    }

    public static (int number1, int number2, char sumType) GetSumParts(string input)
    {
        var (valid, message) = Validate(input);

        if (!valid) throw new ArgumentException(message);

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == '+' || input[i] == '-' || input[i] == '*' || input[i] == '/')
            {
                var num1 = int.Parse(input.Substring(0, i).Trim(' '));
                var num2 = int.Parse(input.Substring(i + 1, input.Length - i - 1).Trim(' '));

                return (num1, num2, input[i]);
            }
        }

        throw new ArgumentException(input);
    }
}