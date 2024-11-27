using System.IO.IsolatedStorage;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Kozuti_Ellenorzes;

class Program
{
    static void Main(string[] args)
    {
        // 1. Feladat
        List<Jarmuvek> jarmuveks = new List<Jarmuvek>();
        foreach (var item in File.ReadAllLines("jarmu.txt"))
        {
            jarmuveks.Add(new Jarmuvek(item));
        }

        // 2. Feladat
        Console.WriteLine("2. Feladat:");
        int dolgozott_orak = jarmuveks[jarmuveks.Count() - 1].ora - jarmuveks[0].ora + 1;
        Console.WriteLine("Az ellenorzest vegzok legalabb {0} orat dolgoztak", dolgozott_orak);

        // 3. Feladat
        Console.WriteLine("\n3. Feladat: Műszakilag ellenőrzött járművek:");
        HashSet<int> orak = new HashSet<int>();
        List<int> indexek = new List<int>();

        for (int i = 0; i < jarmuveks.Count(); i++)
        {
            if (!orak.Contains(jarmuveks[i].ora))
                indexek.Add(i);
            orak.Add(jarmuveks[i].ora);
        }
        
        for (int i = 0; i < indexek.Count(); i++)
        {
            Console.WriteLine($"   {orak.ToArray()[i]} óra: {jarmuveks[indexek[i]].rendszam}");
        }

        // 4. Feladat
        Console.WriteLine("\n4. Feladat: Statisztika: ");
        int[] jarmutipus = new int[4];

        foreach (var item in jarmuveks)
        {
            if (item.rendszam[0] == 'B') jarmutipus[0]++;
            else if (item.rendszam[0] == 'K') jarmutipus[1]++;
            else if (item.rendszam[0] == 'M') jarmutipus[2]++;
            else jarmutipus[3]++;
        }

        Console.WriteLine(
            $"\tKategória: Kamion - {jarmutipus[1]} db \n\tKategória: Busz - {jarmutipus[0]} db\n\tKategória: Motor - {jarmutipus[2]} db \n\tKategória: Személygépkocsi - {jarmutipus[3]} db"
        );

        // 5. Feladat
        Console.WriteLine("\n5. Feladat: Leghosszabb forgalommentes időszak(ok): ");

        static int ToSeconds(int o, int p, int mp)
        {
            return (o * 3600) + (p * 60) + mp;
        }
        
        int max_delta = 0;
        int kezd_ido = 0;

        for (int i = 1; i < jarmuveks.Count(); i++)
        {
            int ido1 = ToSeconds(jarmuveks[i - 1].ora, jarmuveks[i - 1].perc, jarmuveks[i - 1].mp);
            int ido2 = ToSeconds(jarmuveks[i].ora, jarmuveks[i].perc, jarmuveks[i].mp);

            int delta = ido2 - ido1;

            if (delta > max_delta)
            {
                max_delta = delta;
                kezd_ido = ido1;
            }
        }
        Console.WriteLine($"{TimeSpan.FromSeconds(kezd_ido)} - {TimeSpan.FromSeconds(kezd_ido + max_delta)}");

        // 6. Feladat: Kérem a keresendő rendszámot: 
        string rsz = Console.ReadLine();
        // Replace '*' with '.*' to allow it to match any character (letters and digits)
        string regex_pattern = rsz.Replace("*", ".*");

        Regex pattern = new Regex($"^{regex_pattern}$");
        List<string> talalatok = new List<string>();
        List<string> rendszamok = new List<string>();

        foreach (var item in jarmuveks)
        {
            rendszamok.Add(item.rendszam);
        }
        rendszamok.Sort();

        foreach (var item in rendszamok)
        {
            if (pattern.IsMatch(item))
            {
                talalatok.Add(item);
            }
        }

        foreach (var item in talalatok)
        {
            Console.WriteLine(item);
        }
        
    }
}
