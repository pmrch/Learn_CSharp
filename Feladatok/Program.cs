namespace Feladatok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Fejes Patrik */
            Console.WriteLine("alma".Length);
            Console.WriteLine();

            Console.WriteLine("1. Feladat");
            int[] tomb = new int[10];
            Random prog = new Random();

            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = prog.Next(0, 91);
                Console.Write("{0,3}", tomb[i]);
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("2. Feladat");
            int c = 0;

            for (int l = 0; l < tomb.Length; l++)
            {
                if (tomb[l] < 30)
                {
                    c += tomb[l];
                    // c = c + tomb[l] 
                }
            }
            Console.WriteLine("A 30-nál kisebb elemek összege: {0}", c);

            Console.WriteLine();
            Console.WriteLine("3. Feladat");
            tomb[0] = 25;

            int sorszam = 0;

            for (int j = 0; j < tomb.Length; j++)
            {
                if (tomb[j] == 25)
                {
                    sorszam = j + 1;
                }
            }

            if (sorszam == 0)
            {
                Console.WriteLine("Nincs benne 25");
            }

            else
            {
                Console.WriteLine("A 25 sorszáma: {0}", sorszam);
            }

            Console.WriteLine();
            Console.WriteLine("4. Feladat");
            int d = 0;

            for (int k = 0; k < tomb.Length; k++)
            {
                if (tomb[k] < 50)
                {
                    d++;
                }
            }

            if (d == 0)
            {
                Console.WriteLine("Nincs benne 50-nél kisebb elem");
            }

            else
            {
                Console.WriteLine("Az 50-nél kisebb elemek száma: {0}", d);
            }
            Console.WriteLine();

            Console.WriteLine("5. Feladat");
            bool van_benne = false;

            for (int m = 0; m < tomb.Length; m++)
            {
                if (tomb[m] > 20 && tomb[m] < 30)
                {
                    van_benne = true; break;
                }
                else
                {
                    van_benne = false;
                }
            }

            if (van_benne == true)
            {
                Console.WriteLine("Igen, a tömb tárol 20 és 30 közötti számokat");
            }

            else
            {
                Console.WriteLine("A tömb nem tartalmaz 20 és 30 közötti számot");
            }

            Console.WriteLine();
            Console.WriteLine("5. Feladat másként");

            van_benne = false;
            int g = 0;
            
            while (g < tomb.Length && van_benne == false)
            {
                if (tomb[g] > 20 && tomb[g] < 30)
                //if (tomb[g] <= 20 || tomb[g] >= 30) // Előző hamisítása
                {
                    van_benne = true;
                }
                g++;
            }

            if (van_benne == true)
            {
                Console.WriteLine("Igen, a tömb tárol 20 és 30 közötti számokat");
            }

            else
            {
                Console.WriteLine("A tömb nem tartalmaz 20 és 30 közötti számot");
            }
        }
    }
}
