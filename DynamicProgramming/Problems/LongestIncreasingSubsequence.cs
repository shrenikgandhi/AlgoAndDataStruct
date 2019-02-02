using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DynamicProgramming
{

    public class LongestIncreasingSubsequence : IRun
    {
        private Dictionary<int, List<int[]>> increasingSubSequence = new Dictionary<int, List<int[]>>();
        public void Run()
        {
            Console.WriteLine("Longest Increasing Subsequence is running");

            var inputString = File.ReadAllLines(@".\Resources\LongestIncreasingSubsequenceInput.csv");
            int[] inputSequence = new int[inputString.Length];
            for(int i=0; i<inputString.Length;i++)
            {
                inputSequence[i] = Int32.Parse(inputString[i]);
            }
            //int[] inputSequence = new int[] { 10, 22, 9, 33, 21, 50, 41, 60 };
            
            //Recurssion(inputSequence);
            //Tabulation(inputSequence);
            OptimizedAlgo(inputSequence);
        }

        #region Recurssion
        private int recurssionCounter;
        private void Recurssion(int[] inputSequence)
        {
            recurssionCounter = 0;
            Stopwatch sc = new Stopwatch();
            sc.Start();
            int result = LongestIncreasingSubsequenceMethod(inputSequence);
            sc.Stop();

            Console.WriteLine("Result: " + result);
            Console.WriteLine("Time taken: " + sc.Elapsed.ToString("G"));
            Console.WriteLine("Number of time recursive method called: " + recurssionCounter);
        }

        private int LongestIncreasingSubsequenceMethod(int[] arr)
        {
            for(int i = 0; i< arr.Length; i++)
            {
                LongestIncreasingSubsequenceInternal(SubArray(arr, i,1), SubArray(arr, i+1 , arr.Length  - i - 1));
            }
            return increasingSubSequence.Count == 0 ? 0 : increasingSubSequence.Last().Key;
        }

        private void LongestIncreasingSubsequenceInternal(int[] inputSequence, int[] subSequence)
        {
            recurssionCounter++;
            if(increasingSubSequence.ContainsKey(inputSequence.Length))
            {
                increasingSubSequence[inputSequence.Length].Add(inputSequence);
            }
            else
            {
                increasingSubSequence[inputSequence.Length] = new List<int[]>{inputSequence};
            }
            
            if(subSequence.Length == 0)
            {
                return;
            }
            for(int i = 0; i < subSequence.Length; i++)
            {
                if(inputSequence[inputSequence.Length - 1] < subSequence[i])
                {
                    var newinputSequence = inputSequence.ToList();
                    newinputSequence.Add(subSequence[i]);
                    if(i != subSequence.Length)
                    {
                        LongestIncreasingSubsequenceInternal(newinputSequence.ToArray(), SubArray(subSequence, i+1, subSequence.Length -i - 1));
                    }
                }
            }
        }

        private int[] SubArray(int[] data, int index, int length)
        {
            int[] result = new int[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        #endregion

        #region Tabulation

        Dictionary<int, int> increasingSubSequenceLength = new Dictionary<int, int>(); 
        private void Tabulation(int[] inputSequence)
        {
            Console.WriteLine("\n\nLIS using Tabulation:");
            Stopwatch sc = new Stopwatch();
            sc.Start();
            for(int i= inputSequence.Length - 1; i>=0; i--)
            {
                TabulationInternal(i, inputSequence);
            }
            sc.Stop();

            Console.WriteLine("Result: " + increasingSubSequenceLength.Values.Max());
            Console.WriteLine("Time taken: " + sc.Elapsed.ToString("G"));
        }

        private void TabulationInternal(int startIndex, int[] inputSequence)
        {
            if(startIndex == inputSequence.Length - 1)
            {
                increasingSubSequenceLength[startIndex] = 1;
                return;
            }
            increasingSubSequenceLength[startIndex] = 1;
            for( int nextIndex = startIndex + 1; nextIndex < inputSequence.Length; nextIndex++)
            {
                if(inputSequence[startIndex] < inputSequence[nextIndex])
                {
                    if(increasingSubSequenceLength[startIndex] <= increasingSubSequenceLength[nextIndex])
                    {
                        increasingSubSequenceLength[startIndex] = increasingSubSequenceLength[nextIndex]+1;
                    }
                }
            }
        }

        #endregion

        #region Optimized Algorithm

        private IList<int> longestIncreasingSubsequenceList = new List<int>();

        private void OptimizedAlgo(int[] arr)
        {
            Console.WriteLine("\n\nLIS using Optimized Algo:");
            Stopwatch sc = new Stopwatch();
            sc.Start();
            longestIncreasingSubsequenceList.Add(arr[arr.Length - 1]);
            for(int i= arr.Length - 2; i>=0; i--)
            {
                OptimizedAlgoInternal(arr[i]);
            }
            sc.Stop();

            Console.WriteLine("Result: " + longestIncreasingSubsequenceList.Count);
            Console.WriteLine("Time taken: " + sc.Elapsed.ToString("G"));
        }

        private void OptimizedAlgoInternal(int value)
        {
            if(longestIncreasingSubsequenceList[0] <= value)
            {
                longestIncreasingSubsequenceList[0] = value;
                return;
            }
            
            int i = longestIncreasingSubsequenceList.Count - 1;
            for( ; i >=0 ; i--)
            {
                if(longestIncreasingSubsequenceList[i] > value)
                {
                    if(longestIncreasingSubsequenceList.Count > i + 1)
                    {
                        if(longestIncreasingSubsequenceList[i + 1] < value)
                        {
                            longestIncreasingSubsequenceList[i+1] = value;
                            return;
                        }
                    }
                    else
                    {
                        longestIncreasingSubsequenceList.Add(value);
                        return;
                    }
                }
            }
        }

        #endregion
    }
}