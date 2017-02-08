using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixup.Business;

namespace Ixup.Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Question1();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                Console.ReadLine();
            }
        }

        static void Question1()
        {
            Console.WriteLine("Enter 3 sides of triangle:");
            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                var measures = input.Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries);

                if (measures.Length >= 3)
                {
                    var triangle = new Triangle(Convert.ToDouble(measures[0]), Convert.ToDouble(measures[1]),
                        Convert.ToDouble(measures[2]));

                    Console.WriteLine($"This is a {triangle.Type} triangle.");
                    Console.ReadLine();
                }
            }
        }
    }
}
