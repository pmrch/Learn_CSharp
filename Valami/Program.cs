using System;

namespace Valami
{
    class Program
    {
        static void Main(string[] args)
        {
            // Eredeti feladat
            Console.WriteLine("Üdv neked!");
            Console.Write("Hány éves vagy? ");

            string yr = Console.ReadLine();
            int num_of_yrs = int.Parse(yr);

            if (num_of_yrs < 14)
            {
                Console.Write("Jé, hogyhogy középsikolás vagy?");
            }
            else
            {
                Console.Write("Egy év múlva {0} éves leszel.", num_of_yrs + 1);
            }
            Console.WriteLine(" ");
            //Console.ReadKey();

            // Matyi feladat
            Console.Write("Mi volt Mátyás király keresztneve? ");
            string valasz = Console.ReadLine();

            if (valasz == "Mátyás")
            {
                Console.WriteLine("Valóban.");
            }
            else
            {
                Console.WriteLine("Hát majdnem");
            }

            // Csillag
            string csillag = new string('*', 10);
            Console.WriteLine(csillag);
            Console.WriteLine(" ");

            // Összetett típus és tömb (NEM LISTA)

            int[] tomb = {3, 5, 2, 1};
            // Tömbnél előre kell tudni a méretét
            // Ha számokkal meg akarunk tölteni egy tömböt, azt az előzőben láthatjuk

            // tomb = [2, 4, 6, 1];
            string szoveg = "vízalatti pacsirta csapda";

            Console.WriteLine(szoveg[5]);
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.WriteLine(tomb[i]);
            }
            Console.WriteLine(tomb[2]);

            Console.ReadKey();
        }
    }
}
