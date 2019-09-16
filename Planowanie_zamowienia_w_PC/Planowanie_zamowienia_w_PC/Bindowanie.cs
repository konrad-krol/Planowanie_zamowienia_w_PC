using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planowanie_zamowienia_w_PC
{
    class Bindowanie
    {
        public static Dictionary<Klucz, Zawartosc> Suplementy = new Dictionary<Klucz, Zawartosc>();
        public static Dictionary<Klucz, Zawartosc> Kosmetyki = new Dictionary<Klucz, Zawartosc>();
        public static Dictionary<Klucz, Zawartosc> Urzadzenia = new Dictionary<Klucz, Zawartosc>();
        public static Dictionary<Klucz, Zawartosc> Aloes = new Dictionary<Klucz, Zawartosc>();
        public static Dictionary<Klucz, Zawartosc> Kolagen = new Dictionary<Klucz, Zawartosc>();
        public class Klucz
        {
            public string Nazwa { get; set; }
            public Klucz(string okNazwa)
            {
                Nazwa = okNazwa;
            }
        }
        public class Zawartosc
        {
            public decimal? Cena { get; set; }
            public decimal? Ilosc { get; set; }
            public Zawartosc(decimal? okCena, decimal? okIlosc)
            {
                Cena = okCena;
                Ilosc = okIlosc;
            }
        }


    }
}
