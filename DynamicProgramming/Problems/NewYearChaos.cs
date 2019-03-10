using System;
using System.Diagnostics;
using System.IO;

namespace DynamicProgramming
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/new-year-chaos/problem
    /// </summary>
    public class NewYearChaos : IRun
    {
        public void Run()
        {
            Console.WriteLine("New Year Chaos is running");

            var inputString = File.ReadAllLines(@".\Resources\NewYearChaos.txt");
            int numberOfTestCases = Convert.ToByte(inputString[0]);

            Stopwatch sc = new Stopwatch();
            sc.Start();

            for(int testCase = 0; testCase < numberOfTestCases; testCase++)
            {
                int[] arr = Array.ConvertAll(inputString[(testCase * 2) + 2].Split(' '), arrTemp => Convert.ToInt32(arrTemp));
                MinimumBribes(arr);
            }

            sc.Stop();
            Console.WriteLine("Time taken: " + sc.Elapsed.ToString("G"));
        }

        void MinimumBribes(int[] q) 
        {
            var minimumNoOfBribes = 0;
            var maxNoTillNow = 0;
            for(int i = 0; i<q.Length; i++)
            {
                //First condition finds how many places has a person jumped if they are in fornt of their original position
                if(q[i] > i+1)
                {
                    //If the person has jumped more than 2 position, it will be an error condition
                    if(q[i] - i - 1 > 2)
                    {
                        Console.WriteLine("Too chaotic");
                        return;
                    }
                    minimumNoOfBribes += q[i] - i - 1;
                }
                //Next condition if the person is in their own position, they might have jumped
                //To check this, see is there is someone with greater value in front of them
                else if(q[i] == i + 1)
                {
                    if(q[i] < maxNoTillNow)
                    {
                        minimumNoOfBribes++;
                    }
                }
                //Last condition is to see if the person who is behind their position, has jumped
                //For that compare the number of people with greater value in front of them with its displaced value
                else
                {
                    var displacedValue = i+1 - q[i];
                    int noOfPeopleJumpedAheadOfMe = 0;
                    var traverseLength = q[i] - 2 < 0 ? 0 : q[i] - 2;
                    for(int j = i-1; j >= traverseLength; j--)
                    {
                        if(q[i] < q[j])
                        {
                            noOfPeopleJumpedAheadOfMe++;
                        }
                    }

                    minimumNoOfBribes += noOfPeopleJumpedAheadOfMe - displacedValue;
                }

                maxNoTillNow = maxNoTillNow > q[i] ? maxNoTillNow : q[i];
            }
            Console.WriteLine(minimumNoOfBribes);
        }
    }
}