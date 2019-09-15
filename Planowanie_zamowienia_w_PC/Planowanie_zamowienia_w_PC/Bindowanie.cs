using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planowanie_zamowienia_w_PC
{
    class Bindowanie
    {
        public static Dictionary<Klucz, Zawartosc_1> Suplementy = new Dictionary<Klucz, Zawartosc_1>();
        public static Dictionary<Klucz, Zawartosc_2> Kosmetyki = new Dictionary<Klucz, Zawartosc_2>();
        public static Dictionary<Klucz, Zawartosc_2> Urzadzenia = new Dictionary<Klucz, Zawartosc_2>();
        public static Dictionary<Klucz, Zawartosc_2> Aloes = new Dictionary<Klucz, Zawartosc_2>();
        public static Dictionary<Klucz, Zawartosc_2> Kolagen = new Dictionary<Klucz, Zawartosc_2>();
        public class Klucz
        {
            public string Nazwa { get; set; }
            public Klucz(string okNazwa)
            {
                Nazwa = okNazwa;
            }
        }
        public class Zawartosc_1
        {
            public double? Cena { get; set; }
            public double? Ilosc { get; set; }
            public Zawartosc_1(double? okCena, double? okIlosc)
            {
                Cena = okCena;
                Ilosc = okIlosc;
            }
        }
        public class Zawartosc_2
        {
            public double? Cena { get; set; }
            public Zawartosc_2(double? okCena)
            {
                Cena = okCena;
            }
        }


    }
}
