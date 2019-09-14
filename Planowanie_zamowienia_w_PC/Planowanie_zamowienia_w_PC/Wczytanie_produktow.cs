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
        private static void Wczytaj_suplementy()
        {
            string pobierz;
            StreamReader file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\WITAMINY.txt");
            while((pobierz = file.ReadLine()) != null)
            {
                Bindowanie.Suplementy.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator)+1));
            }
            file = Czyszczenie(file);
            file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\KOLAGEN_KAPSOLKI.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Bindowanie.Suplementy.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
            file = Czyszczenie(file);
            file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\ALOESOWY_SOK.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Bindowanie.Suplementy.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
        }

        private static void Wczytaj_urzadzenia()
        {
            string pobierz;
            StreamReader file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\URZADZENIA.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Bindowanie.Urzadzenia.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
        }

        private static void Wczytaj_kosmetyki()
        {
            string pobierz;
            StreamReader file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\KOSMETYKI.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Bindowanie.Kosmetyki.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
            file = Czyszczenie(file);
            file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\PRODUKTY_KOLAGENOWE.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Bindowanie.Kosmetyki.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
            file = Czyszczenie(file);
            file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\KOLAGEN_GRAFIT_SREBRO_PLATYNA.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Bindowanie.Kosmetyki.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
        }

        private static void Wczytaj_aloes()
        {
            string pobierz;
            StreamReader file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\ALOE_VERA_LINE.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Bindowanie.Aloes.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
            file = Czyszczenie(file);
            file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\ALOESOWY_SOK.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Bindowanie.Aloes.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
        }

        private static void Wczytaj_kolagen()
        {
            string pobierz;
            StreamReader file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\PRODUKTY_KOLAGENOWE.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Bindowanie.Kolagen.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
            file = Czyszczenie(file);
            file = new StreamReader(@"C:\Projekty\Planowanie_zamowienia_w_PC\Planowanie_zamowienia_w_PC\Spis_produktow\KOLAGEN_GRAFIT_SREBRO_PLATYNA.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Bindowanie.Kolagen.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
        }
    }
}

