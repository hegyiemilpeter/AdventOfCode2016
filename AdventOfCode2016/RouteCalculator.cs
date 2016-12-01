using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2016
{
    public static class RouteCalculator
    {
        public static int Calculate(string input)
        {
            // Initialization and starting position
            List<Tuple<int, int>> alreadyWereHere = new List<Tuple<int, int>>();
            alreadyWereHere.Add(new Tuple<int, int>(0, 0));
            int x = 0;
            int y = 0;
            int xMultiplier = 1;
            int yMultiplier = 0;
            bool loopFound = false;

            // Splitting the items
            string[] inputArray = Regex.Split(input, ",");

            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = inputArray[i].Trim();
                char direction = inputArray[i][0];
                int val = int.Parse(inputArray[i].Trim(inputArray[i][0]));

                if (i % 2 == 0)
                {
                    // We on Y
                    if (xMultiplier == 1)
                    {
                        if (direction == 'R')
                            yMultiplier = 1;
                        else
                            yMultiplier = -1;
                    }
                    else
                    {
                        if (direction == 'R')
                            yMultiplier = -1;
                        else
                            yMultiplier = 1;
                    }

                    for (int j = 0; j < val; j++)
                    {
                        y += yMultiplier;
                        CheckLoop(alreadyWereHere, ref x, ref y, ref loopFound);
                    }
                }
                else
                {
                    // We go on X
                    if (yMultiplier == 1)
                    {
                        if (direction == 'R')
                            xMultiplier = -1;
                        else
                            xMultiplier = 1;
                    }
                    else
                    {
                        if (direction == 'R')
                            xMultiplier = 1;
                        else
                            xMultiplier = -1;
                    }

                    for (int j = 0; j < val; j++)
                    {
                        x += xMultiplier;
                        CheckLoop(alreadyWereHere, ref x, ref y, ref loopFound);
                    }

                }
            }

            if (x < 0)
            {
                x = x * -1;
            }

            if (y < 0)
            {
                y = y * -1;
            }

            int distance = x + y;
            Console.WriteLine("Distance to bunny: " + distance);

            return distance;
        }

        private static void CheckLoop(List<Tuple<int, int>> alreadyWereHere, ref int x, ref int y, ref bool loopFounded)
        {
            if (loopFounded)
            {
                return;
            }

            int y1 = y;
            int x1 = x;

            if (alreadyWereHere.FirstOrDefault(h => h.Item1 == x1 && h.Item2 == y1) != null)
            {
                loopFounded = true;

                if (x < 0)
                {
                    x1 = x * -1;
                }

                if (y < 0)
                {
                    y1 = y * -1;
                }

                int di1 = x1 + y1;

                Console.WriteLine("First loop at: " + di1);
            }
            else
            {
                alreadyWereHere.Add(new Tuple<int, int>(x, y));
            }
        }
    }
}
