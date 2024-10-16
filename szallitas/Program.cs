using System.Threading.Channels;

namespace szallitas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targyak = { 16, 8, 9, 4, 3, 2, 4, 7, 7, 12, 3, 5, 4, 3, 2 };
            List<int> targyakk = new List<int>();

            // Lista feltöltése
            // targyak.ToList();

            for (int i = 0; i < targyak.Length; i++)
            {
                targyakk.Add(targyak[i]);
            }
            

            Console.WriteLine("2. Feladat");
            int ossz_tomb = 0;
            int ossz_list = 0;

            foreach (int items in targyakk)
            {
                ossz_list += items;
            }

            foreach (int item in targyak)
            {
                ossz_tomb += item;
            }
            Console.WriteLine("A tárgyak össege a tömbben: {0}", ossz_tomb);
            Console.WriteLine("A tárgyak össege a listában: {0}", ossz_list);

            Console.WriteLine();
            Console.WriteLine("3. Feladat");

            Console.Write("A dobozok tartalmának tömege {0} kg", ossz_list);
            Console.WriteLine();

            int dobozok_szama = 0;
            int doboz = 0;

            for (int k = 0; k < targyak.Length - 1; k++)
            {
                doboz += targyakk[k];
                if (doboz + targyakk[k+1] > 20)
                {
                    Console.Write(" {0}", doboz);
                    doboz = 0;
                    dobozok_szama++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("A szükséges dobozok száma: {0}", dobozok_szama);
        }
    }
}
