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
        }

        private void Przycisk_Rozpocznij_Click(object sender, RoutedEventArgs e)
        {
            Wczytaj();
            Znikanie_ekranow();
        }
        private void Wczytaj()
        {
            Wczytanie_produktow.Wybor_wczytywanego_produktu();
        }

        private void Znikanie_ekranow()
        {
            Ekran_Powitalny.Visibility = Visibility.Collapsed;
        }

    }
}
