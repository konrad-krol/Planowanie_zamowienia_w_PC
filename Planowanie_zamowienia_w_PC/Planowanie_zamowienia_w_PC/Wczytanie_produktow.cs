using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace Planowanie_zamowienia_w_PC
{
    class Wczytanie_produktow
    {
        private static string separator = ";";

        public static void Wybor_wczytywanego_produktu()
        {
            Wczytaj_aloes();
            Wczytaj_kolagen();
            Wczytaj_kosmetyki();
            Wczytaj_suplementy();
            Wczytaj_urzadzenia();
        }

        private static StreamReader Czyszczenie(StreamReader czyszczenie_zmiennej)
        {
            czyszczenie_zmiennej = null;
            return czyszczenie_zmiennej;
        }
        private static void Pobieranie(ref string dane, out string nazwa, out double? cena, out double? ilosc)
        {
            nazwa = dane.Substring(0, dane.IndexOf(separator));
            string reszta = dane.Substring(dane.IndexOf(separator)+1);
            cena = Convert.ToDouble(reszta.Substring(0, reszta.IndexOf(separator)));
            try
            {
                ilosc = Convert.ToDouble(reszta.Substring(reszta.IndexOf(separator)+1));
            }
            catch
            {
                ilosc = null;
            }
            
        }
        private static void Pobieranie(ref string dane, out string nazwa, out double? cena)
        {
            nazwa = dane.Substring(0, dane.IndexOf(separator));
            try
            {
                cena = Convert.ToDouble(dane.Substring(dane.IndexOf(separator)+1));
            }
            catch
            {
                cena = null;
            }
        }
        private static void Wczytaj_suplementy()
        {
            string pobierz = "";
            string dane = "";
            double? cena = null;
            double? ilosc = null;
            StreamReader file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\WITAMINY.txt");
            while((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out ilosc);
                Bindowanie.Suplementy.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc_1(cena, ilosc));
            }
            Czyszczenie(file);
            file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\KOLAGEN_KAPSOLKI.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out ilosc);
                Bindowanie.Suplementy.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc_1(cena, ilosc));
            }
            Czyszczenie(file);
            file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\ALOESOWY_SOK.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena);
                Bindowanie.Suplementy.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc_1(cena, null));
            }
        }

        private static void Wczytaj_urzadzenia()
        {
            string pobierz = "";
            string dane = "";
            double? cena = null;
            StreamReader file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\URZADZENIA.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena);
                Bindowanie.Urzadzenia.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc_2(cena));
            }
        }

        private static void Wczytaj_kosmetyki()
        {
            string pobierz = "";
            string dane = "";
            double? cena = null;
            double? ilosc = null;
            StreamReader file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\KOSMETYKI.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena);
                Bindowanie.Kosmetyki.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc_2(cena));
            }
            Czyszczenie(file);
            file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\PRODUKTY_KOLAGENOWE.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena);
                Bindowanie.Kosmetyki.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc_2(cena));
            }
            Czyszczenie(file);
            file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\KOLAGEN_GRAFIT_SREBRO_PLATYNA.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena);
                Bindowanie.Kosmetyki.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc_2(cena));
            }
        }

        private static void Wczytaj_aloes()
        {
            string pobierz = "";
            string dane = "";
            double? cena = null;
            double? ilosc = null;
            StreamReader file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\ALOE_VERA_LINE.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena);
                Bindowanie.Aloes.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc_2(cena));
            }
            Czyszczenie(file);
            file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\ALOESOWY_SOK.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena);
                Bindowanie.Aloes.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc_2(cena));
            }
        }

        private static void Wczytaj_kolagen()
        {
            string pobierz = "";
            string dane = "";
            double? cena = 0;
            double? ilosc = 0;
            StreamReader file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\PRODUKTY_KOLAGENOWE.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena);
                Bindowanie.Kolagen.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc_2(cena));
            }
            Czyszczenie(file);
            file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\KOLAGEN_GRAFIT_SREBRO_PLATYNA.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena);
                Bindowanie.Kolagen.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc_2(cena));
            }
            Czyszczenie(file);
        }
    }
}

