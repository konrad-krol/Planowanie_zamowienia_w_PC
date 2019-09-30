using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planowanie_zamowienia_w_PC
{
    class Baza_Produktow
    {
        public static Dictionary<string, Zawartosc> Suplementy = new Dictionary<string, Zawartosc>();
        public static Dictionary<string, Zawartosc> Kosmetyki = new Dictionary<string, Zawartosc>();
        public static Dictionary<string, Zawartosc> Urzadzenia = new Dictionary<string, Zawartosc>();
        public static Dictionary<string, Zawartosc> Aloes = new Dictionary<string, Zawartosc>();
        public static Dictionary<string, Zawartosc> Kolagen = new Dictionary<string, Zawartosc>();
        public static Dictionary<string, Zawartosc> Promocje = new Dictionary<string, Zawartosc>();

        public static Dictionary<string, Zawartosc_Koszyk> Koszyk = new Dictionary<string, Zawartosc_Koszyk>();

        public static Dictionary<string, Zawartosc> Czyszczenie_Produktow(Dictionary<string, Zawartosc> slownik)
        {
            slownik.Clear();
            return slownik;
        }
        public static Dictionary<string, Zawartosc_Koszyk> Czyszczenie_Koszyk(Dictionary<string, Zawartosc_Koszyk> slownik)
        {
            slownik.Clear();
            return slownik;
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
            public decimal Cena_Jednego { get; set; }
            public Zawartosc_Koszyk(decimal okCena, int okIlosc, int? okPojemnosc, decimal okCena_Jednego)
            {
                Cena = okCena;
                Ilosc = okIlosc;
                Pojemnosc = okPojemnosc;
                Cena_Jednego = okCena_Jednego;
            }
        }
        
    }
}
