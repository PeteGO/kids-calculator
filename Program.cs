using System;

namespace calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter a sum with 2 parts, for example: 3 * 6");
                
                var userInput = Console.ReadLine();

                var (isValid, message) = InputParser.Validate(userInput);
                
                if (!isValid) 
                {
                    Console.WriteLine($"Invalid sum. {message}");
                    Console.WriteLine();
                    continue;
                }

                var (number1, number2, sumType) = InputParser.GetSumParts(userInput);

                var calculator = new Calculator();

                decimal sumResult;

                switch(sumType)
                {
                    case '+':
                        sumResult = calculator.Add(number1, number2);
                        break;
                    case '-':
                        sumResult = calculator.Deduct(number1, number2);
                        break;
                    case '*':
                        sumResult = calculator.Multiply(number1, number2);
                        break;
                    default:
                        Console.WriteLine("Sum type not implemented.");
                        Console.WriteLine();
                        continue;
                }

                Console.WriteLine(sumResult);
                Console.WriteLine();
            }
        }
    }
}
