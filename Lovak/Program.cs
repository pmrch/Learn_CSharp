using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Lovak
{
    class Program
    {
        static int Seged(int erosseg)
        {
            int helper = erosseg - 50;
            int num = 0;

            if (helper % 5 == 0) num = helper;
            else if (helper / 5 >= 1) num = ((helper / 5) + 1) * 5;

            return num;
        }            

        static void Main(string[] args)
        {
            List<int> erossegek = new List<int>();
            foreach (var item in File.ReadAllLines("be1.txt")) erossegek.Add(int.Parse(item));
            
            int N = erossegek[0];

            for (int i = 1; i <= N; i++)
            {
                if (erossegek[i] <= 50) Console.WriteLine(0);
                else if (erossegek[i] > 50 && erossegek[i] <= 90) Console.WriteLine(Seged(erossegek[i]));
                else if (erossegek[i] > 90) Console.WriteLine(45);
            }
        }
    }
}
