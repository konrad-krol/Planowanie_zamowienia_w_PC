using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Planowanie_zamowienia_w_PC
{
    class Obsluga_Koszyk
    {
        public static int liczba_produktow_do_dodania_koszyka = 0;
        public static decimal kwota_zamowienia = 0.00M;
        public static int liczba_produktow_w_koszyku = 0;

        public static void Dodaj_Do_Koszyka(Baza_Produktow.Klucz klucz, Baza_Produktow.Zawartosc zawartosc, int ilosc)
        {
            /*decimal abc = 1234;
            Baza_Produktow.Koszyk.Add(new Baza_Produktow.Klucz(klucz.Nazwa), new Baza_Produktow.Zawartosc_Koszyk(abc, ilosc, zawartosc.Pojemnosc));

            Baza_Produktow.Koszyk.TryGetValue(klucz, out var pobierz_dane);
            int? kkk = pobierz_dane.Ilosc;*/
            bool abc = Sprawdz_Koszyk(klucz);
            decimal cena_produktow = ilosc*zawartosc.Cena;
            kwota_zamowienia += cena_produktow;
            liczba_produktow_w_koszyku += ilosc;
            Baza_Produktow.Koszyk.Add(new Baza_Produktow.Klucz(klucz.Nazwa), new Baza_Produktow.Zawartosc_Koszyk(cena_produktow, ilosc, zawartosc.Pojemnosc));
            
        }
        public static bool Sprawdz_Koszyk(Baza_Produktow.Klucz klucz)
        {
            Baza_Produktow.Klucz abc = klucz;
            if (Baza_Produktow.Koszyk.ContainsKey(abc))
                return false;
            else
                return true;

        }
        public static void Usuwanie_Z_Koszyka(Baza_Produktow.Klucz klucz)
        {
            Baza_Produktow.Koszyk.TryGetValue(klucz, out var pobierz_dane);
            decimal cena = pobierz_dane.Cena;
            int ilosc = pobierz_dane.Ilosc;
            kwota_zamowienia -= cena;
            liczba_produktow_w_koszyku -= ilosc;
            Baza_Produktow.Koszyk.Remove(klucz);
        }
    }
}
