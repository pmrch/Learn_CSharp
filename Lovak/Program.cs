namespace Lovak
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> erossegek = new List<int>();
            foreach (var item in File.ReadAllLines("be1.txt"))
            {
                erossegek.Add(int.Parse(item));
            }

            int N = erossegek[0];

            for (int i = 1; i <= N; i++)
            {
                if (erossegek[i] <= 50)
                {
                    Console.WriteLine(0);
                }

                else if (erossegek[i] > 50 && erossegek[i] <= 90)
                {
                    if (erossegek[i] < 55) Console.WriteLine(5);
                    else if (erossegek[i] <= 60) Console.WriteLine(10);
                    else if (erossegek[i] <= 65) Console.WriteLine(15);
                    else if (erossegek[i] <= 70) Console.WriteLine(20);
                    else if (erossegek[i] <= 75) Console.WriteLine(25);
                    else if (erossegek[i] <= 80) Console.WriteLine(30);
                    else if (erossegek[i] <= 85) Console.WriteLine(35);
                    else Console.WriteLine(40);
                }
                // Strength is greater than 90
                else if (erossegek[i] > 90) Console.WriteLine(45);
            }
        }
    }
}
