using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Proba
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            for (int s = 0; s < 10; s++)
            {
                for (int i = 0; i < 10; i++)
                {
                    int x = rnd.Next(1, 91);
                    if (x < 10)
                    {
                        Console.Write(" {0}, ", x);
                    }
                    else
                    {
                        Console.Write("{0}, ", x);
                    }
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
