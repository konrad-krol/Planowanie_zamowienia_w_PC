using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planowanie_zamowienia_w_PC
{
    class Obsluga_Koszyk
    {
        public static int liczba_produktow_do_dodania_koszyka = 0;
        public static decimal kwota_zamowienia = 0.00M;
        public static int liczba_produktow_w_koszyku = 0;

        public static void Dodaj_Do_Koszyka(string nazwa_produktu, decimal cena_produktow, int ilosc, int? pojemnosc)
        {
            cena_produktow *= ilosc;
            kwota_zamowienia += cena_produktow;
            liczba_produktow_w_koszyku += ilosc;
            Baza_Koszyk.Koszyk.Add(new Baza_Koszyk.Klucz(nazwa_produktu), new Baza_Koszyk.Zawartosc(cena_produktow, ilosc, pojemnosc));
        }
        public static void Usuwanie_Z_Koszyka(Baza_Koszyk.Klucz klucz)
        {
            Baza_Koszyk.Koszyk.TryGetValue(klucz, out var pobierz_dane);
            decimal cena = pobierz_dane.Cena;
            int ilosc = pobierz_dane.Ilosc;
            kwota_zamowienia -= cena;
            liczba_produktow_w_koszyku -= ilosc;
            Baza_Koszyk.Koszyk.Remove(klucz);
        }
    }
}
