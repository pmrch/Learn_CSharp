using System;
using System.IO;
using System.Collections.Generic;
namespace lud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. feladat - adatok beolvasása
            StreamReader sr = new StreamReader("dobasok.txt");
            string[] line = sr.ReadLine().Split(' ');
            sr.Close();
            int[] dob = new int[line.Length];
            for (int i = 0; i < line.Length; i++)
                dob[i] = int.Parse(line[i]);

            List<string> osvenyek = new List<string>();
            sr = new StreamReader("osvenyek.txt");
            while (!sr.EndOfStream)
                osvenyek.Add(sr.ReadLine() + "");
            sr.Close();
            #endregion

            Console.WriteLine("2. feladat");
            Console.WriteLine("A dobások száma: " + dob.Length);
            Console.WriteLine("Az ösvények száma: " + osvenyek.Count);

            Console.WriteLine("3. feladat");
            int maxi = LeghosszabbOsveny(osvenyek);
            Console.WriteLine($"Az egyik leghosszabb a(z) {maxi + 1}. ösvény, hossza: {osvenyek[maxi].Length}");

            Console.WriteLine("4. feladat");
            Console.Write("Adja meg egy ösvény sorszámát! ");
            int ut = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Adja meg a játokosok számát! ");
            int jdb = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("5. feladat");
            int mdb, vdb, edb;
            (mdb, vdb, edb) = Szamlal(osvenyek[ut]);
            if (mdb > 0) Console.WriteLine($"M: {mdb} darab");
            if (vdb > 0) Console.WriteLine($"V: {vdb} darab");
            if (edb > 0) Console.WriteLine($"E: {edb} darab");
            string utvonal = " " + osvenyek[ut];

            /* 6. feladat - fájlba írás*/
            Kulonleges(utvonal);

            Console.WriteLine("7. feladat");
            Alapjatek(utvonal, dob, jdb);

            Console.WriteLine("8. feladat");
            Jatek(utvonal, dob, jdb);
        }
        private static int LeghosszabbOsveny(List<string> osvenyek)
        {
            int maxi = 0;
            for (int i = 1; i < osvenyek.Count; i++)
                if (osvenyek[i].Length > osvenyek[maxi].Length)
                    maxi = i;
            return maxi;
        }
        private static (int, int, int) Szamlal(string utvonal)
        {
            int m = 0, v = 0, e = 0;
            foreach (char c in utvonal)
                if (c == 'M') m++;
                else if (c == 'E') e++;
                else if (c == 'V') v++;
            return (m, v, e);
        }
        private static void Kulonleges(string utvonal)
        {
            StreamWriter sw = new StreamWriter("kulonleges.txt");
            for (int i = 0; i < utvonal.Length; i++)
                if (utvonal[i] != 'M')
                    sw.WriteLine($"{i}\t{utvonal[i]}");
            sw.Close();
        }
        private static void Alapjatek(string utvonal, int[] dob, int jdb)
        {
            int[] jpoz = new int[jdb];
            for (int i = 0; i < jdb; i++)
                jpoz[i] = 0;
            bool vege = false;
            int kor = 0;
            while (!vege && kor <= dob.Length/jdb)
            {
                for (int i = 0;i < jdb; i++)
                {
                    jpoz[i] += dob[kor * jdb + i];
                    if (jpoz[i] >= utvonal.Length)
                        vege = true;
                }
                kor++;
            }
            Console.Write($"A játék a(z) {kor}. körben fejeződött be. A legtávolabb jutó(k) sorszáma:");
            for (int i = 0; i < jdb ; i++)
                if (jpoz[i] >= utvonal.Length)
                    Console.Write(" " + (i + 1));
            Console.WriteLine();
        }
        private static void Jatek(string utvonal, int[] dob, int jdb)
        {
            int[] jpoz = new int[jdb];
            for (int i = 0; i < jdb; i++)
                jpoz[i] = 0;
            bool vege = false;
            int kor = 0;
            while (!vege && kor <= dob.Length / jdb)
            {
                for (int i = 0; i < jdb; i++)
                {
                    jpoz[i] += dob[kor * jdb + i];
                    if (jpoz[i] < utvonal.Length && utvonal[jpoz[i]]=='E')
                        jpoz[i] += dob[kor * jdb + i];
                    else if(jpoz[i] < utvonal.Length && utvonal[jpoz[i]] == 'V')
                        jpoz[i] -= dob[kor * jdb + i];
                    if (jpoz[i] >= utvonal.Length)
                        vege = true;
                }
                kor++;
            }
            string tobbi = "A többiek pozíciója:";
            Console.Write($"Nyertes(ek):");
            for (int i = 0; i < jdb; i++)
                if (jpoz[i] >= utvonal.Length)
                    Console.Write(" " + (i + 1));
                else tobbi += $"\n{i + 1}. játékos, {jpoz[i]}. mező";
            Console.WriteLine();
            Console.WriteLine(tobbi);
        }
    }
}
