using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace Erettsegi24_KozutiEllenorzes
{
    class jármű
    {
        private static DateTime? előző_segéd { get; set; }
        public DateTime idő { get; set; }
        public DateTime eidő { get; set; }
        public TimeSpan deltaIdő { get { return idő - eidő; } }
        public string rsz { get; set; }

        public jármű(string[] s)
        {
            idő=DateTime.Parse(string.Format("{0}:{1}:{2}",s[0],s[1],s[2]));
            rsz = s[3];
            eidő = előző_segéd == null ? idő : (DateTime)előző_segéd;
            előző_segéd = idő;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", eidő.ToString("H:m:s"), idő.ToString("H:m:s"));
        }
    }

    class jaror
    {
        static void Main()
        {
            List<jármű> járművek = new List<jármű>(File.ReadAllLines("jarmu.txt").ToList().ConvertAll(x=>new jármű(x.Split())));

            Console.WriteLine("2. feladat: A munkaidő hossza: {0} óra", járművek.Max(x => x.idő).Hour - járművek.Min(x => x.idő).Hour + 1);

            Console.WriteLine("3. feladat: Műszakilag ellenőrzött járművek:");
            járművek.GroupBy(x => x.idő.Hour).Select(x => new { Óra = x.Key, Rendszám = x.OrderBy(y => y.idő).First().rsz }).ToList().ForEach(x => { Console.WriteLine("{0,5} óra: {1}", x.Óra, x.Rendszám); });

            Console.WriteLine("4. feladat: Statisztika:");
            var BKM = járművek.Where(x=>"BKM".Contains(x.rsz[0])).GroupBy(x => x.rsz[0]).Select(x => new { kat = x.Key=='B' ? "Busz": x.Key=='K' ? "Kamion" : "Motor" , db = x.Count()});
            int szgk = járművek.Count;
            foreach (var i in BKM) {Console.WriteLine("\tKategória: {0} - {1} db", i.kat,i.db); szgk-=i.db; }
            Console.WriteLine("\tKategória: Személygépkocsi - {0} db", szgk);

            Console.WriteLine("5. feladat: Leghosszabb forgalommentes időszak(ok):");
            //Nem derül ki a feladatból, hogy mi a teendő kettő vagy több azonos forgalommentes időszak esetén, így listázzuk ki az azonosakat is:
            járművek.Where(x => x.deltaIdő == járművek.OrderBy(y => y.deltaIdő).Last().deltaIdő).ToList().ForEach(x => { Console.WriteLine("\t{0} - {1}", x.eidő.ToString("H:m:s"), x.idő.ToString("H:m:s")); });


            Console.Write("6. feladat: Kérem a keresendő rendszámot: ");
            //Ha a csillag egy darab tetszőleges karaktert helyettesít:
            //string keres = Console.ReadLine();
            //járművek.Where(x => Regex.IsMatch(x.rsz, keres.Replace("*", "."))).ToList().ForEach(x => { Console.WriteLine("\t{0}", x.rsz); });

            //Tegyük használhatóbbá a keresést! Legyen a csillag jelentése hasonló,
            //mint az ACCESS Like operátoránál a csillag és ismerje a kérdőjelet is!
            string keres = '^'+Console.ReadLine()+"$";
            járművek.Where(x => Regex.IsMatch(x.rsz, keres.Replace("*", ".*").Replace("?","."),RegexOptions.IgnoreCase)).ToList().ForEach(x => { Console.WriteLine("\t{0}",x.rsz); });

            TimeSpan segédTP = TimeSpan.Zero;
            List<string> ki = new List<string>();
            járművek.ForEach(i =>
            {
                segédTP += i.deltaIdő;
                if (segédTP.TotalMinutes >= 5) segédTP = TimeSpan.Zero;
                if (segédTP == TimeSpan.Zero) ki.Add(string.Format("{0} {1}", i.idő.ToString("HH mm ss"), i.rsz));
            });
            File.WriteAllLines("vizsgalt.txt", ki);
            Console.ReadKey();
        }
    }
}