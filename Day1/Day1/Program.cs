using System;
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Hello!");
            Console.Write("Input the first number:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the second number:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What do you want to do with those numbers?");
            Console.WriteLine("[A]dd");
            Console.WriteLine("[S]ubtract");
            Console.WriteLine("[M]ultiply");
            string input = Console.ReadLine();
            char letter = string.IsNullOrEmpty(input) ? ' ' : input[0];
            switch (char.ToUpper(letter))
            {
                case 'A':

                    int AddResult = num1 + num2;
                    Console.WriteLine($"{num1} + {num2} = {AddResult}");
                    break;
                case 'S':

                    int SubResult = num1 - num2;
                    Console.WriteLine($"{num1} - {num2} = {SubResult}");
                    break;
                case 'M':

                    int MultiplyResult = num1 * num2;
                    Console.WriteLine($"{num1} * {num2} = {MultiplyResult}");
                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
            Console.WriteLine("Press R to restart or any key to close");
            string choice = Console.ReadLine().ToUpper();
            if (choice == "R")
            {
                Console.WriteLine("Restarting the program");
                continue;
            }
            else
                break;

        }
    }
}
