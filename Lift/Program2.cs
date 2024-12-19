using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lift_lista
{
    class Program
    {
        private struct igény
        {
            public int óra, perc, másodperc, csapat, honnan, hová;
        }
        private static igény[] igények = new igény[100];
        private static int szintszám, csapatszám, igényszám;
        private static int indulószint;
        private static Random rnd = new Random();
        private static int véletlencsapat=3;

        static void nMain(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();
            Console.ReadLine();
        }

        static void Feladat1()
        {
            FileStream fájl = new FileStream("igeny.txt", FileMode.Open);
            StreamReader olvasó = new StreamReader(fájl);
            string[] egysor = new string[6];

            Console.WriteLine("1. Az adatok beolvasása");
            Console.WriteLine();
            szintszám = int.Parse(olvasó.ReadLine());
            csapatszám = int.Parse(olvasó.ReadLine());
            igényszám = int.Parse(olvasó.ReadLine());

            // Az i blokkváltozó lesz
            for (int i = 0; i < igényszám; i++)
            {
                egysor = olvasó.ReadLine().Split(' ');
                igények[i].óra = int.Parse(egysor[0]);
                igények[i].perc = int.Parse(egysor[1]);
                igények[i].másodperc = int.Parse(egysor[2]);
                igények[i].csapat = int.Parse(egysor[3]);
                igények[i].honnan = int.Parse(egysor[4]);
                igények[i].hová = int.Parse(egysor[5]);
              }
            fájl.Close();
        }
        static void Feladat2()
        {
            Console.Write("2. Adja meg, hogy kezdetben melyik szinten van a lift=");
            indulószint = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        static void Feladat3()
        {
        Console.WriteLine("3. A lift a " + igények[igényszám-1].hová + " szinten áll az utolsó igény teljesítése után.");
        Console.WriteLine();
        }

        static void Feladat4()
        {
            int alsó = indulószint;
            int felső = indulószint;
            int i;

            for (i = 0; i < igényszám; i++)
            {
                alsó = Math.Min(alsó, Math.Min(igények[i].honnan, igények[i].hová));
                felső = Math.Max(felső, Math.Max(igények[i].honnan, igények[i].hová));
            }
            //Kiíráskor sztringgé alakítjuk
            Console.WriteLine("4. Alsó szint = " + alsó.ToString() + " felső szint = " + felső.ToString());
            Console.WriteLine();
        }

        static void Feladat5()
        {
            int utassal = 0;
            int üresen = 0;
            int előzőszint = indulószint;
            
            // i blokkváltozó lesz
            for (int i = 0; i < igényszám; i++)
            {
                if (igények[i].honnan < igények[i].hová)
                {
                    //A változó inkrementálása
                    utassal++;
                }
                if (előzőszint < igények[i].honnan) üresen++;
                előzőszint = igények[i].hová;
            }
            //Megegyezik a VB-vel
            Console.WriteLine("5. Utassal= {0} üresen= {1}", utassal, üresen);
            Console.WriteLine();
        }

        static void Feladat6()
        {
            int[] darab = new int[csapatszám + 1];

            for (int i =0; i<igényszám; i++)
            {
                darab[igények[i].csapat]++;
            }

            Console.Write("6. Nem vette igénybe a liftet: ");
            for (int i = 1; i <= csapatszám; i++)
                if (darab[i] == 0)
                {
                    Console.Write(i.ToString() + " ");
                }
            Console.WriteLine();
            Console.WriteLine();
        }

       
      static void Feladat7()
      {
      int holvanéppen  = -1;         //Kezdetben nem tudjuk hol van
      bool csalte = false;

      véletlencsapat = rnd.Next(1, csapatszám);
      Console.WriteLine("7. Kiválasztott csapat=" + véletlencsapat);

      for (int i = 0; i<igényszám; i++)
      {
          if (igények[i].csapat == véletlencsapat)
          {
              if (holvanéppen == -1)
              {
                  holvanéppen = igények[i].hová;
              }
              else
              {
                  if (holvanéppen != igények[i].honnan)
                  {
                      Console.WriteLine("Csalás a(z) " + i + ". igénynél, lement " + holvanéppen + "->" + igények[i].honnan);
                      csalte = true;
                  }
              }
              holvanéppen = igények[i].hová;
          }
       }
          if (!csalte) Console.WriteLine("Nem állapítható meg csalás");
          Console.WriteLine();
      }

       static void Feladat8()
        { 
           FileStream fájl = new FileStream("../../blokkol.txt", FileMode.Create);
           StreamWriter író = new StreamWriter(fájl);

           Console.WriteLine("8. Az adatok kiírása");
           Console.WriteLine();
 
           for (int i=0; i< igényszám; i++)
            {
                if (igények[i].csapat == véletlencsapat)
                {
                    Console.WriteLine("Befejezés ideje: " + igények[i].óra + ":" + igények[i].perc + ":" + igények[i].másodperc);
                    író.WriteLine("Befejezés ideje: " + igények[i].óra + ":" + igények[i].perc + ":" + igények[i].másodperc);
                    Console.Write("Sikeresség=");
                    string sikeresség = Console.ReadLine();
                    író.WriteLine("Sikeresség: " + sikeresség);
                    Console.WriteLine("-----");
                    író.WriteLine("-----");
                    Console.WriteLine("Indulási emelelet: " + igények[i].honnan);
                    író.WriteLine("Indulási emelelet: " + igények[i].honnan);
                    Console.WriteLine("Célemelet: " + igények[i].hová);
                    író.WriteLine("Célemelet: " + igények[i].hová);
                    Console.Write("Feladatkód=");
                    int feladatkód = int.Parse(Console.ReadLine());
                    író.WriteLine("Feladatkód: " + feladatkód);
                }
            }
        író.Close();
        fájl.Close();

        Console.WriteLine();
        }
    }
}


      
    