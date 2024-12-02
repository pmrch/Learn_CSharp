using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace IPv6;

class Program
{
    static void Main(string[] args)
    {
        // 1. Feladat: Beolvas
        List<IPv6Cimek> cimek = new List<IPv6Cimek>();
        List<string> seged = new List<string>();
        
        foreach (var item in File.ReadAllLines("ip.txt"))
        {
            cimek.Add(new IPv6Cimek(item));
            seged.Add(item);
        }

        // 2. Feladat
        Console.WriteLine($"2. Feladat: \nAz állományban {cimek.Count()} darab adatsor van.");

        // 3. Feladat
        Console.WriteLine("\nA legalacsonyabb tárolt IP-cím: \n{0}", seged.Min());

        // 4. Feladat
        int[] tipusok = new int[3];
        Regex dok_tip = new Regex(@"^2001:0db8:");
        Regex glob_tip = new Regex(@"^2001:0e[0-9a-fA-F]{2}");

        foreach (var item in seged)
        {
            if (dok_tip.IsMatch(item)) tipusok[0]++;
            else if (glob_tip.IsMatch(item)) tipusok[1]++;
            else tipusok[2]++;
        }

        Console.WriteLine($"\n4. Feladat:\nDokumentációs cím: {tipusok[0]} darab\nGlobális egyedi cím: {tipusok[1]} darab\nHelyi egyedi cím: {tipusok[2]} darab");

        // 5. Feladat
        Console.WriteLine("\n5. Feladat:");
        using (StreamWriter writer = new StreamWriter("sok.txt"))
        {
            int sorszam = 0;
            foreach (var item in seged)
            {
                sorszam++;
                int nulla = 0;
                foreach (char k in item)
                {
                    if (k == '0')
                    {
                        nulla++;
                        if (nulla >= 18)
                        {
                            nulla = 0;
                            writer.WriteLine($"{sorszam} {item}");
                        }
                    }
                }
            }
        }

        // 6. Feladat
        Console.WriteLine("\n6. Feladat");
        int sz = int.Parse(Console.ReadLine());
        string tetel = seged[sz];
        List<string> rovid = new List<string>();

        for (int i = 0; i < tetel.Length; i++)
        {
            int n = 0;
            while (tetel[i] != ':')
            {
                n++;
                if (n == 4)
                {
                    rovid[i] = 0;
                }
            }
        }
    }
}
