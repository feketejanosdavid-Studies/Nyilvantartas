using Library.Data;
using Library.Models;
using System;

namespace Programunk
{
    public class Program
    {
        static void KiIr(IEnumerable<object> adatok)
        {
            foreach (var item in adatok)
                Console.WriteLine(item.ToString());
            Console.WriteLine();
        }

        static void Main(string[] args)
        {

            AdatContext db = new AdatContext();

            if (!db.Adatok.Any())
            {
                var sorok = File.ReadAllLines(@"c:\Users\Diak\..fjd\Második_félév\asztali_alkalmazasok\2024-03-27\1.csv").Skip(1);
                foreach (var line in sorok)
                {
                    db.Adatok.Add(new Adatok(line));
                    db.SaveChanges();
                }
            }

            KiIr(db.Adatok);
        }
    }
}

