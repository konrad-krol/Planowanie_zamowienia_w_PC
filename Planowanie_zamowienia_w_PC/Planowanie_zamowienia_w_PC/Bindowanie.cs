using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planowanie_zamowienia_w_PC
{
    class Bindowanie
    {
        public static Dictionary<string, string> Suplementy = new Dictionary<string, string>();
        public static Dictionary<string, string> Kosmetyki = new Dictionary<string, string>();
        public static Dictionary<string, string> Urzadzenia = new Dictionary<string, string>();
        public static Dictionary<string, string> Aloes = new Dictionary<string, string>();
        public static Dictionary<string, string> Kolagen = new Dictionary<string, string>();

        public string Suplement_Nazwa { get; set; }
        public string Suplement_Cena { get; set; }
        public string Kosmetyki_Nazwa { get; set; }
        public string Kosmetyki_Cena { get; set; }
        public string Urzadzenia_Nazwa { get; set; }
        public string Urzadzenia_Cena { get; set; }
        public string Aloes_Nazwa { get; set; }
        public string Aloes_Cena { get; set; }
        public string Kolagen_Nazwa { get; set; }
        public string Kolagen_Cena { get; set; }

        public Bindowanie(string Suplement_Nazwa_1, string Suplement_Cena_1, string Kosmetyki_Nazwa_1, string Kosmetyki_Cena_1,
            string Urzadzenia_Nazwa_1, string Urzadzenia_Cena_1, string Aloes_Nazwa_1, string Aloes_Cena_1,
            string Kolagen_Nazwa_1, string Kolagen_Cena_1)
        {
            Suplement_Nazwa = Suplement_Nazwa_1;
            Suplement_Cena = Suplement_Cena_1;
            Kosmetyki_Nazwa = Kosmetyki_Nazwa_1;
            Kosmetyki_Cena = Kosmetyki_Cena_1;
            Urzadzenia_Nazwa = Urzadzenia_Nazwa_1;
            Urzadzenia_Cena = Urzadzenia_Cena_1;
            Aloes_Nazwa = Aloes_Nazwa_1;
            Aloes_Cena = Aloes_Cena_1;
            Kolagen_Nazwa = Kolagen_Nazwa_1;
            Kolagen_Cena = Kolagen_Cena_1;
        }
        
        public static Dictionary<Nazwa,Cena> Produkt = new Dictionary<Nazwa, Cena>();

        public static void Dodawanie()
        {
            Produkt.Add(new Nazwa("abc"), new Cena(123));
            Produkt.Add(new Nazwa("def"), new Cena(456));
        }

        public class Nazwa
        {
            public Nazwa(string name)
            {
                Nazwa1 = name;
            }
            public string Nazwa1 { get; set; }
        }
        public class Cena
        {
            public Cena(int price)
            {
                Cena1 = price;
            }
            public int Cena1 { get; set; }
        }
    }
}
