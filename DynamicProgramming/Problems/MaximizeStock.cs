using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DynamicProgramming
{
    /// <summary>
    /// Refer to the link https://www.hackerrank.com/challenges/stockmax/problem
    /// </summary>
    public class MaximizeStock : IRun
    {
        public void Run()
        {
            Console.WriteLine("Maximize Stock is running");

            var inputString = File.ReadAllLines(@".\Resources\MaximizeStockPrice.txt");
            int numberOfTestCases = Convert.ToByte(inputString[0]);

            Stopwatch sc = new Stopwatch();
            sc.Start();

            //int[] input = new int[] {5, 3, 2};

            for(int testCase = 0; testCase < numberOfTestCases; testCase++)
            {
                int[] arr = Array.ConvertAll(inputString[(testCase * 2) + 2].Split(' '), arrTemp => Convert.ToInt32(arrTemp));
                var result = StockMax(arr);
                Console.WriteLine(result);
            }

            sc.Stop();
            Console.WriteLine("Time taken: " + sc.Elapsed.ToString("G"));
        }

        private long StockMax(int[] prices) 
        {
            int noOfShares = 0;
            long costPrice = 0;
            long sellingPrice = 0;
            long maxPrice = prices.Max();
            for(int i=0; i< prices.Length; i++)
            {
                if(prices[i] < maxPrice)
                {
                    costPrice += prices[i];
                    noOfShares++;
                }
                else
                {
                    sellingPrice += noOfShares * maxPrice;
                    noOfShares = 0;
                    maxPrice = GetNewMaxPrice(prices, i);
                }
            }

            return sellingPrice - costPrice;
        }

        private long GetNewMaxPrice(int[] prices, int index)
        {
            long maxPrice = 0;
            for(int i = index+ 1;i<prices.Length; i++)
            {
                if(prices[i] > maxPrice)
                {
                    maxPrice = prices[i];
                }
            }

            return maxPrice;
        }
    }
}