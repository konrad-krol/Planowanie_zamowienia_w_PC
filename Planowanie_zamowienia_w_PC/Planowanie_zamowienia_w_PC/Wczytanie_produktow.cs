using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Planowanie_zamowienia_w_PC
{
    class Wczytanie_produktow
    {
        public Dictionary<string, string> Suplementy = new Dictionary<string, string>();
        public Dictionary<string, string> Kosmetyki = new Dictionary<string, string>();
        public Dictionary<string, string> Urzadzenia = new Dictionary<string, string>();
        public Dictionary<string, string> Aloes = new Dictionary<string, string>();
        public Dictionary<string, string> Kolagen = new Dictionary<string, string>();

        private string separator = ";";

        public void Wybor_wczytywanego_produktu(string rodzaj_wczytywanych_produktów)
        {
            switch (rodzaj_wczytywanych_produktów)
            {
                case "suplementy":
                    Wczytaj_suplementy();
                    break;
                case "kosmetyki":
                    Wczytaj_kosmetyki();
                    break;
                case "urzadzenia":
                    Wczytaj_urzadzenia();
                    break;
                case "aloes":
                    Wczytaj_aloes();
                    break;
                case "kolagen":
                    Wczytaj_kolagen();
                    break;
                default:
                    break;
            }
        }

        private void Wczytaj_suplementy()
        {
            string pobierz;
            StreamReader file = new StreamReader(@"\Spis_produktow\WITAMINY.txt");
            while((pobierz = file.ReadLine()) != null)
            {
                Suplementy.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator)+1));
            }
            file = new StreamReader(@"\Spis_produktow\KOLAGEN_KAPSOLKI.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Suplementy.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
            file = new StreamReader(@"\Spis_produktow\ALOESOWY_SOK.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Suplementy.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
        }

        private void Wczytaj_urzadzenia()
        {
            string pobierz;
            StreamReader file = new StreamReader(@"\Spis_produktow\URZADZENIA.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Urzadzenia.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
        }

        private void Wczytaj_kosmetyki()
        {
            string pobierz;
            StreamReader file = new StreamReader(@"\Spis_produktow\KOSMETYKI.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Kosmetyki.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
            file = new StreamReader(@"\Spis_produktow\PRODUKTY_KOLAGENOWE.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Kosmetyki.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
            file = new StreamReader(@"\Spis_produktow\KOLAGEN_GRAFIT_SREBRO_PLATYNA.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Kosmetyki.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
        }

        private void Wczytaj_aloes()
        {
            string pobierz;
            StreamReader file = new StreamReader(@"\Spis_produktow\ALOE_VERA_LINE.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Aloes.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
            file = new StreamReader(@"\Spis_produktow\ALOESOWY_SOK.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Aloes.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
        }

        private void Wczytaj_kolagen()
        {
            string pobierz;
            StreamReader file = new StreamReader(@"\Spis_produktow\PRODUTY_KOLAGENOWE.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Kolagen.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
            file = new StreamReader(@"\Spis_produktow\KOLAGEN_GRAFIT_SREBRO_PLATYNA.txt");
            while ((pobierz = file.ReadLine()) != null)
            {
                Kolagen.Add(pobierz.Substring(0, pobierz.IndexOf(separator)), pobierz.Substring(pobierz.IndexOf(separator) + 1));
            }
        }
    }
}

