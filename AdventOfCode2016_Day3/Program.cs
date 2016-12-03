using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016_Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("..\\..\\adventOfCode2016_day3_input.txt");

            TriangleCalculator.GetTheNumberOfValidTriangles("5 10 25");
            TriangleCalculator.GetTheNumberOfValidTriangles("2 2 4");

            TriangleCalculator.AdvancedGetTheNumberOfValidTriangles(@"2 2 4
4 10 15
3 6 9
1 2 3
4 5 6
7 8 9");


            TriangleCalculator.AdvancedGetTheNumberOfValidTriangles(input);


            Console.ReadLine();
        }
    }
}
