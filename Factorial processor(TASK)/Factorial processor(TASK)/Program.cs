﻿namespace Factorial_processor_TASK_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FactorialProcessor processor = new FactorialProcessor();

            Console.WriteLine("Послідовно");
            processor.Go(5, false);

            Console.WriteLine("Паралельно");
            processor.Go(5, true);

            Console.ReadLine();
        }
    }
}