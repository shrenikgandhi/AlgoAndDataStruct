using System;
using System.Diagnostics;
using System.IO;

namespace DynamicProgramming
{
    /// <summary>
    /// Refer to the link https://www.hackerrank.com/challenges/maxsubarray/problem
    /// </summary>
    public class MaxSubArray : IRun
    {
        public void Run()
        {
            Console.WriteLine("Max Subarray is running");

            var inputString = File.ReadAllLines(@".\Resources\MaxSubArray.txt");
            int numberOfTestCases = Convert.ToByte(inputString[0]);

            Stopwatch sc = new Stopwatch();
            sc.Start();

            for(int testCase = 0; testCase < numberOfTestCases; testCase++)
            {
                int[] arr = Array.ConvertAll(inputString[(testCase * 2) + 2].Split(' '), arrTemp => Convert.ToInt32(arrTemp));
                var result = maxSubArray(arr);
                Console.WriteLine("Result: "+string.Join(" ", result));
            }

            sc.Stop();
            Console.WriteLine("Time taken: " + sc.Elapsed.ToString("G"));
        }

        int[] maxSubArray(int[] arr) 
        {
            int[] maxSumArray = new int[arr.Length];
            maxSumArray[arr.Length - 1] = arr[arr.Length - 1];
            int maxSum = arr[arr.Length - 1];

            for(int i=arr.Length - 2;i>=0;i--)
            {

                var currentSum = arr[i] + maxSumArray[i+1];
                if(currentSum < arr[i])
                {
                    maxSumArray[i] = arr[i];
                }
                else
                {
                    maxSumArray[i] = currentSum;
                }

                if(maxSumArray[i] > maxSum)
                {
                    maxSum = maxSumArray[i];
                }
            }

            int minNumber = short.MinValue;
            int sum = 0;
            for (int i = 0; i< arr.Length; i++)
            {
                if(arr[i]<=0)
                {
                    if(arr[i] > minNumber)
                    {
                        minNumber = arr[i];
                    }
                }
                else
                {
                    sum += arr[i];
                }
            }

            return new int[] {maxSum, sum != 0 ? sum : minNumber};
        }
    }
}