namespace DolgozatMegbeszeles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tomb = new int[10];
            Random veletlen = new Random();

            for (int i = 0; i < tomb.Count(); i++)
            {
                tomb.Append(veletlen.Next(0, 91));
                Console.Write("{0, }", tomb[i]);
            }

            int k = 0;
            while (k < 10 && !(tomb[k] > 20 && tomb[k] < 30))
            {
                k++;
            }
            Console.WriteLine(k);
        }
    }
}