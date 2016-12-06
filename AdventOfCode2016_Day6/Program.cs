using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016_Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageDecoder.GetDecodedMessage(@"..\\..\\Test.txt", true);

            MessageDecoder.GetDecodedMessage(@"..\\..\\adventOfCode2016_day6_input.txt", true);

            MessageDecoder.GetDecodedMessage(@"..\\..\\Test.txt", false);

            MessageDecoder.GetDecodedMessage(@"..\\..\\adventOfCode2016_day6_input.txt", false);

            Console.ReadLine();
        }
    }
}
