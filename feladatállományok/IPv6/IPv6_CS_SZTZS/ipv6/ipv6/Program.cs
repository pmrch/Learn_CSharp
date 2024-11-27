using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipv6
{
    public enum part {High = 0, Low = 4}

    class IPv6
    {
        public string Address { get; set; }
        private string[] words;

        public IPv6(string ip)
        {
            Address = ip;
            words = ip.Split(':');
        }

        public int NullaDB()
        {
            int db = 0;
            for (int i = 0; i < Address.Length; i++)
            {
                if (Address[i] == '0')
                {
                    db++;
                }
            }
            return db;
        }

        public string ValueIP()
        {   //vezetőnullák elhagyása
            string value = "";
            
            for (int i = 0; i < 8; i++)
            {
                int j = 0;
                while (j < 3 && words[i][j] == '0')
                {
                    j++;
                }
                while (j < 4)
                {
                    value += words[i][j];
                    j++;
                }
                if (i<7)
                {
                    value += ':';
                } 
            }
            return value;
        }

        public string ShortIP()
        {
            string shortIP = "";
            string[] word = ValueIP().Split(':');
            int maxhely = -1;
            int maxhossz = 0;
            int hossz = 0;

            for (int i = 0; i < 8; i++)
            {
                if (word[i] == "0")
                {
                    hossz++;
                    if (hossz > maxhossz)
                    {
                        maxhossz = hossz;
                        maxhely = i;
                    }
                }
                else
                {
                    hossz = 0;
                }
            }

            if (maxhossz < 2)
            {
                shortIP = "Nem rövidíthető tovább.";
            }
            else
            {
                int j = 0;
                while (j<= maxhely - maxhossz)
                {
                    shortIP += word[j];
                    shortIP += ':';
                    j++;
                }
                shortIP += ':';
                j = maxhely + 1;
                while (j < 7)
                {
                    shortIP = shortIP += word[j];
                    shortIP += ':';
                    j++;
                }
                if (j == 7) //az utolsó csomag, ha az nem 0-s. (Ha maxhely = 7, akkor j = 8, a cím vége ::)
                {
                    shortIP = shortIP += word[j];
                }
            }
            return shortIP;
        }

        public UInt64 Num(part p)
        {
            UInt64 num = 0;

            
            for (int i = (int)p; i < (int)p + 4; i++)
            {
                num <<= 16;
                num += (ulong) Hex2Int(words[i]);
            } 

            return num;
        }

        private int Hex2Int(string word)
        {
            int a = 0;

            //Technikásan, ha ismered a nyelvet
            //a = UInt64.Parse(word, System.Globalization.NumberStyles.HexNumber);

            //Részletezve
            //for (int i = 0; i < 4; i++)
            //{
            //    switch (word[i])
            //    {
            //        case 'a': a = 16 * a + 10; break;
            //        case 'b': a = 16 * a + 11; break;
            //        case 'c': a = 16 * a + 12; break;
            //        case 'd': a = 16 * a + 13; break;
            //        case 'e': a = 16 * a + 14; break;
            //        case 'f': a = 16 * a + 15; break;

            //        default: a = 16 * a + int.Parse(word[i].ToString());
            //            break;
            //    }
            //}

            //Szépen, ha ismered a kódokat
            for (int i = 0; i < 4; i++)
            {
                a <<= 4 ;
                a += (word[i] < 60 ? word[i] - 48 : word[i] - 87);
            }
            return a;
        }
    
    
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<IPv6> ips = new List<IPv6>();

            //1. feladat: adatok beolvasása
            #region 1
            using (System.IO.StreamReader sr = new System.IO.StreamReader("ip.txt"))
            {
                while (!sr.EndOfStream)
                {
                    ips.Add(new IPv6(sr.ReadLine()));
                }

            }

            #endregion

            //2. feladat: adatsorok száma
            #region 2
            Console.WriteLine("2. feladat");
            Console.WriteLine("Az állományban {0} darab adatsor van.", ips.Count);
            #endregion

            //3. feladat: legalacsonyabb ip-cím
            //1. megoldás: a címek összehasonlítása szövegként
            #region 3/1
            int minhely = 0;
            for (int i = 1; i < ips.Count; i++)
            {
                if (ips[minhely].Address.CompareTo(ips[i].Address) == 1)
                {
                    minhely = i;
                }
            }
            Console.WriteLine("3. feladat");
            Console.WriteLine("A legalacsonyabb tárolt IP-cím:\n\r\t{0}", ips[minhely].Address);
            #endregion

            //2. megoldás, a címek összehasonlítása 2 UInt64 számként
            #region 3/2
            int minh = 0;
            for (int i = 1; i < ips.Count; i++)
            {
                if (ips[minh].Num(part.High) > ips[i].Num(part.High) || (ips[minh].Num(part.High) == ips[i].Num(part.High) && ips[minh].Num(part.Low) > ips[i].Num(part.Low)))
                {
                    minh = i;
                }
            }
            Console.WriteLine("3. feladat");
            Console.WriteLine("A legalacsonyabb tárolt IP-cím:\n\r\t{0}", ips[minh].Address);
            Console.WriteLine("azaz:\t" + ips[minh].Num(part.High) + " " + ips[minh].Num(part.Low));
            #endregion

            //4. feladat: típusonként az IP-címek
            #region 4
            //csak 3-féle van, a szabályokat lehet egyszerüsíteni
            int docDB = 0;
            int devDB = 0;
            int addrDB = 0;
            foreach (IPv6 ip in ips)
            {
                if (ip.Address[0] == 'f')
                {
                    addrDB++;
                }
                else if (ip.Address[6] == 'd')
                {
                    docDB++;
                }
                else
                {
                    devDB++;
                }
            }
            Console.WriteLine("4. feladat:");
            Console.WriteLine("Dokumentációs cím: {0} darab\n\rGlobális egyedi cím: {1} darab\n\rHelyi egyedi cím: {2} darab", docDB, devDB, addrDB);
            #endregion

            //5. feladat: NullaDB>=18 (IPv6 osztályból)
            #region 5
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("sok.txt"))
            {
                for (int i = 0; i < ips.Count; i++)
                {
                    if (ips[i].NullaDB() >= 18)
                    {
                        sw.WriteLine("{0,3} {1}", i + 1, ips[i].Address);
                    }
                }
            }
            #endregion

            //6. feladat: sorszám bekérése IP rövidítés az osztályban
            #region 6
            Console.Write("Kérek egy sorszámot: ");
            int ssz = int.Parse(Console.ReadLine());
            Console.WriteLine(ips[ssz - 1].Address);
            Console.WriteLine(ips[ssz - 1].ValueIP());
            #endregion

            //7. feladat: tovább rövidítés
            #region 7
            Console.WriteLine(ips[ssz - 1].ShortIP());
            #endregion
    
            Console.ReadLine();
        }
    }
}
