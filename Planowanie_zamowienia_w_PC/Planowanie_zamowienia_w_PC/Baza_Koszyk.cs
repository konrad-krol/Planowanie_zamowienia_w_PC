using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planowanie_zamowienia_w_PC
{
    class Baza_Koszyk
    {
        public static Dictionary<Klucz, Zawartosc> Koszyk = new Dictionary<Klucz, Zawartosc>();
        public class Klucz
        {
            public string Nazwa { get; set; }
            public Klucz(string okNazwa)
            {
                Nazwa = okNazwa;
            }
        }

        public static Dictionary<Klucz, Zawartosc> Czyszczenie_Koszyka(Dictionary<Klucz, Zawartosc> slownik)
        {
            slownik.Clear();
            return slownik;
        }
        public class Zawartosc
        {
            public decimal Cena { get; set; }
            public int Ilosc { get; set; }
            public int? Pojemnosc { get; set; }
            public Zawartosc(decimal okCena, int okIlosc, int? okPojemnosc)
            {
                Cena = okCena;
                Ilosc = okIlosc;
                Pojemnosc = okPojemnosc;
            }
        }
    }
}
