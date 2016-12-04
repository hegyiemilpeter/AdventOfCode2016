using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016_Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (NameChecker.GetIdForLine("aaaaa-bbb-z-y-x-123[abxyz]") != 123)
                Console.WriteLine("Error in test 1");

            if (NameChecker.GetIdForLine("a-b-c-d-e-f-g-h-987[abcde]") != 987)
                Console.WriteLine("Error in test 2");

            if (NameChecker.GetIdForLine("not-a-real-room-404[oarel]") != 404)
                Console.WriteLine("Error in test 3");

            if (NameChecker.GetIdForLine("totally-real-room-200[decoy]") != 0)
                Console.WriteLine("Error in test 4");

            NameChecker.GetTheSumOfTheIds(@"..\\..\\adventOfCode2016_day4_input.txt");

            NameChecker.DecodeFileAndFindNorth(@"..\\..\\adventOfCode2016_day4_input.txt");

            Console.ReadLine();
        }
    }
}
