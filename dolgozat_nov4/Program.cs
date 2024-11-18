using System.Reflection.Metadata;

namespace dolgozat_nov4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Feladat
            // A csoport

            // 2. Feladat
            List<int> szamok = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i <= 10; i++)
            {
                szamok.Add(rnd.Next(0, 91));
            }
            foreach (int szam in szamok)
            {
                Console.Write("{0, 3}", szam);
            }
            Console.WriteLine();
            Console.WriteLine();

            // 3. Feladat
            int osszeg = 0;
            foreach (int szam in szamok)
            {
                if (szam < 30)
                {
                    osszeg += szam;
                }
            }
            Console.WriteLine("A 30 alatti számok összege: {0}", osszeg);
            Console.WriteLine();

            // 4. Feladat
            bool van = false;
            int sorszam = 0;

            for (int i = 0; i <= 10; i++)
            {
                if (szamok[i] == 25)
                {
                    sorszam = i + 1;
                    van = true;
                }
            }

            if (van == true)
            {
                Console.WriteLine("A 25-ös sorszáma: {0}", sorszam);
            }
            else
            {
                Console.WriteLine("Hiba történt: Nincs 25-ös a tömbben");
            }
            Console.WriteLine();

            // 5. Feladat
            int kisebb_mint_otven = 0;

            foreach (int szam in szamok)
            {
                if (szam < 50)
                {
                    kisebb_mint_otven++;
                }
            }
            Console.WriteLine("Az 50-nél kisebb elemek száma: {0}", kisebb_mint_otven);
            Console.WriteLine();

            // 6. Feladat
            foreach (int szam in szamok)
            {
                if (szam < 30 && szam > 20)
                {
                    Console.WriteLine("A(z) {0} az első 20 és 30 közötti szám a tömbben", szam);
                    break;
                }
            }
            Console.WriteLine();
            
            // 7. Feladat
            List<int> masodik_tomb  = new List<int>();
            foreach (int szam in szamok)
            {
                masodik_tomb.Add(szam * 10);
            }
            foreach (int szam in masodik_tomb)
            {
                Console.Write("{0, 4}", szam);
            }
            Console.WriteLine();
        }
    }
}
