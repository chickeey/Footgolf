using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footgolf
{
    class Versenyzo
    {
        public string Nev { get; set; }
        public string Kategoria { get; set; }
        public string Egyesulet { get; set; }
        public int[] Pontok { get; set; }

        public int OsszPont => PontSzamitas(Pontok);

        public object osszpontszam { get; internal set; }

        public Versenyzo(string nev, string kat, string egy, int[] pontok)
        {
            Nev = nev;
            Kategoria = kat;
            Egyesulet = egy;
            Pontok = pontok;
        }
        public int PontSzamitas(int[] pontok)
        {
            Array.Sort(pontok);
            int ossz = 0;
            for (int i = 0; i < pontok.Length; i++)
            {
                if (pontok[i] != 0 && i < 2) pontok[i] = 10;
                ossz += pontok[i];
            }
            return ossz;
        }
    }
}

