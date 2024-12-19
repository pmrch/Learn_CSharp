using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Lift;

class Program
{
    static void Main(string[] args)
    {
        // 1. Feladat
        List<Lift> igenyek = new List<Lift>();
        int[] alapadatok = new int[3];
        int index = 0;

        foreach(var item in File.ReadAllLines("igeny.txt"))
        {
            if (item.Contains(" "))
            {
                igenyek.Add(new Lift(item));
            }
            else
            {
                alapadatok[index] = int.Parse(item);
            }
            index++;
        }

        // 2. Feladat
        int induloszint = 0;

        Console.Write("\n2. Adja meg a kezdő szint számát: ");
        induloszint = int.Parse(Console.ReadLine());
        while (induloszint > 101 || induloszint == 0)
        {
            Console.Write("\n2. Adja meg a kezdő szint számát: ");
            induloszint = int.Parse(Console.ReadLine());
        }

        // 3. Feladat
        var vegso_szint = igenyek.Last().end;
        Console.WriteLine("\n3. A lift a {0}. szinten áll az utolsó igény teljesítése után.", vegso_szint);

        // 4. Feladat
        int max = igenyek.Max(p => Math.Max(p.start, p.end));
        int min = igenyek.Min(p => Math.Min(p.start, p.end));

        Console.WriteLine("\n4. Feladat\nA legmagasabb szint: {0}\nA legalacsonyabb szint: {1}", max, min);

        // 5. Feladat
        

        // 6. Feladat
        List<int> ossz_csapatok = new List<int>();
        HashSet<int> hasznalt_csapatok = new HashSet<int>();

        foreach(var item in igenyek) hasznalt_csapatok.Add(item.sorszam);
        for (int i = 1; i <= alapadatok[1]; i++) ossz_csapatok.Add(i);
        var csapatok = ossz_csapatok.Where(p => !hasznalt_csapatok.Contains(p));
    
        Console.Write("\n6. A kovetkezo csapatok nem hasznaltak a liftet: ");
        foreach (var item in csapatok) Console.Write($"{item} ");
    }
}
