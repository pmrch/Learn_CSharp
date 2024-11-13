using System.Runtime.CompilerServices;

namespace Helsinki
{
    class Program
    {
        struct HelsinkiSorok
        {
            public int helyezes, sportolok;
            public string sportag, versenyszam;
        }
        static void Main(string[] args)
        {
            List<HelsinkiSorok> pontszerzok = new List<HelsinkiSorok>();
            
            using (StreamReader reader = new StreamReader("helsinki.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] egy_sor = reader.ReadLine().Split(' ');;
                    
                    HelsinkiSorok seged = new HelsinkiSorok();
                    seged.helyezes = int.Parse(egy_sor[0]);
                    seged.sportolok = int.Parse(egy_sor [1]);
                    seged.sportag = egy_sor[2];
                    seged.versenyszam = egy_sor[3];

                    pontszerzok.Add(seged);
                }
            }

            foreach (var item in pontszerzok)
            { 
                Console.WriteLine("{0}\t{1}", item.helyezes, item.sportolok);
            }

            Console.WriteLine();
            Console.WriteLine("A pontszerző helyezések száma: {0}", pontszerzok.Count());
        }
    }
}