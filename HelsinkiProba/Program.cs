﻿using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.WebSockets;

namespace Helsinki
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Helyezes> pontszerzok = new List<Helyezes>();
            
            foreach (var item in File.ReadAllLines("helsinki.txt"))
            {
                pontszerzok.Add(new Helyezes(item));
            }
            Console.WriteLine($"3. Feladat:\n Pontszerző helyezések száma {pontszerzok.Count()}");
            
            // 4. Feladat
            int arany = 0, ezust = 0, bronz = 0, osszes = 0;
            foreach (var item in pontszerzok)
            {
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
            }
            Console.WriteLine("4. feladat");
            Console.WriteLine("Arany: {0}\nEzüst: {1}\nBronz: {2}\nÖsszesen: {3}\n", arany, ezust, bronz, osszes);
            
            // 5. Feladat
            Console.WriteLine("5. feladat");
            int pontszamok = 0;
            int[] lehetseges_pontszamok = { 7, 5, 4, 3, 2, 1 };
            
            foreach (var item in pontszerzok)
            {
                pontszamok += lehetseges_pontszamok[item.helyezes - 1];
            }

            Console.WriteLine("Olimpiai pontok száma: {0}\n", pontszamok);
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
                Console.WriteLine("Úszás sportágban szereztek több érmet");
            else if (uszas_ermek == torna_ermek)
                Console.WriteLine("Torna és úszás sportágban ugyanannyi érmet szereztek");
            else
                Console.WriteLine("Torna sportágban szereztek több érmet\n");
            
            // 7. Feladat
            List<string> masolat = new List<string>();
            foreach (var item in pontszerzok)
            {
                string fix = item.sportag;
                if (fix == "kajakkenu")
                {
                    fix = "kajak-kenu";
                    masolat.Add($"{item.helyezes} {item.sportag}, {lehetseges_pontszamok[item.helyezes] - 1} {fix}, {item.versenyszam}");
                }
            }
            File.WriteAllLines("helsinki2.txt", masolat);  
            
            // 8. Feladat
            Console.WriteLine("8. feladat");
            
            int legnagyobb_csapat = 0;
            List<Helyezes> segito = new List<Helyezes>();
            Helyezes[] segito2 = new Helyezes[segito.Count()];

            foreach (var item in File.ReadAllLines("helsinki2.txt"))
            {
                segito.Add(new Helyezes(item));
            }
            int hm = 0;
            foreach (var item in segito)
            {
                if (legnagyobb_csapat < item.sportolok)
                {
                    legnagyobb_csapat = item.sportolok;
                    segito2[hm].helyezes = item.helyezes; segito2[hm].sportolok = item.sportolok;
                    segito2[hm].sportag = item.sportag; segito2[hm].versenyszam = item.versenyszam;
                }
                hm++;
            }
            Console.WriteLine("Helyezés: {0}\nSportág: {1}\nVersenyszám: {2}\nSportolók Száma: {3}",
            segito2.helyezes, segito2.sportag, segito2.versenyszam, segito2.sportolok);
        }
    }
}