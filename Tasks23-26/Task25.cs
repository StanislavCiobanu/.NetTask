using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks23_26
{
    /* 
            * Author : Ciobanu Stanislav
            * Date : 23.09.2024
            * Task : Exercise 25 from .Net home work
    */
    public class Task25
    {
        public void Execute()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < 10; i++)
            {
                string input = Console.ReadLine();
                string[] values = input.Split(" ");
                dict.Add(values[0], int.Parse(values[1]));
            }

            /*For test
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                ["Student"] = 1,
                ["Student2"] = 2,
                ["Student3"] = 3,
                ["Student4"] = 4,
                ["Student5"] = 5,
                ["Student6"] = 6,
                ["Student7"] = 7,
                ["Student8"] = 8,
                ["Student9"] = 9,
                ["Student10"] = 10
            };*/

            Console.WriteLine("\nEnter a student to remove");
            dict.Remove(Console.ReadLine());
            PrintDict(dict);

            Console.WriteLine("\nEnter a student for changing the mark");
            dict[Console.ReadLine()] = 10;
            PrintDict(dict);

            Console.WriteLine("\nmax value: " + dict.Values.Max());

            void PrintDict(Dictionary<string, int> dict)
            {
                Console.WriteLine();
                foreach (var student in dict)
                {
                    Console.WriteLine(student.Key + ": " + student.Value);
                }
                Console.WriteLine();
            }
        }
    }
}
