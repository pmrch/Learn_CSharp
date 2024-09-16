using System;

namespace Valami
{
    class Program
    {
        static void Main(string[] args)
        {
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
            //Console.ReadKey();

        }
    }
}
