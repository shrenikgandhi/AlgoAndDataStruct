using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DynamicProgramming
{
    public class Fibonacci : IRun
    {
        public void Run()
        {
            Console.WriteLine("Fibonacci is running");
            Recursion();
            Memoization();
            Tabulation();
        }

        #region Recursion
        private int recursionCounter;
        private void Recursion()
        {
            Console.WriteLine("\n\nFibonacci using Recurssion:");
            recursionCounter = 0;
            Stopwatch sc = new Stopwatch();
            sc.Start();
            var resultRecursion = RecursionFibo(40);
            sc.Stop();

            Console.WriteLine("Result: " + resultRecursion);
            Console.WriteLine("Time taken: " + sc.Elapsed.ToString("G"));
            Console.WriteLine("Number of time recursive method called: " + recursionCounter);
        }

        private long RecursionFibo(int number)
        {
            recursionCounter++;

            if (number <= 1)
            {
                return number;
            }
            else
            {
                return RecursionFibo(number - 1) + RecursionFibo(number - 2);
            }
        }
        #endregion

        #region Memoization
        private int tabulationCounter;
        private Dictionary<int,long> fibonacci;

        private void Memoization()
        {
            Console.WriteLine("\n\nFibonacci using Memoization:");
            tabulationCounter = 0;
            fibonacci = new Dictionary<int, long>();
            Stopwatch sc = new Stopwatch();
            sc.Start();
            var resultMemoization = MemoizationFibo(40);
            sc.Stop();

            Console.WriteLine("Result: " + resultMemoization);
            Console.WriteLine("Time taken: " + sc.Elapsed.ToString("G"));
            Console.WriteLine("Number of time memoized method called: " + tabulationCounter);
        }

        private long MemoizationFibo(int number)
        {
            tabulationCounter++;

            if(fibonacci.ContainsKey(number))
            {
                return fibonacci[number];
            }
            else if(number <= 1)
            {
                fibonacci[number] = number;
            }
            else
            {
                fibonacci[number] = MemoizationFibo(number - 1) + MemoizationFibo(number - 2);
            }
            return fibonacci[number];
        }
        #endregion

        #region Tabulation

        private void Tabulation()
        {
            Console.WriteLine("\n\nFibonacci using Tabulation:");
            Stopwatch sc = new Stopwatch();
            sc.Start();
            var resultTabulation = TabulationFibo(40);
            sc.Stop();

            Console.WriteLine("Result: " + resultTabulation);
            Console.WriteLine("Time taken: " + sc.Elapsed.ToString("G"));
        }

        private long TabulationFibo(int number)
        {
            long[] fibonacciSeries = new long [number+1];

            fibonacciSeries[0] = 0;
            fibonacciSeries[1] = 1;

            for(int i = 2; i <= number; i++)
            {
                fibonacciSeries[i] = fibonacciSeries[i-1] + fibonacciSeries[i-2];
            }

            return fibonacciSeries[number];
        }
        #endregion
    }
}
