using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Erettsegi25_IPv6
{
    class IPcím
    {
        public string[] Tagok { get; set; } // címcsopor tagok (8x4 jegy)
        public int Ssz { get; set; } // sorszám
        private static int sorszám_segéd = 0;

        public IPcím(string[] m)
        {
            Tagok = new string[8];
            for (int i = 0; i < m.Length; i++) Tagok[i] = m[i];
            Ssz = ++sorszám_segéd;
        }

        public string EredetiCím { get { return String.Join(":", Tagok); } }

        public int NullákSzáma { get { return EredetiCím.Count(x => x == '0'); } }

        public string VezetőNullákNélkül { get { return String.Join(":", Tagok.Select(x => x.Substring(0, 3).TrimStart('0') + x[3])); } }

        public string NagyonRövid
        {
            get
            {
                string mitKeres = ":0:0:0:0:0:0:0";
                while (mitKeres.Length > 2)
                {
                    int index = VezetőNullákNélkül.IndexOf(mitKeres);
                    if (index > 0) return VezetőNullákNélkül.Substring(0, index + 1) + VezetőNullákNélkül.Substring(index + mitKeres.Length);
                    else mitKeres = mitKeres.Substring(0, mitKeres.Length - 2);
                }
                return "Nem rövidíthető tovább.";
            }
        }

        public string Fajta
        {
            get
            {
                if (Tagok[0].Equals("2001") && Tagok[1].Equals("0db8")) return "Dokumentációs";
                if (Tagok[0].Equals("2001") && Tagok[1].StartsWith("0e")) return "Globális";
                if (Tagok[0].StartsWith("fc") || Tagok[0].StartsWith("fd")) return "Helyi";
                return "Ismeretlen";
            }
        }
    }

    class Cimek
    {
        static void Main()
        {
            Console.WriteLine("1. Feladat: ip.txt állomány beolvasása");
            List<IPcím> ipCímek = new List<IPcím>();
            foreach (var i in File.ReadAllLines("ip.txt")) ipCímek.Add(new IPcím(i.Split(':')));

            Console.WriteLine("2. Feladat:\n\tAz állományban {0} darab adatsor van.", ipCímek.Count);

            Console.WriteLine("3. Feladat:\n\tA legalacsonyabb tárolt IP cím:\n\t{0}", ipCímek.OrderBy(x => x.EredetiCím).First().EredetiCím);

            Console.WriteLine("4. Feladat:");
            foreach (var i in ipCímek.GroupBy(g => g.Fajta)) Console.WriteLine("\t{0} cím: {1} darab", i.Key, i.Count());

            Console.WriteLine("5. Feladat: sok.txt");
            List<string> ki = new List<string>();
            foreach (var i in ipCímek.Where(x => x.NullákSzáma >= 18)) ki.Add(String.Format("{0} {1}", i.Ssz, i.EredetiCím));
            File.WriteAllLines("sok.txt", ki);

            Console.Write("6. Feladat:\n\tKérek egy sorszámot: ");
            int sorszám = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("\t{0}\n\t{1}", ipCímek[sorszám].EredetiCím, ipCímek[sorszám].VezetőNullákNélkül);

            Console.Write("7. Feladat:\n\t{0}", ipCímek[sorszám].NagyonRövid);

            Console.ReadKey();
        }
    }
}
