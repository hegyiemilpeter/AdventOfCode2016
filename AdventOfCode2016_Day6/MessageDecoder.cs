using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016_Day6
{
    public static class MessageDecoder
    {
        public static void GetDecodedMessage(string fileName, bool mostCommon)
        {
            string[] lines = File.ReadAllLines(fileName);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lines[0].Length; i++)
            {
                var l = lines.Select(x => x[i]);

                Dictionary<char, int> charCounter = new Dictionary<char, int>();
                foreach (char item in l.Distinct())
                {
                    charCounter.Add(item, l.Count(x => x == item));
                }

                if (mostCommon)
                    sb.Append(charCounter.OrderByDescending(x => x.Value).Select(x => x.Key).First());
                else 
                    sb.Append(charCounter.OrderBy(x => x.Value).Select(x => x.Key).First());

                }

                Console.WriteLine(sb.ToString());
        }
    }
}
