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
        Console.Write("\n2. Adja meg a kezdő szint számát: ");
        int induloszint = int.Parse(Console.ReadLine());

        // 3. Feladat
        var vegso_szint = igenyek.Last().end;
        Console.WriteLine("\n3. A lift a {0}. szinten áll az utolsó igény teljesítése után.", vegso_szint);

        // 4. Feladat
        int max = igenyek.Max(p => Math.Max(p.start, p.end));
        int min = igenyek.Min(p => Math.Min(p.start, p.end));

        Console.WriteLine("\n4. Feladat\nA legmagasabb szint: {0}\nA legalacsonyabb szint: {1}", max, min);

        // 5. Feladat
        var count = igenyek.Where(p => p.start < p.end).Count();
        var count2 = igenyek.Where(p => p.end < p.start).Count();
        Console.WriteLine($"\nUtassal: {count}  Utas nélkül: {count2}");

        // 6. Feladat
        HashSet<int> csapatok = new HashSet<int>();
        foreach(var item in igenyek) csapatok.Add(item.sorszam);
        
        string nem_vette_igenybe = "";
        foreach(var item in nem_vette_igenybe)

        Console.WriteLine("\nNem vette igénybe a liftet: {0}", nem_vette_igenybe);
    }
}
