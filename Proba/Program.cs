﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            decimal fakt = 1;

            for (decimal i = 1; i <= 18; i++)
            {
                fakt = fakt * i;
                Console.WriteLine("{0}! {1}  ", i, fakt);
            }
            Console.ReadKey();
        */

            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rnd.Next(1, 90));
            }
            Console.ReadKey();
        }
    }
}
