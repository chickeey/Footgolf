using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Footgolf
{
    class Program
    {
        static List<Versenyzo> versenyzok;
        static void Main(string[] args)
        {
            Feladat02();
            Feladat03();
            Feladat04();
            Console.ReadKey();
        }
        private static void Feladat04()
        {
            double nok = versenyzok.Count(a => a.Kategoria.ToLower().Contains("noi"));
            double arany = (nok * 100) / versenyzok.Count();
            Console.WriteLine("4. feladat: A női versenyzők aránya: {0:0.00}%", arany);
        }
        private static void Feladat03()
        {
            Console.WriteLine("3. feladat: Versenyzők száma: " + versenyzok.Count());
        }
        private static void Feladat02()
        {
            versenyzok = new List<Versenyzo>();

            var sr = new StreamReader(@"..\..\Res\fob2016.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                var tomb = sr.ReadLine().Split(';');

                versenyzok.Add(new Versenyzo(tomb[0], tomb[1], tomb[2],
                    new int[] { int.Parse(tomb[3]), int.Parse(tomb[4]), int.Parse(tomb[5]), int.Parse(tomb[6]), int.Parse(tomb[7]), int.Parse(tomb[8]), int.Parse(tomb[9]), int.Parse(tomb[10]) }));
            }
            sr.Close();
            Console.WriteLine("8. feladat: Egyesület statisztika");
            Dictionary<string, int> d = new Dictionary<string, int>();
            foreach (var i in versenyzok)
            {
                if (d.ContainsKey(i.Egyesulet))
                {
                    d[i.Egyesulet]++;
                }
                else
                {
                    d.Add(i.Egyesulet, 1);
                }
            }
            foreach (var i in d)
            {
                if (i.Key != "n.a." && i.Value >= 3)
                {
                    Console.WriteLine("\t{0} - {1} fő", i.Key, i.Value);
                }
            }
            List<string> kiirsor = new List<string>();
            foreach (var i in versenyzok)
            {
                if (i.Kategoria == "Felnott ferfi")
                {
                    kiirsor.Add($"{i.Nev};{i.OsszPont}");
                }
            }
            File.WriteAllLines("osszpontFF.txt", kiirsor);
        }
    }
}
