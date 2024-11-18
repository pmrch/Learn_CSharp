using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.WebSockets;

namespace Helsinki
{
    class Program
    {
        struct HelsinkiSorok
        {
            public int helyezes, sportolok;
            public string sportag, versenyszam;
        }
        static void Main(string[] args)
        {
            List<HelsinkiSorok> pontszerzok = new List<HelsinkiSorok>();
            
            using (StreamReader reader = new StreamReader("helsinki.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] egy_sor = reader.ReadLine().Split(' ');;
                    
                    HelsinkiSorok seged = new HelsinkiSorok();
                    seged.helyezes = int.Parse(egy_sor[0]);
                    seged.sportolok = int.Parse(egy_sor [1]);
                    seged.sportag = egy_sor[2];
                    seged.versenyszam = egy_sor[3];

                    pontszerzok.Add(seged);
                }
            }

            foreach (var item in pontszerzok)
            { 
                Console.WriteLine("{0}\t{1}", item.helyezes, item.sportolok);
            }

            Console.WriteLine("\n3. feladat");
            Console.WriteLine("A pontszerző helyezések száma: {0}", pontszerzok.Count(), "\n");
            
            // 4. Feladat
            int arany = 0, ezust = 0, bronz = 0, osszes = 0;
            foreach (var item in pontszerzok)
            {
                if (item.helyezes == 1)
                {
                    arany++;
                    osszes++;
                }
                else if (item.helyezes == 2)
                {
                    ezust++;
                    osszes++;
                }
                else if (item.helyezes == 3)
                {
                    bronz++;
                    osszes++;
                }

                /* Ez is mukodik, csak nem tudom hogy elfogadott-e
                switch (item.helyezes)
                {
                    case 1: 
                        arany++;
                        osszes++;
                        break;
                    case 2:
                        ezust++;
                        osszes++;
                        break;
                    case 3:
                        bronz++;
                        osszes++;
                        break;
                }
                */
            }
            Console.WriteLine("4. feladat");
            Console.WriteLine("Arany: {0}\nEzust: {1}\nBronz: {2}\nOsszesen: {3}\n", arany, ezust, bronz, osszes);
            
            // 5. Feladat
            Console.WriteLine("5. feladat");
            int pontszamok = 0;
            
            foreach (var item in pontszerzok)
            {
                switch (item.helyezes)
                {
                    case 1:
                        pontszamok += 7;
                        break;
                    case 2:
                        pontszamok += 5;
                        break;
                    case 3:
                        pontszamok += 4;
                        break;
                    case 4:
                        pontszamok += 3;
                        break;
                    case 5:
                        pontszamok += 2;
                        break;
                    case 6:
                        pontszamok += 1;
                        break;
                }
            }
            Console.WriteLine("Olimpiai pontok szama: {0}\n", pontszamok);
            Console.WriteLine("6. feladat");

            int uszas_ermek = 0, torna_ermek = 0;
            foreach (var item in pontszerzok)
            {
                switch (item.sportag)
                {
                    case "uszas":
                        uszas_ermek++;
                        break;
                    case "torna":
                        torna_ermek++;
                        break;
                }
            }

            if (uszas_ermek > torna_ermek)
                Console.WriteLine("Uszas sportagban szereztek tobb ermet");
            else if (uszas_ermek == torna_ermek)
                Console.WriteLine("Torna es uszas sportagban ugyanannyi ermet szereztek");
            else
                Console.WriteLine("Torna sportagban szereztek tobb ermet\n");

            // 7. Feladat
            List<HelsinkiSorok> masolat = new List<HelsinkiSorok>();
            using (StreamWriter writer = new StreamWriter("helsinki2.txt"))
            {
                HelsinkiSorok seged = new HelsinkiSorok();

                foreach (var item in pontszerzok)
                {
                    seged.helyezes = item.helyezes;
                    seged.sportolok = item.sportolok;
                    seged.versenyszam = item.versenyszam;
                    seged.sportag = item.sportag;

                    if (item.sportag == "kajakkenu")                    
                        seged.sportag = "kajak-kenu";

                    masolat.Add(seged);
                }

                int olimpiai_pont = 0;
                foreach (var item in masolat)                
                {
                    switch (item.helyezes) {
                        case 1: olimpiai_pont = 7; break; case 2: olimpiai_pont = 5; break; case 3: olimpiai_pont = 4; break;
                        case 5: olimpiai_pont = 3; break; case 6: olimpiai_pont = 2; break; case 7: olimpiai_pont = 1; break;
                    }
                    writer.WriteLine("{0} {1} {2} {3} {4}", item.helyezes, item.sportolok, olimpiai_pont, item.sportag, item.versenyszam);
                }   
            }
            // 8. Feladat
            Console.WriteLine("8. feladat");
            
            int legnagyobb_csapat = 0;;
            HelsinkiSorok segito = new HelsinkiSorok();

            foreach (var item in masolat)
            {
                if (legnagyobb_csapat < item.sportolok)
                {
                    legnagyobb_csapat = item.sportolok;
                    segito.helyezes = item.helyezes; segito.sportolok = item.sportolok;
                    segito.sportag = item.sportag; segito.versenyszam = item.versenyszam;
                }
            }
            Console.WriteLine("Helyezes: {0}\nSportag: {1}\nVersenyszam: {2}\nSportolok Szama: {3}",
            segito.helyezes, segito.sportag, segito.versenyszam, segito.sportolok);
        }
    }
}