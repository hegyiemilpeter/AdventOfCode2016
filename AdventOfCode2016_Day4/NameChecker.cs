using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2016_Day4
{
    public static class NameChecker
    {
        public static int GetTheSumOfTheIds(string filename)
        {
            string input = File.ReadAllText(filename);
            string[] lines = Regex.Split(input, "\r\n");
            int response = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                response += GetIdForLine(lines[i]);
            }

            Console.WriteLine(input);
            Console.WriteLine("Sum of the valid ID-s: " + response);
            return response;
        }

        public static void DecodeFileAndFindNorth(string fileName)
        {
            string input = File.ReadAllText(fileName);
            string[] lines = Regex.Split(input, "\r\n");

            for (int i = 0; i < lines.Length; i++)
            {
               string result = Decode(lines[i]);
               if (result.Contains("north"))
                   Console.WriteLine(result + " line: " + lines[i]);
            }
        }

        public static string Decode(string input)
        {
            int id = GetIdForLine(input);

            if (id != 0)
            {
                string[] allitems = Regex.Split(input, "-");
                allitems = allitems.Take(allitems.Length - 1).ToArray();

                string[] newItems = new string[allitems.Length];

                for (int i = 0; i < id; i++)
                {
                    for (int j = 0; j < allitems.Length; j++)
                    {
                        StringBuilder sb = new StringBuilder();

                        for (int k = 0; k < allitems[j].Length; k++)
                        {
                            char c = allitems[j][k];

                            if (c == 'z')
                            {
                                c = 'a';
                            }
                            else
                            {
                                c++;
                            }

                            sb.Append(c, 1);
                        }

                        newItems[j] = sb.ToString();
                    }

                    allitems = newItems;
                }

                StringBuilder sb2 = new StringBuilder();
                for (int i = 0; i < allitems.Length; i++)
                {
                    sb2.Append(allitems[i]);
                    if (i != allitems.Length - 1)
                        sb2.Append(" ");
                }

                string result = sb2.ToString();
                return result;
            }

            return string.Empty;
        }

        public static int GetIdForLine(string input)
        {
            int response = 0;

            string[] allitems = Regex.Split(input, "-");
            Dictionary<char, int> counter = new Dictionary<char, int>();

            for (int i = 0; i < allitems.Length-1; i++)
            {
                for (int j = 0; j < allitems[i].Length; j++)
                {
                    char actualCharacter = allitems[i][j];

                    if  (counter.ContainsKey(actualCharacter))
                    {
                        counter[actualCharacter]++;
                    }
                    else
                    {
                        counter.Add(actualCharacter, 1);
                    }
                }
            }

            char[] ordered = counter.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(5).Select(x => x.Key).ToArray();

            string[] lastItems = Regex.Split(allitems[allitems.Length - 1], @"\[");
            lastItems[1] = lastItems[1].Replace("]", string.Empty);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < ordered.Count(); i++)
            {
                builder.Append(ordered[i], 1);
            }

            if (string.Equals(lastItems[1], builder.ToString()))
                response = int.Parse(lastItems[0]);

            return response;
        }
    }
}
