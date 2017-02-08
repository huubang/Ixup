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
                Question2();
                Question3();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                Console.ReadLine();
            }
        }

        static void Question1()
        {
            Console.WriteLine("--- Question 1 ---");
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

        static void Question2()
        {
            Console.WriteLine("--- Question 2 ---");
            Console.WriteLine("Enter a string:");
            string originalSentence = Console.ReadLine();
            if (originalSentence != null)
            {            
                Console.WriteLine(originalSentence.ReverseWords());
                Console.ReadLine();
            }            
        }

        static void Question3()
        {
            Console.WriteLine("--- Question 3 ---");

            var linkedList = new SinglyLinkedList();

            for (var i = 11; i > 1; i--)
            {
                linkedList.Insert(i);
            }

            SinglyLinkedListNode x = linkedList.NodeFromTail(5);
            Console.WriteLine("List: {0}", linkedList);
            Console.WriteLine("The 5th element from tail is: {0}", x.Value);
            Console.ReadLine();
        }
    }
}
