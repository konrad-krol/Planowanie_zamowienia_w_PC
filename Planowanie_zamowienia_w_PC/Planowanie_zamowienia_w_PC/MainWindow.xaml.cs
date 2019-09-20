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
            Lista_Kosmetyki.ItemsSource = Baza_Produktow.Kosmetyki;
            Lista_Urzadzenia.ItemsSource = Baza_Produktow.Urzadzenia;
            Lista_Aloes.ItemsSource = Baza_Produktow.Aloes;
            Lista_Kolagen.ItemsSource = Baza_Produktow.Kolagen;
            Lista_Koszyk.ItemsSource = Baza_Koszyk.Koszyk;
        }
        private void Znikanie_ekranow()
        {
            Ekran_Powitalny.Visibility = Visibility.Collapsed;
            Ekran_Kategoria_Produktow.Visibility = Visibility.Collapsed;
            Ekran_Kategoria_Suplementy.Visibility = Visibility.Collapsed;
            Ekran_Produkty_W_Koszyku.Visibility = Visibility.Collapsed;
            Ekran_Kategoria_Aloes.Visibility = Visibility.Collapsed;
            Ekran_Kategoria_Kolagen.Visibility = Visibility.Collapsed;
            Ekran_Kategoria_Kosmetyki.Visibility = Visibility.Collapsed;
            Ekran_Kategoria_Urzadzenia.Visibility = Visibility.Collapsed;
        }
        private void Odswiezanie_List_Produktow()
        {
            Lista_Suplementy.Items.Refresh();
            Lista_Urzadzenia.Items.Refresh();
            Lista_Kosmetyki.Items.Refresh();
            Lista_Kolagen.Items.Refresh();
            Lista_Aloes.Items.Refresh();
            Lista_Koszyk.Items.Refresh();
            Liczba_Produtkow_Do_Dodania.Text = "1";
        }
        private void Przycisk_Rozpocznij_Click(object sender, RoutedEventArgs e)
        {
            bool potwierdzenie = false;
            try
            {
                Baza_Koszyk.Koszyk = Baza_Koszyk.Czyszczenie_Koszyka(Baza_Koszyk.Koszyk);
                potwierdzenie = Wczytanie_produktow.Wybor_wczytywanego_produktu(potwierdzenie);
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            if(potwierdzenie == true)
            {
                Znikanie_ekranow();
                Odswiezanie_List_Produktow();
                Ekran_Kategoria_Produktow.Visibility = Visibility.Visible;
            }
        }
        private void Przycisk_Dodaj_Do_Koszyka_Click(object sender, RoutedEventArgs e)
        {
            if (Lista_Suplementy.SelectedItem == null)
                MessageBox.Show("Brak zaznaczonego Produktu! \nProszę zaznaczyć produkt, który ma zostać dodany do koszyka!");
            else
            {
                var pobierz_dane = (KeyValuePair<Baza_Produktow.Klucz, Baza_Produktow.Zawartosc>)Lista_Suplementy.SelectedItem;
                Obsluga_Koszyk.Dodaj_Do_Koszyka(pobierz_dane.Key.Nazwa, pobierz_dane.Value.Cena,
                    Int32.Parse(Liczba_Produtkow_Do_Dodania.Text.ToString()), pobierz_dane.Value.Pojemnosc);
                Odswiezanie_List_Produktow();
            }
        }
        private void Przycisk_Wybor_Ekranu_Click(object sender, RoutedEventArgs e)
        {
            Znikanie_ekranow();
            Button Przycisk = (Button)sender;
            switch (Przycisk.Content.ToString())
            {
                case "Suplementy diety":
                    Ekran_Kategoria_Suplementy.Visibility = Visibility.Visible;
                    break;
                case "Urządzenia":
                    Ekran_Kategoria_Urzadzenia.Visibility = Visibility.Visible;
                    break;
                case "Kosmetyki":
                    Ekran_Kategoria_Kosmetyki.Visibility = Visibility.Visible;
                    break;
                case "Aloe Vera Line":
                    Ekran_Kategoria_Aloes.Visibility = Visibility.Visible;
                    break;
                case "Kolagen":
                    Ekran_Kategoria_Kolagen.Visibility = Visibility.Visible;
                    break;
                case "Wstecz":
                    Ekran_Kategoria_Produktow.Visibility = Visibility.Visible;
                    break;
                case "Idź do koszyka":
                    Ekran_Produkty_W_Koszyku.Visibility = Visibility.Visible;
                    break;
                default:
                    MessageBox.Show("Nieznana operacja!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
        }
    }
}

