using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planowanie_zamowienia_w_PC
{
    class Baza_Produktow
    {
        public static Dictionary<Klucz, Zawartosc> Suplementy = new Dictionary<Klucz, Zawartosc>();
        public static Dictionary<Klucz, Zawartosc> Kosmetyki = new Dictionary<Klucz, Zawartosc>();
        public static Dictionary<Klucz, Zawartosc> Urzadzenia = new Dictionary<Klucz, Zawartosc>();
        public static Dictionary<Klucz, Zawartosc> Aloes = new Dictionary<Klucz, Zawartosc>();
        public static Dictionary<Klucz, Zawartosc> Kolagen = new Dictionary<Klucz, Zawartosc>();

        public static Dictionary<Klucz, Zawartosc_Koszyk> Koszyk = new Dictionary<Klucz, Zawartosc_Koszyk>();

        public static Dictionary<Klucz, Zawartosc> Czyszczenie_Produktow(Dictionary<Klucz, Zawartosc> slownik)
        {
            slownik.Clear();
            return slownik;
        }
        public static Dictionary<Klucz, Zawartosc_Koszyk> Czyszczenie_Koszyk(Dictionary<Klucz, Zawartosc_Koszyk> slownik)
        {
            slownik.Clear();
            return slownik;
        }
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
            public decimal Cena { get; set; }
            public int? Pojemnosc { get; set; }
            public Zawartosc(decimal okCena, int? okPojemnosc)
            {
                Cena = okCena;
                Pojemnosc = okPojemnosc;
            }
        }
        public class Zawartosc_Koszyk
        {
            public decimal Cena { get; set; }
            public int Ilosc { get; set; }
            public int? Pojemnosc { get; set; }
            public Zawartosc_Koszyk(decimal okCena, int okIlosc, int? okPojemnosc)
            {
                Cena = okCena;
                Ilosc = okIlosc;
                Pojemnosc = okPojemnosc;
            }
        }


    }
}
