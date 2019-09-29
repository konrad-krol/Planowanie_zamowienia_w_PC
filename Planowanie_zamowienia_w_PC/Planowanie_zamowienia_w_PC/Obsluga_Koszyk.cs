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

        public static void Dodaj_Do_Koszyka(string klucz, Baza_Produktow.Zawartosc zawartosc, int ilosc)
        {
            decimal cena_produktow = ilosc * zawartosc.Cena;
            if(Baza_Produktow.Koszyk.ContainsKey(klucz))
            {
                Edytuj_Koszyk(klucz, ilosc, ref Baza_Produktow.Koszyk, ref liczba_produktow_w_koszyku, ref kwota_zamowienia);
            }
            else
            {
                Baza_Produktow.Koszyk.Add(klucz, new Baza_Produktow.Zawartosc_Koszyk(cena_produktow, ilosc, zawartosc.Pojemnosc, zawartosc.Cena));
                kwota_zamowienia += cena_produktow;
                liczba_produktow_w_koszyku += ilosc;
            }
        }
        public static void Edytuj_Koszyk(string klucz, int ilosc_dodaj, ref Dictionary<string, Baza_Produktow.Zawartosc_Koszyk> koszyk, 
            ref int ilosc_produktow_w_koszyku, ref decimal wartosc_zamowienia)
        {
            koszyk.TryGetValue(klucz, out Baza_Produktow.Zawartosc_Koszyk zawartosc);
            ilosc_produktow_w_koszyku += ilosc_dodaj;
            wartosc_zamowienia += zawartosc.Cena_Jednego * ilosc_dodaj;
            koszyk[klucz] = new Baza_Produktow.Zawartosc_Koszyk(zawartosc.Cena + ilosc_dodaj * zawartosc.Cena_Jednego, ilosc_dodaj + zawartosc.Ilosc, zawartosc.Pojemnosc, zawartosc.Cena_Jednego);

        }
        public static void Usuwanie_Z_Koszyka(string klucz)
        {
            Baza_Produktow.Koszyk.TryGetValue(klucz, out var pobierz_dane);
            kwota_zamowienia -= pobierz_dane.Cena;
            liczba_produktow_w_koszyku -= pobierz_dane.Ilosc;
            Baza_Produktow.Koszyk.Remove(klucz);
        }
    }
}
