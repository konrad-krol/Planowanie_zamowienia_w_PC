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
        private static DataGrid kategoria_zamawianego_produktu;
        public MainWindow()
        {
            InitializeComponent();
            Lista_Suplementy.ItemsSource = Baza_Produktow.Suplementy;
            Lista_Kosmetyki.ItemsSource = Baza_Produktow.Kosmetyki;
            Lista_Urzadzenia.ItemsSource = Baza_Produktow.Urzadzenia;
            Lista_Aloes.ItemsSource = Baza_Produktow.Aloes;
            Lista_Kolagen.ItemsSource = Baza_Produktow.Kolagen;
            Lista_Koszyk.ItemsSource = Baza_Produktow.Koszyk;
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
            Ekran_Obsluga_Zamowienia.Visibility = Visibility.Collapsed;
        }
        private void Odswiezanie_List_Produktow()
        {
            Lista_Suplementy.Items.Refresh();
            Lista_Urzadzenia.Items.Refresh();
            Lista_Kosmetyki.Items.Refresh();
            Lista_Kolagen.Items.Refresh();
            Lista_Aloes.Items.Refresh();
            Lista_Koszyk.Items.Refresh();
            Pobierz_Liczba_Produtkow_Do_Dodania_Obsluga_Zamowienia.Text = "1";
            Pobierz_Liczba_Produtkow_Do_Dodania_Produkty_W_Koszyku.Text = "1";
            Tekst_Kwota_Zamowienia_Kategoria_Produktow.Text = string.Format("{0:c}", Obsluga_Koszyk.kwota_zamowienia);
            Tekst_Kwota_Zamowienia_Obsluga_Zamowienia.Text = string.Format("{0:c}", Obsluga_Koszyk.kwota_zamowienia);
            Tekst_Kwota_Zamowienia_Produkty_W_Koszyku.Text = string.Format("{0:c}", Obsluga_Koszyk.kwota_zamowienia);
            Tekst_Liczba_Zamowionych_Produktow_Kategoria_Produktow.Text = Obsluga_Koszyk.liczba_produktow_w_koszyku.ToString();
            Tekst_Liczba_Zamowionych_Produktow_Obsluga_Zamowienia.Text = Obsluga_Koszyk.liczba_produktow_w_koszyku.ToString();
        }
        private void Przycisk_Rozpocznij_Click(object sender, RoutedEventArgs e)
        {
            bool potwierdzenie = false;
            try
            {
                Baza_Produktow.Koszyk = Baza_Produktow.Czyszczenie_Koszyk(Baza_Produktow.Koszyk);
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
            if (kategoria_zamawianego_produktu.SelectedItem == null)
                MessageBox.Show("Brak zaznaczonego Produktu! \nProszę zaznaczyć produkt, który ma zostać dodany do koszyka!");
            else
            {
                var pobierz_dane = (KeyValuePair<Baza_Produktow.Klucz, Baza_Produktow.Zawartosc>)kategoria_zamawianego_produktu.SelectedItem;
                string ccc = pobierz_dane.Key.Nazwa;
                Obsluga_Koszyk.Dodaj_Do_Koszyka(pobierz_dane.Key, pobierz_dane.Value, Int32.Parse(Pobierz_Liczba_Produtkow_Do_Dodania_Obsluga_Zamowienia.Text.ToString().Replace(" ", "")));
                Odswiezanie_List_Produktow();
                Obsluga_Koszyk.Sprawdz_Koszyk(pobierz_dane.Key);
            }
        }
        private void Przycisk_Wybor_Ekranu_Click(object sender, RoutedEventArgs e)
        {
            Znikanie_ekranow();
            Odswiezanie_List_Produktow();
            Button Przycisk = (Button)sender;
            switch (Przycisk.Content.ToString())
            {
                case "Suplementy diety":
                    Ekran_Kategoria_Suplementy.Visibility = Visibility.Visible;
                    Ekran_Obsluga_Zamowienia.Visibility = Visibility.Visible;
                    kategoria_zamawianego_produktu = Lista_Suplementy;
                    break;
                case "Urządzenia":
                    Ekran_Kategoria_Urzadzenia.Visibility = Visibility.Visible;
                    Ekran_Obsluga_Zamowienia.Visibility = Visibility.Visible;
                    kategoria_zamawianego_produktu = Lista_Urzadzenia;
                    break;
                case "Kosmetyki":
                    Ekran_Kategoria_Kosmetyki.Visibility = Visibility.Visible;
                    Ekran_Obsluga_Zamowienia.Visibility = Visibility.Visible;
                    kategoria_zamawianego_produktu = Lista_Kosmetyki;
                    break;
                case "Aloe Vera Line":
                    Ekran_Kategoria_Aloes.Visibility = Visibility.Visible;
                    Ekran_Obsluga_Zamowienia.Visibility = Visibility.Visible;
                    kategoria_zamawianego_produktu = Lista_Aloes;
                    break;
                case "Kolagen":
                    Ekran_Kategoria_Kolagen.Visibility = Visibility.Visible;
                    Ekran_Obsluga_Zamowienia.Visibility = Visibility.Visible;
                    kategoria_zamawianego_produktu = Lista_Kolagen;
                    break;
                case "Wstecz":
                    Ekran_Kategoria_Produktow.Visibility = Visibility.Visible;
                    break;
                case "Idź do koszyka":
                    Ekran_Produkty_W_Koszyku.Visibility = Visibility.Visible;
                    kategoria_zamawianego_produktu = Lista_Koszyk;
                    break;
                default:
                    MessageBox.Show("Nieznana operacja!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
        }
        private void Blokada_Liter_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key <= Key.D9 && e.Key >= Key.D0) ? false : true;
        }

        private void Przycisk_Usun_Click(object sender, RoutedEventArgs e)
        {
            if (kategoria_zamawianego_produktu.SelectedItem == null)
                MessageBox.Show("Brak zaznaczonego Produktu! \nProszę zaznaczyć produkt, który ma zostać dodany do koszyka!");
            else
            {
                var pobierz_dane = (KeyValuePair<Baza_Produktow.Klucz, Baza_Produktow.Zawartosc_Koszyk>)kategoria_zamawianego_produktu.SelectedItem;
                Obsluga_Koszyk.Usuwanie_Z_Koszyka(pobierz_dane.Key);
                Odswiezanie_List_Produktow();
            }
        }
    }
}

