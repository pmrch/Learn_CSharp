using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cimek
{
    class Program
    {
        static string[] ipc = new string[500];  //tárolja a címeket
        static int n = 0;                       //ip címek száma
        static string hc, rc;                   //7-8.feladathoz

        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();

            Console.ReadKey();
        }

        static void Feladat1()
        {
            StreamReader olv = new StreamReader("../../ip.txt");
            while (olv.Peek() > 0)
            {
                ipc[n] = olv.ReadLine();
                n++;
            }
        }

        static void Feladat2()
        {
            Console.WriteLine("2. feladat:");
            Console.WriteLine("Az állományban {0} darab adatsor van.", n);
            Console.WriteLine();
        }

        static void Feladat3()
        {
            Console.WriteLine("3. feladat:");
            string min = ipc[0];
            for (int i = 1; i < n; i++)
                if (String.Compare(min, ipc[i]) > 0)
                    min = ipc[i];
            Console.WriteLine("A legalacsonyabb tárolt IP cím:");
            Console.WriteLine(min);
            Console.WriteLine();
        }

        static void Feladat4()
        {
            Console.WriteLine("4. feladat:");
            int dok = 0;
            int glob = 0;
            int helyi = 0;
            for (int i = 0; i < n; i++)
            {
                if (ipc[i].Substring(0, 9) == "2001:0db8")
                    dok++;
                if (ipc[i].Substring(0, 7) == "2001:0e")
                    glob++;
                if (ipc[i].Substring(0, 2) == "fc" || ipc[i].Substring(0, 2) == "fd")
                    helyi++;
            }
            Console.WriteLine("Dokumentációs cím: {0} darab", dok);
            Console.WriteLine("Globális egyedi cím: {0} darab", glob);
            Console.WriteLine("Helyi egyedi cím: {0} darab", helyi);
            Console.WriteLine();
        }

        static void Feladat5()
        {
            StreamWriter iro = new StreamWriter("../../sok.txt");
            for (int i = 0; i < n; i++)
            {
                int db = 0;
                for (int j = 0; j < ipc[i].Length; j++)
                    if (ipc[i][j] == '0')
                        db++;
                if (db >= 18)
                    iro.WriteLine("{0} {1}", i + 1, ipc[i]);
            }
            iro.Close();
        }

        static void Feladat6()
        {
            Console.WriteLine("6. feladat:");
            string[] resz = new string[8];

            Console.Write("Kérek egy sorszámot: ");
            int sz = Convert.ToInt32(Console.ReadLine());
            //0-tól számozzuk:
            sz = sz - 1;

            hc = ipc[sz];
            resz = hc.Split(':');

            for (int i = 0; i < 8; i++)
            {
                //amíg van az elején '0', leszedi, ha 0-nál hosszabb
                while (resz[i][0] == '0' && resz[i].Length > 1)
                    resz[i] = resz[i].Substring(1, resz[i].Length - 1);

                /*Ugyanez a TrimStart függvénnyel:
                resz[i]=resz[i].TrimStart('0');
                if (resz[i] == "")
                    resz[i] = "0";*/

                rc = rc + resz[i];
                if (i < 7)
                    rc = rc + ":";
            }
            Console.WriteLine(hc);
            Console.WriteLine(rc);
            Console.WriteLine();
        }

        static void Feladat7()
        {
            Console.WriteLine("7. feladat:");
            string rrc = "";
            int[] db = new int[8];
            string[] resz = new string[8];
            resz = rc.Split(':');

            //Megszámoljuk a következő "0" sorozatok számát
            for (int i = 0; i < 8; i++)
                if (resz[i] == "0")
                {
                    int j = i;
                    while (resz[j] == "0")
                    {
                        db[i]++;
                        j++;
                    }
                }

            //Megkeressük az (első) leghosszabb kezdetét
            bool vane = false;
            int maxh = 0;
            for (int i = 0; i < 7; i++)
                if (db[maxh] < db[i])
                {
                    maxh = i;
                    vane = true;
                }

            if (vane == false)
                Console.WriteLine("Nem rövidíthető tovább!");
            else
            {
                for (int i = 0; i < maxh; i++)
                    rrc = rrc + resz[i] + ":";
                rrc = rrc + ":";
                for (int i = maxh + db[maxh]; i < 8; i++)
                {
                    rrc = rrc + resz[i];
                    if (i < 7)
                        rrc = rrc + ":";
                }
                Console.WriteLine(rrc);
            }
        }
    }
}
