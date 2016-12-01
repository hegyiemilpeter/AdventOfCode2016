using System; 

namespace AdventOfCode2016
{
    // Copyright: Emil Péter Hegyi 2016
    class Program
    {
        static void Main(string[] args)
        {
            string input = "L5, R1, R3, L4, R3, R1, L3, L2, R3, L5, L1, L2, R5, L1, R5, R1, L4, R1, R3, L4, L1, R2, R5, R3, R1, R1, L1, R1, L1, L2, L1, R2, L5, L188, L4, R1, R4, L3, R47, R1, L1, R77, R5, L2, R1, L2, R4, L5, L1, R3, R187, L4, L3, L3, R2, L3, L5, L4, L4, R1, R5, L4, L3, L3, L3, L2, L5, R1, L2, R5, L3, L4, R4, L5, R3, R4, L2, L1, L4, R1, L3, R1, R3, L2, R1, R4, R5, L3, R5, R3, L3, R4, L2, L5, L1, L1, R3, R1, L4, R3, R3, L2, R5, R4, R1, R3, L4, R3, R3, L2, L4, L5, R1, L4, L5, R4, L2, L1, L3, L3, L5, R3, L4, L3, R5, R4, R2, L4, R2, R3, L3, R4, L1, L3, R2, R1, R5, L4, L5, L5, R4, L5, L2, L4, R4, R4, R1, L3, L2, L4, R3";

            if (RouteCalculator.Calculate("R1, L1, R1, R1, R1") != 1)
            {
                Console.WriteLine("Error at case 1!");
            }

            if (RouteCalculator.Calculate("R1, L1, R1, R1") != 2)
            {
                Console.WriteLine("Error at case 2!");
            }

            if (RouteCalculator.Calculate("R2, L3") != 5)
            {
                Console.WriteLine("Error at case 3!");
            }

            if (RouteCalculator.Calculate("R2, R2, R2") != 2)
            {
                Console.WriteLine("Error at case 4!");
            }

            if (RouteCalculator.Calculate("L2, L2, L2") != 2)
            {
                Console.WriteLine("Error at case 5!");
            }

            if (RouteCalculator.Calculate("R5, L5, R5, R3") != 12)
            {
                Console.WriteLine("Error at case 6!");
            }

            if (RouteCalculator.Calculate("R1, L1, L1, L1") != 0)
            {
                Console.WriteLine("Error at case 7!");
            }

            RouteCalculator.Calculate(input);

            Console.ReadLine();
        }
    }
}


