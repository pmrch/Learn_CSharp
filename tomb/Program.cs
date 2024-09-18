namespace tomb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lotto = new int[20];  // 20 elemű tömb létrehozása
            Random szamok = new Random(); // szamok nevű véletlen szám létrehozása

            for (int i = 0; i < 20; i++) // a lottó i-edik elemét az iteráló + 1 háromszorosához teszi egyenlővé
            {
                // lotto[i] = (i + 1) * 3; 
                lotto[i] = szamok.Next(100, 201); // 100 és 200 közti egész véletlen számmal töltjük meg a lottót
            }

            for (int i = 0; i < lotto.Length; i++) // Iterátor, ami végigmegy a lottó elemein
            {
                Console.Write("{0} {1}", lotto[i], ", ");
            }

            int osszeg = 0;

            for(int i = 0; i < lotto.Length - 1; i++)
            {
                osszeg += lotto[i];
            }
            Console.WriteLine();
            Console.Write("A lottó számok összege: {0}", osszeg);

            Console.ReadKey();
        }
    }
}
