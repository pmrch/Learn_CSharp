using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaror
{
    class Meres
    {
        public int Ora { get; set; }
        public int Perc { get; set; }
        public int Mperc { get; set; }
        public string Rendszám { get; set; }
        public string Adat { get; set; }

        public int IDŐ()
        {
            return (Ora*60+Perc)*60 +Mperc;
        }

        public Meres(string sor)
        {
            string[] adatok = sor.Split(' ');
            Ora = int.Parse(adatok[0]);
            Perc = int.Parse(adatok[1]);
            Mperc = int.Parse(adatok[2]);
            Rendszám = adatok[3];
            Adat = adatok[0] + ":" + adatok[1] + ":" + adatok[2];
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            List<Meres> meresek = new List<Meres>();
            using (System.IO.StreamReader sr = new System.IO.StreamReader("jarmu.txt"))
            {
                while (!sr.EndOfStream)
                {
                    meresek.Add(new Meres(sr.ReadLine()));
                }
            }

            Console.WriteLine("2. feladat");
            int munkaido = meresek[meresek.Count - 1].Ora - meresek[0].Ora;
            if (meresek[meresek.Count - 1].Perc == 0 && meresek[meresek.Count - 1].Mperc == 0)
            {
                Console.WriteLine("a munkaidő: {0} óra", munkaido);
            }
            else
            {
                Console.WriteLine("A munkaidő: {0} óra", munkaido + 1);
            }

            Console.WriteLine("\n3. feladat");
            Console.WriteLine("{0,4} óra: {1}", meresek[0].Ora, meresek[0].Rendszám);
            int i = 1;
            do
            {
                if (meresek[i - 1].Ora != meresek[i].Ora)
                {
                    Console.WriteLine("{0,4} óra: {1}", meresek[i].Ora, meresek[i].Rendszám);
                }
                ++i;
            } while (i < meresek.Count);

            Console.WriteLine("\n4. feladat");

            string[] tipus = new string[4] { "Busz", "Kamion", "Motor", "Egyéb" };
            int[] dbk = new int[4] { 0, 0, 0, 0 };
            for (i = 0; i < meresek.Count; i++)
            {
                switch (meresek[i].Rendszám[0])
                {
                    case 'B': dbk[0]++;
                        break;
                    case 'K': dbk[1]++;
                        break;
                    case 'M': dbk[2]++;
                        break;
                    default: dbk[3]++;
                        break;
                }
            }
            for (i = 0; i < 4; i++)
            {
                Console.WriteLine("\t{0, -8} {1,3}", tipus[i], dbk[i]);
            }

            Console.WriteLine("\n5. feladat");
            int maxh = 0;
            int maxé = 0;
            for (i = 0; i < meresek.Count - 1; i++)
            {
                if (meresek[i + 1].IDŐ() - meresek[i].IDŐ() > maxé)
                {
                    maxé = meresek[i + 1].IDŐ() - meresek[i].IDŐ();
                    maxh = i;
                }
            }
            Console.WriteLine("{0}:{1}:{2} - {3}:{4}:{5}", meresek[maxh].Ora, meresek[maxh].Perc, meresek[maxh].Mperc, meresek[maxh + 1].Ora, meresek[maxh + 1].Perc, meresek[maxh + 1].Mperc);

            Console.WriteLine("\n6. feladat");
            Console.Write("Adja meg a keresett rendszámot! (Helyettesítse az ismeretlen karatkereket *-gal: ");
            string keresett = Console.ReadLine();
            int db = 0;
            for (i = 0; i < meresek.Count; i++)
            {
                db = 0;
                for (int j = 0; j < 7; j++)
                { 
                    if (meresek[i].Rendszám[j] == keresett[j] || keresett[j] == '*')
                    {
                        ++db;
                    }
                }
                if (db == 7)
                {
                    Console.WriteLine(meresek[i].Rendszám);
                }
            }

            Console.WriteLine("\n7. feladat");

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("vizsgalt.txt"))
            {
                sw.WriteLine("{0}  {1}", meresek[0].Adat, meresek[0].Rendszám);
                int mert = 0;
                for (i = 0; i < meresek.Count; i++)
                {
                    if (meresek[i].IDŐ()> meresek[mert].IDŐ() + 300)
                    {
                        mert = i;
                        sw.WriteLine("{0}  {1}", meresek[mert].Adat, meresek[mert].Rendszám);
                    }
                }

            }
            Console.WriteLine("A kiírás befejeződött");
            Console.ReadKey();

        }
    }
}
