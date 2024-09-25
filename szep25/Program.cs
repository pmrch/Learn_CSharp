namespace szep25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.
            string korte = "alma";
            // 2.
            Console.WriteLine(korte[2]);
            // 3.
            Random sportfogadas = new Random();
            // 4.
            string[] duma = new string[20];
            // 5.
            for (int i = 0; i < duma.Length; i++)
            {
                duma[i] = sportfogadas.Next(1, 101).ToString();
            }
            // Tipuselteres alatt hiba keletkezik, mert a duma tomb csak string tipusu valtozot tarolhat,
            // nem pedig int-et, a sportfogadas erteke egy int.

            string[] nevek = { "Miki", "Nóri", "Béla", "Kati", "Feri", "Jani", "Soma", "Tomi", "Laci", "Miki", "Doma", "Geri" };
            string[] masolat = new string[nevek.Length];
            int masolathoz = 0;

            for (int j = 0; j < nevek.Length; j++)
            {
                Console.WriteLine(nevek[j]);
                if (nevek[j][1] == 'a')
                {
                    masolat[masolathoz] = nevek[j];
                    masolathoz++;
                }
                //Console.Write("{0,5}", nevek[j]);
            }
            for (int k = 0; k < masolathoz; k++)
            {
                Console.Write("{0,5}", masolat[k]);
            }
            Console.WriteLine();
            for (int l = 0; l < nevek.Length; l++)
            {
                int db = 0;
                for (int i = 0; i < nevek[i].Length; i++)
                {
                    if (nevek[l][i] == 'i')
                    {
                        db++;
                    }
                }
                if (db == 2)
                {
                    Console.Write("{0,5}", nevek[l]);
                }
                db = 0;
            }

        }
    }
}
