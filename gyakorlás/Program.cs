using System.Text;
namespace gyakorlás
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder valasz = new StringBuilder(3);
            /*
            for (char ch = 'a';  ch <= 'z'; ++ch)
            {
                sb.Append(ch);
            }
            Console.Write(sb);*/
            string[] szavak = { "mag", "bab", "aba", "sir", "sin" };
            Random feladat = new Random();
            int rejtett = feladat.Next(0, 5);

            bool vege = true;

            int pontok = 3;
            string tipp = "";
            while (vege)
            {
                Console.WriteLine("Add meg a tippedet: ");
                tipp = Console.ReadLine();

                StringBuilder valasz = new StringBuilder(3);
                if (tipp == "stop" || pontok == 0)
                {
                    vege = false;
                }
                else
                {
                    Console.WriteLine("Add meg a tippedet: ");
                    tipp = Console.ReadLine();

                    //Console.WriteLine("rejtett szó:\t{0}", szavak[rejtett]);
                    Console.WriteLine("A tipp:\t\t{0}", tipp);

                    //char[] valasz = { '.', '.', '.' };
                    pontok = 0;
                    for (int i = 0; i < tipp.Length; i++)
                    {
                        if (tipp[i] == szavak[rejtett][i])
                        {
                            valasz.Append(tipp[i]);
                        }
                        else
                        {
                            valasz.Append('.');
                            pontok++;
                        }
                    }
                    string seged = "";
                    Console.Write("Válasz:\t\t");
                    for (int l = 0; l < valasz.Length; l++)
                    {
                        Console.Write(valasz[l]);
                        seged += valasz[l];
                    }
                    Console.WriteLine();
                    Console.WriteLine(pontok);
                }
            }
            string ess = new string("próbaszöveg");

            Console.WriteLine(ess);
            string csere;
            csere = ess.Replace(ess[5], 'z');
            Console.WriteLine(csere);
        }
    }
}
