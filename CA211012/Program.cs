using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CA211012
{
    class Program
    {
        static List<Kategoria> kategoriak = new List<Kategoria>();
        static void Main(string[] args)
        {
            Beolvasas();
            Console.WriteLine($"2. feladat: {kategoriak.Count} db");
            Console.WriteLine($"3. feladat: {kategoriak.Sum(x => x.Eltunt + x.Tulelo)} fő");
            Console.Write($"4. feladat: Kulcsszó: ");
            string ksz = Console.ReadLine();
            bool van = kategoriak.Any(x => x.Nev.Contains(ksz));
            Console.WriteLine($"\t{(van ? "Van találat" : "Nincs találat")}");
            if (van)
            {
                Console.Write("5. feladat: ");
                kategoriak.Where(x => x.Nev.Contains(ksz))
                    .ToList()
                    .ForEach(y => Console.WriteLine($"\n{y.Nev} {y.Tulelo + y.Eltunt} fő"));
            }

            Console.WriteLine($"7. feladat: {kategoriak.Where(x => x.Tulelo == kategoriak.Max(y => y.Tulelo)).First().Nev}");
               
            Console.ReadKey();
        }

        private static void Beolvasas()
        {
            using (var sr = new StreamReader("titanic.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    kategoriak.Add(new Kategoria(sr.ReadLine()));
                }
            }
            

        }
    }
}
