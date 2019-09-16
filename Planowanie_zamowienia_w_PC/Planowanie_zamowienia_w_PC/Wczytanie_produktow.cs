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
        private static string sciezka_kosmetyki = @"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\KOSMETYKI.txt";
        private static string sciezka_witaminy = @"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\WITAMINY.txt";
        private static string sciezka_kolagen_kapsolki = @"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\KOLAGEN_KAPSOLKI.txt";
        private static string sciezka_aloesowy_sok = @"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\ALOESOWY_SOK.txt";
        private static string sciezka_urzadzenia = @"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\URZADZENIA.txt";
        private static string sciezka_produkty_kolagenowe = @"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\PRODUKTY_KOLAGENOWE.txt";
        private static string sciezka_kolagen_grafit_srebro_platyna = @"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\KOLAGEN_GRAFIT_SREBRO_PLATYNA.txt";
        private static string sciezka_aloe_vera_line = @"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\ALOE_VERA_LINE.txt";


        public static bool Wybor_wczytywanego_produktu(bool potwierdzenie)
        {
            Wczytaj_aloes();
            Wczytaj_kolagen();
            Wczytaj_kosmetyki();
            Wczytaj_suplementy();
            Wczytaj_urzadzenia();
            zaladuj();

            string[] spis = { "aloes", "kolagen", "kosmetyki", "suplementy", "urzadzenia", "true" };
            foreach(string wybor in spis)
            {

            }
            return potwierdzenie;
        }

        private static bool Spis_Produktow(bool potwierdzenie, string wybor)
        {
            switch(wybor)
            {
                case "aloes":
                    string[] tablica_sciezka_aloes = { sciezka_aloe_vera_line, sciezka_aloesowy_sok };
                    break;
                case "kolagen":
                    string[] tablica_sciezka_kolagen = { sciezka_produkty_kolagenowe, sciezka_kolagen_grafit_srebro_platyna, };
                    break;
                case "kosmetyki":
                    string[] tablica_sciezka_kosmetyki = { sciezka_kosmetyki, sciezka_produkty_kolagenowe, sciezka_kolagen_grafit_srebro_platyna };
                    break;
                case "suplementy":
                    string[] tablica_sciezka_suplementy = { sciezka_witaminy, sciezka_kolagen_kapsolki, sciezka_aloesowy_sok };
                    break;
                case "urzadzenia":
                    string[] tablica_sciezka_urzadzenia = { sciezka_urzadzenia };
                    break;
                case "true":
                    potwierdzenie = true;
                    break;
                default:
                    potwierdzenie = false;
                    break;
            }
            return potwierdzenie;
        }
        private static void wczytaj(ref Dictionary<Bindowanie.Klucz, Bindowanie.Zawartosc> slownik, string sciezka)
        {
            string pobierz = "";
            string dane = "";
            decimal? cena = null;
            decimal? ilosc = null;
            StreamReader file = new StreamReader(sciezka, Encoding.UTF8);
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out ilosc);
                slownik.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc(cena, ilosc));
            }
        }
        private static void zaladuj()
        {
            string[] ilosc = { sciezka_witaminy, sciezka_kolagen_kapsolki, sciezka_aloesowy_sok };
            foreach(string ccc in ilosc)
            {
                wczytaj(ref Bindowanie.Suplementy, ccc);
            }
        }
        private static StreamReader Czyszczenie(StreamReader czyszczenie_zmiennej)
        {
            czyszczenie_zmiennej = null;
            return czyszczenie_zmiennej;
        }
        private static void Pobieranie(ref string dane, out string nazwa, out decimal? cena, out decimal? ilosc)
        {
            nazwa = dane.Substring(0, dane.IndexOf(separator));
            string reszta = dane.Substring(dane.IndexOf(separator)+1);
            cena = Convert.ToDecimal(reszta.Substring(0, reszta.IndexOf(separator)));
            try
            {
                ilosc = Convert.ToDecimal(reszta.Substring(reszta.IndexOf(separator)+1));
            }
            catch
            {
                ilosc = null;
            }
        }
        private static void Wczytaj_suplementy()
        {
            string pobierz = "";
            string dane = "";
            decimal? cena = null;
            decimal? ilosc = null;
            StreamReader file = new StreamReader(sciezka_witaminy, Encoding.UTF8);
            while((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out ilosc);
                Bindowanie.Suplementy.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc(cena, ilosc));
            }
            Czyszczenie(file);
            file = new StreamReader(sciezka_kolagen_kapsolki, Encoding.UTF8);
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out ilosc);
                Bindowanie.Suplementy.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc(cena, ilosc));
            }
            Czyszczenie(file);
            file = new StreamReader(sciezka_aloesowy_sok, Encoding.UTF8);
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out ilosc);
                Bindowanie.Suplementy.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc(cena, ilosc));
            }
        }

        private static void Wczytaj_urzadzenia()
        {
            string pobierz = "";
            string dane = "";
            decimal? cena = null;
            decimal? ilosc = null;
            StreamReader file = new StreamReader(sciezka_urzadzenia, Encoding.UTF8);
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out _);
                Bindowanie.Urzadzenia.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc(cena, ilosc));
            }
        }

        private static void Wczytaj_kosmetyki()
        {
            string pobierz = "";
            string dane = "";
            decimal? cena = null;
            decimal? ilosc = null;
            StreamReader file = new StreamReader(sciezka_kosmetyki, Encoding.UTF8);
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out ilosc);
                Bindowanie.Kosmetyki.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc(cena, ilosc));
            }
            Czyszczenie(file);
            file = new StreamReader(sciezka_produkty_kolagenowe, Encoding.UTF8);
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out ilosc);
                Bindowanie.Kosmetyki.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc(cena, ilosc));
            }
            Czyszczenie(file);
            file = new StreamReader(sciezka_kolagen_grafit_srebro_platyna, Encoding.UTF8);
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out ilosc);
                Bindowanie.Kosmetyki.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc(cena, ilosc));
            }
        }

        private static void Wczytaj_aloes()
        {
            string pobierz = "";
            string dane = "";
            decimal? cena = null;
            decimal? ilosc = null;
            StreamReader file = new StreamReader(sciezka_aloe_vera_line, Encoding.UTF8);
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out _);
                Bindowanie.Aloes.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc(cena, ilosc));
            }
            Czyszczenie(file);
            file = new StreamReader(sciezka_aloesowy_sok, Encoding.UTF8);
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out _);
                Bindowanie.Aloes.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc(cena, ilosc));
            }
        }

        private static void Wczytaj_kolagen()
        {
            string pobierz = "";
            string dane = "";
            decimal? cena = 0;
            decimal? ilosc = 0;
            StreamReader file = new StreamReader(sciezka_produkty_kolagenowe, Encoding.UTF8);
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out _);
                Bindowanie.Kolagen.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc(cena, ilosc));
            }
            Czyszczenie(file);
            file = new StreamReader(sciezka_kolagen_grafit_srebro_platyna, Encoding.UTF8);
            while ((pobierz = file.ReadLine()) != null)
            {
                Pobieranie(ref pobierz, out dane, out cena, out _);
                Bindowanie.Kolagen.Add(new Bindowanie.Klucz(dane), new Bindowanie.Zawartosc(cena, ilosc));
            }
            Czyszczenie(file);
        }
    }
}

