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
            Lista_Suplementy.ItemsSource = Baza_Produktow.Suplementy;
            
        }
        private void Znikanie_ekranow()
        {
            Ekran_Powitalny.Visibility = Visibility.Collapsed;
            Ekran_Kategoria_Produktow.Visibility = Visibility.Collapsed;
            Ekran_Kategoria_Suplementy.Visibility = Visibility.Collapsed;
            Ekran_Produkty_W_Koszyku.Visibility = Visibility.Collapsed;
        }
        private void Przycisk_Rozpocznij_Click(object sender, RoutedEventArgs e)
        {
            bool potwierdzenie = false;
            try
            {
                potwierdzenie = Wczytanie_produktow.Wybor_wczytywanego_produktu(potwierdzenie);
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            if(potwierdzenie == true)
            {
                Znikanie_ekranow();
            }
        }

        private void Przycisk_Dodaj_Do_Koszyka_Click(object sender, RoutedEventArgs e)
        {
            bool potwierdzenie = false;
            potwierdzenie = Wczytanie_produktow.Wybor_wczytywanego_produktu(potwierdzenie);
            Lista_Suplementy.Items.Refresh();
        }

        private void Przycisk_Suplementy_Click(object sender, RoutedEventArgs e)
        {
            Znikanie_ekranow();
            Ekran_Kategoria_Suplementy.Visibility = Visibility.Visible;
            Ekran_Produkty_W_Koszyku.Visibility = Visibility.Visible;
        }

        private void Przycisk_Powrot_Do_Kategorii_Produktow_Click(object sender, RoutedEventArgs e)
        {
            var sample = (KeyValuePair<Baza_Produktow.Klucz, Baza_Produktow.Zawartosc>)Lista_Suplementy.SelectedItem;
            string abc = sample.Key.Nazwa;
            decimal www = sample.Value.Cena;
            int? aaa = sample.Value.Ilosc;
        }
    }
}

