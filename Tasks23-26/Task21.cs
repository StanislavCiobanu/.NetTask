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
            * Task : Exercise 21 from .Net home work
    */
    public class Task21
    {
        public void Execute()
        {
            List<int> ints = new List<int>() { 1, 2, 3, 4, 5, 6 };

            ints.Add(7);
            ints.Remove(1);
            ints.Contains(2);
            ints.Find(x => x.Equals(5));
            ints.All(x => x.Equals(6));
            ints.Any(x => x.Equals(7));
            ints.Average();
            ints.First();
            ints.Last();
            ints.Clear();
        }
    }
}
