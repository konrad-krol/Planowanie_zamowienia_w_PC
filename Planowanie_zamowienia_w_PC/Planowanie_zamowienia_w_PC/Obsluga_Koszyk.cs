using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planowanie_zamowienia_w_PC
{
    class Obsluga_Koszyk
    {
        public static int ilosc_produktow_do_koszyka = new int ();

        public class Liczba_Produktow_Do_Koszyka
        {
            public int Liczba_do_dodania { get; set; }
            public Liczba_Produktow_Do_Koszyka(int ok_Liczba_Produktow_Do_Koszyka)
            {
                Liczba_do_dodania = ok_Liczba_Produktow_Do_Koszyka;
            }
        }
        public static void Dodaj_Do_Koszyka(string nazwa_produktu, decimal cena_produktow, int ilosc, int? pojemnosc)
        {
            cena_produktow *= ilosc;
            Baza_Koszyk.Koszyk.Add(new Baza_Koszyk.Klucz(nazwa_produktu), new Baza_Koszyk.Zawartosc(cena_produktow, ilosc, pojemnosc));
        }
    }
}
