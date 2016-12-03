using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2016_Day3
{
    public static class TriangleCalculator
    {
        public static int GetTheNumberOfValidTriangles(string input)
        {
            int count = 0;

            string[] triangles = Regex.Split(input, "\r\n");

            for (int i = 0; i < triangles.Length; i++)
            {
                string[] triangle = Regex.Split(triangles[i], " ").Where(x => !string.IsNullOrEmpty(x)).ToArray();
                int[] triangleValues = new int[3];

                for (int j = 0; j < 3; j++)
                {
                    triangleValues[j] = int.Parse(triangle[j].Trim());
                }
                
                if (IsValidTriangle(triangleValues[0], triangleValues[1], triangleValues[2]))
                {
                    count++;
                }
            }

            Console.WriteLine(input);
            Console.WriteLine("The number of valid triangles: " + count);

            return count;
        }

        public static int AdvancedGetTheNumberOfValidTriangles(string input)
        {
            int count = 0;

            string[] triangles = Regex.Split(input, "\r\n");
            int[,] triangleValues = new int[3, triangles.Length];

            for (int i = 0; i < triangles.Length; i++)
            {
                string[] triangle = Regex.Split(triangles[i], " ").Where(x => !string.IsNullOrEmpty(x)).ToArray();
                triangleValues[0, i] = int.Parse(triangle[0]);
                triangleValues[1, i] = int.Parse(triangle[1]);
                triangleValues[2, i] = int.Parse(triangle[2]);
            }
            
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < triangles.Length; k += 3)
                {
                    if (IsValidTriangle(triangleValues[j, k], triangleValues[j, k+1], triangleValues[j, k+2]))
                        count++;
                }
            }

            Console.WriteLine(input);
            Console.WriteLine("The number of valid  triangles (advance): " + count);

            return count;
        }

        private static bool IsValidTriangle(int a, int b, int c)
        {
            bool valid = true;

            if (a + b <= c || b + c <= a || a + c <= b)
            {
                valid = false;
            }

            return valid;
        }
    }
}
