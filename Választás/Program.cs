using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.IO;
using System.Transactions;

namespace Valasztas
{
    class Program
    {
        struct EgyKepviselo
        {
            public string vnev, knev, korzet, part;
            public int szavazat;
        }
        static void Main(string[] args)
        {
            List<EgyKepviselo> kepviselok = new List<EgyKepviselo>();
            using (StreamReader reader = new StreamReader("szavazatok.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] egy_sor = reader.ReadLine().Split(' ');
                    EgyKepviselo seged = new EgyKepviselo();
                    
                    seged.korzet = egy_sor[0]; seged.szavazat = int.Parse(egy_sor[1]);
                    seged.vnev = egy_sor[2]; seged.knev = egy_sor[3]; seged.part = egy_sor[4]; 
                    
                    kepviselok.Add(seged);
                }
            }
            foreach (var item in kepviselok)
            {
                Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\n", 
                item.korzet, item.szavazat, item.vnev, item.knev, item.part);
            }
            Console.WriteLine("\n2. Feladat\nA helyhatósági választáson {0} képviselőjelölt indult.\n", kepviselok.Count());
            Console.WriteLine("3. Feladat");

            string elonev = Console.ReadLine();
            string utonev = Console.ReadLine();
            int szav = 0;
            bool talalat = false;

            foreach (var item in kepviselok)
            {
                if (item.vnev == elonev && item.knev == utonev)
                {
                    szav = item.szavazat;
                    talalat = true;
                }
            }
            
            if (szav > 0 && talalat == true)
            {
                Console.WriteLine($"{elonev} {utonev} {szav} szavazatot kapott.");
            }
            else
            {
                Console.WriteLine("Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban.");
            }
            Console.WriteLine("\n4. Feladat");

            float osszeg = 0;
            float szazalek;
            const int ossz_polgar = 12345;

            foreach (var item in kepviselok)
            {
                osszeg += item.szavazat;
            }
            szazalek = (osszeg / ossz_polgar) * 100;
            Console.WriteLine($"A választáson {osszeg} állampolgár, a jogosultak {Math.Round(szazalek, 2)}%-a vett részt.\n\n5. Feladat");
            
            // 5. Feladat
            int gyep = 0;
            int hep = 0;
            int tisz = 0;
            int zep = 0;
            int fugg = 0;

            foreach (var item in kepviselok)
            {
                if (item.part == "GYEP")
                {
                    gyep += item.szavazat;
                }
                else if (item.part == "HEP")
                {
                    hep += item.szavazat;
                }
                else if (item.part == "TISZ")
                {
                    tisz += item.szavazat;
                }
                else if (item.part == "ZEP")
                {
                    zep += item.szavazat;
                }
                else
                {
                    fugg += item.szavazat;
                }
            }
            Console.WriteLine($"Gyümölcsevők pártja= {Math.Round((float)gyep / osszeg * 100, 2)}%");
            Console.WriteLine($"Húsevők pártja= {Math.Round((float)hep / osszeg * 100, 2)}%");
            Console.WriteLine($"Tejivók szövetsége= {Math.Round((float)tisz / osszeg * 100, 2)}%");
            Console.WriteLine($"Zöldségevők pártja= {Math.Round((float)zep / osszeg * 100, 2)}%");
            Console.WriteLine($"Független jelöltek= {Math.Round((float)fugg / osszeg * 100, 2)}%\n");

            // 6. Feladat
            Console.WriteLine("6. Feladat");
            List<int> szavazatok_szama = new List<int>();

            foreach (var item in kepviselok)
            {
                szavazatok_szama.Add(item.szavazat);
            }

            int legtobb_szavazat = szavazatok_szama.Max();
            Console.WriteLine(legtobb_szavazat);

            for (int i = 0; i < kepviselok.Count(); i++)
            {
                if (kepviselok[i].szavazat == legtobb_szavazat)
                {
                    Console.WriteLine($"{kepviselok[i].vnev} {kepviselok[i].knev} {kepviselok[i].part}");
                }
            }

            // 7. Feladat
            Console.WriteLine("\n7. Feladat");
            int[] indexek = new int[5];

            int maxGyep = 0, maxHep = 0, maxTisz = 0, maxZep = 0, maxFugg = 0;

            for (int i = 0; i < kepviselok.Count(); i++)
            {
                if (kepviselok[i].part == "GYEP")
                {
                    if (kepviselok[i].szavazat > maxGyep)
                    {
                        maxGyep = kepviselok[i].szavazat;
                        indexek[0] = i;
                    }
                }
                else if (kepviselok[i].part == "HEP")
                {
                    if (kepviselok[i].szavazat > maxHep)
                    {
                        maxHep = kepviselok[i].szavazat;
                        indexek[1] = i;
                    }
                }
                else if (kepviselok[i].part == "TISZ")
                {
                    if (kepviselok[i].szavazat > maxTisz)
                    {
                        maxTisz = kepviselok[i].szavazat;
                        indexek[2] = i; 
                    }
                }
                else if (kepviselok[i].part == "ZEP")
                {
                    if (kepviselok[i].szavazat > maxZep)
                    {
                        maxZep = kepviselok[i].szavazat;
                        indexek[3] = i;
                    }
                }
                else
                {
                    if (kepviselok[i].szavazat > maxFugg)
                    {
                        maxFugg = kepviselok[i].szavazat;
                        indexek[4] = i;
                    }
                }
            }
            
            if (indexek[0] != -1) Console.WriteLine($"1 {kepviselok[indexek[0]].vnev} {kepviselok[indexek[0]].knev} {kepviselok[indexek[0]].part}");
            if (indexek[1] != -1) Console.WriteLine($"2 {kepviselok[indexek[1]].vnev} {kepviselok[indexek[1]].knev} {kepviselok[indexek[1]].part}");
            if (indexek[2] != -1) Console.WriteLine($"3 {kepviselok[indexek[2]].vnev} {kepviselok[indexek[2]].knev} {kepviselok[indexek[2]].part}");
            if (indexek[3] != -1) Console.WriteLine($"4 {kepviselok[indexek[3]].vnev} {kepviselok[indexek[3]].knev} {kepviselok[indexek[3]].part}");
            if (indexek[4] != -1) Console.WriteLine($"5 {kepviselok[indexek[4]].vnev} {kepviselok[indexek[4]].knev} fuggetlen");
            
        }
    }
}