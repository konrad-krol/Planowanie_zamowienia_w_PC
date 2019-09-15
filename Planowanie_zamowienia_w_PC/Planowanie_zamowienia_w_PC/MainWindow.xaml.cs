using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Planowanie_zamowienia_w_PC
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Lista_Produktow.ItemsSource = Produkt;
            Dodawanie();
        }

        public Dictionary<A, B> Produkt = new Dictionary<A, B>();

        public void Dodawanie()
        {
            Produkt.Add(new A("witaminy"), new B(57.60, null));
            Produkt.Add(new A("Kolagen"), new B(112,22));
            
            Lista_Produktow.Items.Refresh();
        }

        public class A
        {
            public string Nazwa { get; set; }
            public A(string okNazwa)
            {
                Nazwa = okNazwa;
            }
        }
        public class B
        {
            public double Cena { get; set; }
            public double? Ilosc { get; set; }
            public B(double okCena, double? okIlosc)
            {
                Cena = okCena;
                Ilosc = okIlosc;
            }
        }
        private void Przycisk_Rozpocznij_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                Wczytaj();
                Znikanie_ekranow();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Wczytaj()
        {
            Wczytanie_produktow.Wybor_wczytywanego_produktu();
        }

        private void Znikanie_ekranow()
        {
            Ekran_Powitalny.Visibility = Visibility.Collapsed;
        }

        private void Przycisk_Dodaj_Do_Koszyka_Click(object sender, RoutedEventArgs e)
        {
            Dodawanie();
            Lista_Produktow.Items.Refresh();
        }
    }
}

