namespace Bármi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random tipmix = new Random();
            string alma = "körte";
            int[] betuk = new int[10];
            betuk[2] = tipmix.Next(10, 101);
            // Van-e típuseltérési hiba

            for (int k = 1; k < 16; k++)
            {
            }
            int[] adatok = { 10, 3, 11, 1, 25, 32, 14, 9, 88, 7 };
            for (int i = 0; i < adatok.Length; i++)
            {
                Console.Write("{0,3}", adatok[i]);
            }
            int osszeg = 0;
            for (int a = 0; a < adatok.Length; a++)
            {
                //osszeg = osszeg + adatok[a];
                osszeg += adatok[a];
            }
            Console.WriteLine();
            Console.WriteLine("A tömb elemeinek összege: {0}", osszeg);

            int minimum = adatok[0];
            for (int m = 1; m < adatok.Length; m++)
            {
                if (adatok[m] < minimum)
                {
                    minimum = adatok[m];
                }
            }
            Console.WriteLine("A legkisebb elem: {0}", minimum);
            
            int maximum = adatok[0];
            for (int n = 1; n < adatok.Length; n++)
            {
                if (adatok[n] > maximum)
                {
                    maximum = adatok[n];
                }
            }
            Console.WriteLine("A legnagyobb elem: {0}", maximum);

            Console.Write("A páros számok: ");
            for (int z = 0; z < adatok.Length; z++)
            {
                if (adatok[z] % 2 == 0)
                {
                    Console.Write("{0, 3}", adatok[z]);
                }
            }
            Console.WriteLine();

            Array.Sort(adatok);
            for (int b = 0; b < adatok.Length; b++)
            {
                Console.Write("{0,3}", adatok[b]);
            }
            Console.WriteLine();

            string[] játék = { "dom", "sár", "aba", "sar", "kat" };
            Array.Sort(játék);
            for (int c = 0; c < játék.Length; c++)
            {
                Console.Write("{0,4}", játék[c]);
            }
            Console.WriteLine();

            Console.Write("Második karaktere 'a': ");
            for (int d = 0; d < játék.Length; d++)
            {
                if (játék[d][1] == 'a')
                {
                    Console.Write("{0,4}", játék[d]);
                }
            }
        }
    }
}
