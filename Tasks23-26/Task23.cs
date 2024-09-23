using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Tasks23_26
{
    /* 
            * Author : Ciobanu Stanislav
            * Date : 23.09.2024
            * Task : Exercise 23 from .Net home work
    */
    public class Task23
    {
        public void Execute()
        {
            string input = Console.ReadLine().Trim();
            string[] values = input.Split(' ');


            foreach (string value in values)
            {

                if (int.TryParse(value, out int _))
                {
                    Console.Write("int");
                }
                else if (float.TryParse(value, CultureInfo.InvariantCulture, out float _))
                {
                    Console.Write("float");
                }
                else if (char.TryParse(value, out char _))
                {
                    Console.Write("char");
                }
                else if (bool.TryParse(value, out bool _))
                {
                    Console.Write("bool");
                }
                else
                {
                    Console.Write("string");
                }

                Console.Write(' ');
            }
        }
    }
}
