using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace befozes
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> uvegek = new List<int>() { 5, 2, 2, 4, 3, 2, 4, 10, 5, 5, 3, 5, 4, 3, 3 };
            Console.WriteLine("2. feladat:");
            Console.Write("Mari néni lekvárja (dl): ");
            int l = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("3. feladat: ");

            //int max = uvegek.Max();
            //int index = uvegek.FindIndex(max);

            int max = 0;
            int index = 0;

            for (int i = 0; i < uvegek.Count(); i++)
            {
                if (uvegek[i]>max)
                {
                    max=uvegek[i];
                    index=i;

                }
            }
            
            Console.WriteLine("A legnagyobb üveg:{0} dl és {1}. a sorban", max, index);
            Console.WriteLine("4. feladat:");
            int sum = 0;
            foreach (var item in uvegek)
            {
                sum += item;
            }

            if (sum>=l)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Elegendő üveg volt.");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Maradt lekvár.");
            }
            Console.ResetColor();
            Console.WriteLine("proba");

            Console.ReadKey();
        }
    }
}
