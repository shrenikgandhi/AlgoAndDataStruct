using System;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            IRun program = new Fibonacci();
            program.Run();
            Console.WriteLine("\n\nExecution Completed!");
        }
    }
}
