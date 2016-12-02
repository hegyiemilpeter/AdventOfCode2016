using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2016_Day2
{
    public static class BathroomCodeCalculator
    {
        public static int[] CalculateTheFirstCode(string input)
        {
            string[] lines = Regex.Split(input, "\r\n");
            int[] response = new int[lines.Length];

            int x = 1;
            int y = 1;

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    switch (lines[i][j])
                    {
                        case 'U':
                            if (x < 2)
                                x++;
                            break;
                        case 'D':
                            if (x > 0)
                                x--;
                            break;
                        case 'L':
                            if (y > 0)
                                y--;
                            break;
                        case 'R':
                            if (y < 2)
                                y++;
                            break;
                    }
                }

                if (x == 0)
                {
                    switch (y)
                    {
                        case 0:
                            response[i] = 7;
                            break;
                        case 1:
                            response[i] = 8;
                            break;
                        case 2:
                            response[i] = 9;
                            break;
                        default:
                            break;
                    }
                }
                else if (x == 1)
                {
                    switch (y)
                    {
                        case 0:
                            response[i] = 4;
                            break;
                        case 1:
                            response[i] = 5;
                            break;
                        case 2:
                            response[i] = 6;
                            break;
                        default:
                            break;
                    }
                }
                else if (x == 2)
                {
                    switch (y)
                    {
                        case 0:
                            response[i] = 1;
                            break;
                        case 1:
                            response[i] = 2;
                            break;
                        case 2:
                            response[i] = 3;
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine("Input: " + Environment.NewLine + input);
            Console.Write("Code: ");
            for (int i = 0; i < response.Length; i++)
            {
                Console.Write(response[i]);
            }

            Console.ReadLine();
            return response;
        }

        public static char[] CalculateTheSecondCode(string input)
        {
            string[] lines = Regex.Split(input, "\r\n");
            char[] response = new char[lines.Length];

            int x = 2;
            int y = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    switch (lines[i][j])
                    {
                        case 'U':
                            if (   (x == 0)
                                || (x == 1)
                                || (x == 2 && (y > 0 && y < 4))
                                || (x == 3 && y == 2)
                                )
                                x++;
                            break;
                        case 'D':
                            if (   (x == 4)
                                || (x == 3)
                                || (x == 2 && (y > 0 && y < 4))
                                || (x == 1 && y == 2)
                               )
                                x--;
                            break;
                        case 'L':
                            if (
                                   (y == 1 && x == 2)
                                || (y == 2 && (x > 0 && x < 4))
                                || (y == 3)
                                || (y == 4)
                                )
                                y--;
                            break;
                        case 'R':
                            if (
                                  (y == 0) 
                                || (y == 1)
                                || (y == 2 && (x > 0 && x < 4))
                                || (y == 3 && x == 2)
                                )
                                y++;
                            break;
                    }
                }

                if (x == 0 && y == 2)
                {
                    response[i] = 'D';
                }
                else if (x == 1)
                {
                    switch (y)
                    {
                        case 1:
                            response[i] = 'A';
                            break;
                        case 2:
                            response[i] = 'B';
                            break;
                        case 3:
                            response[i] = 'C';
                            break;
                        default:
                            break;
                    }
                }
                else if (x == 2)
                {
                    switch (y)
                    {
                        case 0:
                            response[i] = '5';
                            break;
                        case 1:
                            response[i] = '6';
                            break;
                        case 2:
                            response[i] = '7';
                            break;
                        case 3:
                            response[i] = '8';
                            break;
                        case 4:
                            response[i] = '9';
                            break;
                        default:
                            break;
                    }
                }
                else if (x == 3)
                {
                    switch (y)
                    {
                        case 1:
                            response[i] = '2';
                            break;
                        case 2:
                            response[i] = '3';
                            break;
                        case 3:
                            response[i] = '4';
                            break;
                        default:
                            break;
                    }
                }
                else if (x == 4 && y == 2)
                {
                    response[i] = '1';
                }
            }

            Console.WriteLine("Input: " + Environment.NewLine + input);
            Console.Write("Code: ");
            for (int i = 0; i < response.Length; i++)
            {
                Console.Write(response[i]);
            }

            Console.ReadLine();
            return response;
        }
    }
}
