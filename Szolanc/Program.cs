using System.Threading.Tasks.Dataflow;

namespace Szolanc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> szavak = new List<string>();
            //string[] szavak = new string[100];
            int n = 0;
            bool jo = true;
            int siker = 0;

            char utolso;
            char elso;

            while (jo)
            {
                Console.Write("{0}. Szó: ", n + 1);
                //szavak[n] = Console.ReadLine();
                szavak.Add(Console.ReadLine());
                //utolso = szavak[n][5];

                if (szavak[n].Length != 6)
                {
                    jo = false;
                    Console.WriteLine("A karakterek száma téves! ");
                }

                //Console.WriteLine(elso);
                //Console.WriteLine(utolso);
                else
                {
                    if (n != 0)
                    {
                        elso = szavak[n][0];
                        utolso = szavak[n - 1][5];
                        if (elso != utolso)
                        {
                            Console.WriteLine("Nem illeszkedett! ");
                            jo = false;
                        }
                        else
                        {
                            siker++;
                        }
                    }
                    n++;
                }
            }
            /*
            if (siker <= 2)
            {
                Console.WriteLine("Kezdő");
            }
            else if (siker <= 5)
            {
                Console.WriteLine("közepes");
            }
            else
            {
                Console.WriteLine("haladó");
            }*/
            
            switch (n)
            {
                case 0: Console.WriteLine("Kezdő");
                    break;
                case 1: Console.WriteLine("Kezdő");
                    break;
                case 2: Console.WriteLine("Kezdő");
                    break;

                case 3: Console.WriteLine("Közepes");
                    break;
                case 4: Console.WriteLine("Közepes");
                    break;
                case 5: Console.WriteLine("Közepes");
                    break;
                default: Console.WriteLine("Sint: haladó");
                    break;
            }
            foreach (var item in szavak)
            {
                Console.Write("{0}, ", item);
            }
        }
    }
}
