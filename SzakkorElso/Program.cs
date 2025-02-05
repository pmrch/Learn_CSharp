using System.Text.RegularExpressions;

namespace SzakkorElso;

class Program
{
    static void Main(string[] args)
    {
        Bolygo b = new Bolygo("Mars", 989898, 3);
        List<Bolygo> bolygok = new List<Bolygo>();
        
        try
        { 
            foreach (var item in File.ReadAllLines("data.txt"))
            {
                string oneLine = item;
                string[] parts = oneLine.Split(';');

                bolygok.Add(new Bolygo(parts[0], int.Parse(parts[1]), int.Parse(parts[2])));
            }
        } catch (Exception e) {
            Console.WriteLine("Failed to open the file with following error:\n{0}", e.Message);
        }

        var bolygok500_1000 = bolygok.Where(p => p.iTomeg > 700 && p.iTomeg < 1100);
        foreach (var item in bolygok500_1000) Console.WriteLine(item.sNev);

        var bolygok_hosszuNev = bolygok.Where(p => p.sNev.Length == bolygok.Max(b => b.sNev.Length));
        foreach (var item in bolygok_hosszuNev) Console.WriteLine(item.sNev);
    }
}
