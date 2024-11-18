using System;
using System.Linq;

namespace Létra
{
  class ProgramBetter
  {
    static void Main(string[] args)
    {
      int[] dobasok = { 3, 1, 1, 2, 1, 5, 5, 4, 4, 4, 1, 2, 3, 6, 4, 6, 1, 4 };

      Console.WriteLine("2. feladat");
      int holtart = 0;
      int le = 0;

      for (int i = 0; i < dobasok.Count(); i++)
      {
        holtart += dobasok[i];

        if (holtart % 10 == 0)
        {
          holtart -= 3;
          le++;
        }
        Console.Write("{0} ", holtart);
      }
      Console.WriteLine();

      Console.WriteLine("3. feladat");
      Console.WriteLine("A játék során {0} alkalommal lépett létrára.",le);

      Console.WriteLine("4. feladat");
      Console.WriteLine((holtart >= 45) ? "A játékot befejezte." : "A játékot abbahagyta.");
    }
  }
}