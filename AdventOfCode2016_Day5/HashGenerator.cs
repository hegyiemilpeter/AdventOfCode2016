using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016_Day5
{
    public static class HashGenerator
    {
        public static string GetPassword(string input)
        {
            Console.WriteLine($"Password process for '{input}' started!");

            StringBuilder sb = new StringBuilder();

            int i = 0;
            int length = 0;
            while (length < 8)
            {
                string password = input + i.ToString();

                MemoryStream memoryStream = new MemoryStream();
                StreamWriter writer = new StreamWriter(memoryStream);
                writer.Write(password);
                writer.Flush();
                memoryStream.Position = 0;

                MD5 hash = MD5.Create();
                byte[] hashBytes = hash.ComputeHash(memoryStream);

               string hex =  BitConverter.ToString(hashBytes);

                if (hex.StartsWith("00-00-0"))
                {
                    sb.Append(hex[7]);
                    length++;
                    Console.Write(hex[7]);
                }

                i++;
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Process for '{input}' finished!");

            return sb.ToString();
        }

        public static string GetAdvancedPassword(string input)
        {
            Console.WriteLine($"Advanced password process for '{input}' started!");

            StringBuilder sb = new StringBuilder();

            int i = 0;
            int length = 0;
            char[] response = new char[] { '_', '_', '_', '_', '_', '_', '_', '_', } ;

            while (length < 8)
            {
                string password = input + i.ToString();

                MemoryStream memoryStream = new MemoryStream();
                StreamWriter writer = new StreamWriter(memoryStream);
                writer.Write(password);
                writer.Flush();
                memoryStream.Position = 0;

                MD5 hash = MD5.Create();
                byte[] hashBytes = hash.ComputeHash(memoryStream);

                string hex = BitConverter.ToString(hashBytes);

                if (hex.StartsWith("00-00-0"))
                {
                    int position = 0;
                    string s = new string(new char[] { hex[7] });
                    if(int.TryParse(s, out position))
                    {
                        if (position >= 0 && position <= 7 && response[position] == '_')
                        {
                            response[position] = hex[9];

                            for (int j = 0; j < response.Length; j++)
                            {
                               Console.Write(response[j] + " ");
                            }

                            length++;
                            Console.WriteLine(Environment.NewLine);
                        }
                    }
                }

                i++;
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Process for '{input}' finished!");

            return sb.ToString();
        }
    }
}
