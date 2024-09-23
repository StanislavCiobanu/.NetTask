using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks23_26
{
    public class Task24
    {
        /* 
            * Author : Ciobanu Stanislav
            * Date : 20.09.2024
            * Task : Exercise 24 from .Net home work
        */
        public void Execute()
        {
            List<int> list = new List<int>();
            string input = Console.ReadLine().Trim();

            string[] values = input.Split(' ');

            if (values.Length >= 10)
            {
                foreach (string value in values)
                {
                    list.Add(int.Parse(value));
                }

                PrintList(list);

                Console.WriteLine("\nEnter value to remove");
                list.Remove(int.Parse(Console.ReadLine()));

                PrintList(list);

                Console.WriteLine("\nEnter index to remove");
                list.RemoveAt(int.Parse(Console.ReadLine()));

                PrintList(list);

                Console.WriteLine("\nRemoving elements in range of 2, 4");
                list.RemoveRange(2, 4);

                PrintList(list);

                Console.WriteLine("\nMax:");
                Console.WriteLine(list.Max(x => x));

                Console.WriteLine("\nMin:");
                Console.WriteLine(list.Min(x => x));

                Console.WriteLine("\nSum:");
                Console.WriteLine(list.Sum(x => x));
            }
            else 
            { 
                throw new NotEnoughValuesException();
            }
        }

        void PrintList(List<int> list)
        {
            Console.WriteLine("\n");
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
        }
    }

    // Throw if user did not enter enough values
    class NotEnoughValuesException : Exception
    {
        public NotEnoughValuesException() : base("Not enough values") { }
        public NotEnoughValuesException(string message) : base(message) { }
    }
}
