using System.Runtime.InteropServices.ComTypes;

namespace Autok_Mozgasa;

class Program
{
    static void Main(string[] args)
    {
        List<Jeladas> jeladasok = new List<Jeladas>();

        try {
            foreach (var item in File.ReadAllLines("jeladas.txt")) {
                string[] oneline = item.Split('\t');
                jeladasok.Add(new Jeladas(oneline[0], int.Parse(oneline[1]), 
                int.Parse(oneline[2]), int.Parse(oneline[3])));
            }
        } catch (Exception ex) {
            Console.WriteLine($"Error filling the list: {ex}");
        }

        // 2. Feladat
        Console.WriteLine("2. Feladat");

        var legutobbi = jeladasok.Last();
        Console.WriteLine($"Az utolsó jeladás időpontja {legutobbi.ora}:{legutobbi.perc}, " +
        $"a jármű rendszáma {legutobbi.rendszam}");

        // 3. Feladat
        Console.WriteLine("\n3. Feladat");

        string elso_rendszam = jeladasok[0].rendszam;
        Console.WriteLine($"Az első jármű: {elso_rendszam}");

        var tmp_adasok = jeladasok.Where(p => p.rendszam == elso_rendszam).ToList();
        Console.Write("Jeladásainak időpontjai: ");
        foreach (var item in tmp_adasok) Console.Write($"{item.ora}:{item.perc} ");

        //4. Feladat
        Console.WriteLine("\n\n4. Feladat");

        Console.Write("Kérem adjon meg egy óra értéket (0-24): ");
        int tmp_ora = int.Parse(Console.ReadLine());
        Console.Write("Kérem adjon meg egy perc értéket (0-59): ");
        int tmp_perc = int.Parse(Console.ReadLine());
        
        int tmp = 0;
        foreach (var item in jeladasok) {
            if (item.ora == tmp_ora && item.perc == tmp_perc) {
                tmp++;
            }
        }
        if (tmp == 0) Console.WriteLine("Nem volt jeladás ebben az időpontban");
        else Console.WriteLine($"Jeladások száma: {tmp}");

        // 5. Feladat
        Console.WriteLine("\n5. Feladat");

        int max_speed = jeladasok.Max(p => p.sebesseg);
        Console.WriteLine($"{max_speed} km/h volt a legnagyobb sebesség");

        Console.Write("A járművek: ");
        var leggyorsabb_kocsik = jeladasok.Where(P => P.sebesseg == max_speed).ToList();
        foreach (var item in leggyorsabb_kocsik) Console.Write($"{item.rendszam} ");

        // 6. Feladat
        Console.WriteLine("\n\n6.Feladat");

        Console.Write("Kérem, adjon meg egy rendszámot: ");
        string tmp_rendszam = Console.ReadLine();

        var tmp_kocsik = jeladasok.Where(p => p.rendszam == tmp_rendszam).ToList();
        double tav = 0.0f;
        float kul = 0.0f;
        float ido2 = 0.0f;
        
        for (int i = 0; i < tmp_kocsik.Count() - 1 ; i++) {
            string new_perc = "";
            if (tmp_kocsik[i].perc < 10) new_perc = $"0{tmp_kocsik[i].perc}"; else new_perc = $"{tmp_kocsik[i].perc}";
            Console.WriteLine($"{tmp_kocsik[i].ora}:{new_perc} {tav} km");
            
            float ido = tmp_kocsik[i].ora + tmp_kocsik[i].perc / 60.0f;
            ido2 = tmp_kocsik[i + 1].ora + tmp_kocsik[i + 1].perc / 60.0f;
            
            kul = ido2 - ido;
            tav += kul * tmp_kocsik[i].sebesseg;
            tav = Math.Round(tav, 1);
        }
        kul = 0;
        
        var utolso = tmp_kocsik[tmp_kocsik.Count() - 1];
        kul = utolso.ora + utolso.perc / 60.0f - ido2;
        tav += kul * utolso.sebesseg;

        Console.WriteLine($"{utolso.ora}:{utolso.perc} {tav} km");

        // 7. Feladat
        Console.WriteLine("\n7.Feladat");

        
    }
}
