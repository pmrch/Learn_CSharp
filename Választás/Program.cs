using System.IO;

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
                Console.Write("{0}\t{1}\t{2}\t{3}\t{4}", 
                item.korzet, item.szavazat, item.vnev, item.knev, item.part);
                Console.WriteLine();
            }
        }
    }
}