namespace Cegauto_FP;

class Program
{
    static void Main(string[] args)
    {
        // 1. Feladat
        List<Autok> autoks = new List<Autok>();
        foreach (var item in File.ReadAllLines("autok.txt")) autoks.Add(new Autok(item));
        
        // 2. Feladat
        Console.WriteLine($"2. Feladat\n{autoks[autoks.Count() - 1].nap}. nap rendszám: {autoks[autoks.Count() - 1].rendszam}");

        // 3. Feladat
        Console.Write("\nNap: ");
        int bekert_nap = int.Parse(Console.ReadLine());
        var bekert_nap_autoi = autoks.Where(p => p.nap == bekert_nap);
        
        foreach (var item in bekert_nap_autoi) Console.WriteLine($"{item.ora_perc} {item.rendszam} {item.km_ora} {item.ki_be}");

        // 4. Feladat
        int autok_parkoloban = 0;
        foreach (var item in autoks)
        {
            
        }
    }
}