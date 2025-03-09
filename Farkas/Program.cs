using System.Formats.Asn1;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace MyApp {
    internal class Program {
        static void Main(string[] args) {
            // 1. Feladat
            List<Veetel> vetelek = [];

            using (StreamReader sr = new("veetel.txt")) {
                while (!sr.EndOfStream) {
                    string? line1 = sr.ReadLine();
                    string? line2 = sr.ReadLine();

                    if (line1 != null && line2 != null) vetelek.Add(new Veetel(line1, line2));
                }
            }

            // 2. Feladat
            Console.WriteLine("2. Feladat");
            Console.WriteLine($"Az első üzenet rögzítője: {vetelek[0].iAmator}");
            Console.WriteLine($"Az utolsó üzenet rögzítője: {vetelek[vetelek.Count() - 1].iAmator}");

            // 3. Feladat
            Console.WriteLine("\n3. Feladat");

            var farkasok = vetelek.Where(p => p.sFeljegyes.Contains("farkas"));
            foreach (var item in farkasok) Console.WriteLine($"{item.iNap}. nap: {item.iAmator}. rádióamatőr");

            // 4. Feladat
            Console.WriteLine("\n4. Feladat");

            Dictionary<int, int> stats = new Dictionary<int, int>();
            for (int i = 1; i <= 11; i++) {
                int numOfAm = vetelek.Where(p => p.iNap == i).Count();
                stats.Add(i, numOfAm);
            }
            foreach (var item in stats) Console.WriteLine($"{item.Key}. nap: {item.Value} rádióamatőr");
            
            // 5. Feladat
            Console.WriteLine("\n5. Feladat");

            using (StreamWriter sw = new StreamWriter("adaas.txt")) {
                List<Veetel> rendezett = new List<Veetel>();
                foreach (var item in vetelek.OrderBy(p => p.iNap).ToList()) rendezett.Add(item);

                for (int i = 0; i < rendezett.Count(); ++i) {
                    
                }

                string? worker = "";
                    
            }
        }

        public bool isTheSame(Veetel v1, Veetel v2) {
            bool value = true;

            
            
            return value;
        }

        public bool Szame(string szo) {
            bool valasz = true;

            for (ushort i = 0; i < szo.Length; i++) {
                if (szo[i] < '0' || szo[i] > '9') {
                    valasz = false;
                }
            }

            return valasz;
        }
    }
}
