using System.Net.Http.Headers;

namespace Létra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] adatok = { 3, 1, 1, 2, 1, 5, 5, 4, 4, 4, 1, 2, 3, 6, 4, 6, 1, 4 };
            int[] masik_adatok = new int[adatok.Length];

            Random este_van = new Random();
            for (int i = 0; i < adatok.Count(); i++)
            {
                masik_adatok.Append(este_van.Next(1, 7));
            }

            List<int> adatok_lista = new List<int>()
            { 3, 1, 1, 2, 1, 5, 5, 4, 4, 4, 1, 2, 3, 6, 4, 6, 1, 4 };
            
            foreach (var item in adatok_lista)
            {
                Console.Write("{0}, ", item);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("2. Feladat");

            // 2. és 3. Feladat
            int mezok = 0;
            int letrak = 0;
            List<int> lepesek = new List<int>();

            foreach (var item in adatok_lista)
            {
                lepesek.Add(mezok);
                mezok += item;
                if (mezok % 10 == 0)
                {
                    mezok -= 3;
                    letrak++;
                }
                Console.Write("{0} ", mezok);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("3. Feladat");
            Console.WriteLine("A játék során {0} alkalommal lépett létrára.", letrak);
            Console.WriteLine();
            Console.WriteLine("4. Feladat");

            if (mezok >= 45)
            {
                Console.WriteLine("A játékot bejezte.");
            }
            else
            {
                Console.WriteLine("A játékot abbahagyta.");
            }
            {
                
            }

        }
    }
}
