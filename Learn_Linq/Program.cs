using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace LearnLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            foreach (var item in File.ReadAllLines("data.txt").Skip(1))
                people.Add(new Person { Name = item.Split(';')[0], Age = int.Parse(item.Split(';')[1]) });

            // Linq lekérdezés egy p ismeretlennel
            var young_people = people.Where(p => p.Age < 30);

            Console.WriteLine($"30 évnél fiatalabb személyek:");
            foreach (var person in young_people)
                Console.WriteLine($"{person.Name}, {person.Age} éves");

            // Linq lekérdezés: Rendezzük a személyeket kor szerint csökkenő sorrendbe
            var ordered_people = people.OrderByDescending(p => p.Age);

            Console.WriteLine("\nSzemélyek kor szerinti csökkenő sorrendbe: ");
            foreach (var person in ordered_people)
                Console.WriteLine($"{person.Name}, {person.Age} éves");

            // Linq lekérdezés segítségével megszámoljuk a 30 év felettieket
            int count = people.Count(p => p.Age > 30);
            Console.WriteLine("\n30 év feletti emberek száma: {0}", count);
            
            //Console.WriteLine(people.Count());
            var people_between_30_35 = people.Count(p => p.Age < 35 && p.Age > 30);
            Console.WriteLine("30 és 35 közötti emberek száma: {0}", people_between_30_35);

            // 
            Regex pattern = new Regex("^A");
            var nagy_a = people.Where(p => pattern.IsMatch(p.Name));
            
            Console.WriteLine("Nagy A-val kezdődő emberek: ");
            foreach (var item in nagy_a)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}