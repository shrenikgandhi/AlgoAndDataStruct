﻿using System;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            IRun program = new NewYearChaos();
            program.Run();
            Console.WriteLine("\n\nExecution Completed!");
        }
    }
}
