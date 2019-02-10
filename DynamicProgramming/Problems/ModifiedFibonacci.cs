using System;
using System.Diagnostics;
using System.Numerics;

namespace DynamicProgramming
{
    /// <summary>
    /// O/P of the function should be a modified fibonacci given first 2 numbers and finding the nth number
    /// t(n) = t(n-1)^2 + t(n-2)
    /// </summary>
    public class ModifiedFibonacci : IRun
    {
        public void Run()
        {
            Console.WriteLine("Modified Fibonacci is running");
            Stopwatch sc = new Stopwatch();
            sc.Start();
            int number1 = 1;
            int number2 = 2;
            int n = 10;

            var result = fibonacciModified(number1, number2, n);

            sc.Stop();

            Console.WriteLine("Result: " + result);
            Console.WriteLine("Time taken: " + sc.Elapsed.ToString("G"));
        }

        private BigInteger fibonacciModified(int number1, int number2, int n) {
            BigInteger[] result = new BigInteger[n];
            result[0] = number1;
            result[1] = number2;

            for (int i = 2; i<=n-1;i++)
            {
                result[i] = result[i-2] + (result[i-1] * result[i-1]);
            }
            return result[n-1];
        }
    }
}