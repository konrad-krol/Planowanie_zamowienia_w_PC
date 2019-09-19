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
            string[] spis = { "aloes", "kolagen", "kosmetyki", "suplementy", "urzadzenia", "true" };
            foreach(string wybor in spis)
            {
                potwierdzenie = Spis_Produktow(potwierdzenie, wybor);
            }
            return potwierdzenie;
        }
        private static bool Spis_Produktow(bool potwierdzenie, string wybor)
        {
            switch(wybor)
            {
                case "aloes":
                    string[] tablica_sciezka_aloes = { sciezka_aloe_vera_line, sciezka_aloesowy_sok };
                    Baza_Produktow.Aloes = Baza_Produktow.Czyszczenie_Produktow(Baza_Produktow.Aloes);
                    Baza_Produktow.Aloes = Wczytaj_produkty(Baza_Produktow.Aloes, tablica_sciezka_aloes);
                    break;
                case "kolagen":
                    string[] tablica_sciezka_kolagen = { sciezka_produkty_kolagenowe, sciezka_kolagen_grafit_srebro_platyna, };
                    Baza_Produktow.Kolagen = Baza_Produktow.Czyszczenie_Produktow(Baza_Produktow.Kolagen);
                    Baza_Produktow.Kolagen = Wczytaj_produkty(Baza_Produktow.Kolagen, tablica_sciezka_kolagen);
                    break;
                case "kosmetyki":
                    string[] tablica_sciezka_kosmetyki = { sciezka_kosmetyki, sciezka_produkty_kolagenowe, sciezka_kolagen_grafit_srebro_platyna };
                    Baza_Produktow.Kosmetyki = Baza_Produktow.Czyszczenie_Produktow(Baza_Produktow.Kosmetyki);
                    Baza_Produktow.Kosmetyki = Wczytaj_produkty(Baza_Produktow.Kosmetyki, tablica_sciezka_kosmetyki);
                    break;
                case "suplementy":
                    string[] tablica_sciezka_suplementy = { sciezka_witaminy, sciezka_kolagen_kapsolki, sciezka_aloesowy_sok };
                    Baza_Produktow.Suplementy = Baza_Produktow.Czyszczenie_Produktow(Baza_Produktow.Suplementy);
                    Baza_Produktow.Suplementy = Wczytaj_produkty(Baza_Produktow.Suplementy, tablica_sciezka_suplementy);
                    break;
                case "urzadzenia":
                    string[] tablica_sciezka_urzadzenia = { sciezka_urzadzenia };
                    Baza_Produktow.Urzadzenia = Baza_Produktow.Czyszczenie_Produktow(Baza_Produktow.Urzadzenia);
                    Baza_Produktow.Urzadzenia = Wczytaj_produkty(Baza_Produktow.Urzadzenia, tablica_sciezka_urzadzenia);
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
        private static Dictionary<Baza_Produktow.Klucz, Baza_Produktow.Zawartosc> Wczytaj_produkty(Dictionary<Baza_Produktow.Klucz, Baza_Produktow.Zawartosc> slownik, string[] sciezka)
        {
            string pobierz = "";
            string dane = "";
            decimal cena = 0.00M;
            int? ilosc = null;
            foreach(string wybierz in sciezka)
            {
                StreamReader file = new StreamReader(wybierz, Encoding.UTF8);
                while ((pobierz = file.ReadLine()) != null)
                {
                    Pobieranie(pobierz, out dane, out cena, out ilosc);      
                    slownik.Add(new Baza_Produktow.Klucz(dane), new Baza_Produktow.Zawartosc(cena, ilosc));        
                }                
                file = Czyszczenie_File(file);             
            }
            return slownik;
        }
        private static void Pobieranie(string dane, out string nazwa, out decimal cena, out int? ilosc)
        {
            nazwa = dane.Substring(0, dane.IndexOf(separator));
            string reszta = dane.Substring(dane.IndexOf(separator)+1);
            cena = Convert.ToDecimal(reszta.Substring(0, reszta.IndexOf(separator)));
            try
            {
                ilosc = Convert.ToInt32(reszta.Substring(reszta.IndexOf(separator)+1));
            }
            catch
            {
                ilosc = null;
            }
        }
        private static StreamReader Czyszczenie_File(StreamReader czyszczenie_zmiennej)
        {
            czyszczenie_zmiennej = null;
            return czyszczenie_zmiennej;
        }
    }
}

