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

namespace HuvelykMatyi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    struct Keszlet
    {
        public Button nap;
        public TextBox ar;
    }

    
    public partial class MainWindow : Window
    {
        List<Keszlet> keszlet = new List<Keszlet>();
        //Dictionary<>
        public MainWindow()
        {
            InitializeComponent();
            keszletLoad();
            arAllitas(false);
        }

        private void keszletLoad()
        {
            Keszlet klt = new Keszlet();
            klt.nap = btnHetfo;
            klt.ar = tbxHetfo;
            keszlet.Add(klt);


        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                string nap = (string)(sender as Button).Content;
                string osszeg = "";

                string msg = nap;

                switch (nap)
                {
                    case "Hétfő":
                        osszeg = tbxHetfo.Text;
                        break;

                    case "Kedd":
                        osszeg = tbxKedd.Text;
                        break;

                    case "Szerda":
                        osszeg = tbxSzerda.Text;
                        break;

                    case "Csütörtök":
                        osszeg = tbxCsutortok.Text;
                        break;

                    case "Péntek":
                        osszeg = tbxPentek.Text;
                        break;

                    case "Szombat":
                        osszeg = tbxSzombat.Text;
                        break;

                    case "Vasárnap":
                        osszeg = tbxVasarnap.Text;
                        break;
                }

                msg += ": " + osszeg + " Ft";
                MessageBox.Show(msg);
            }

        }

        private void btnBeallitas_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult valasz = MessageBox.Show("Megváltoztatja az árakat?", "Figyelmeztetés", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (valasz == MessageBoxResult.Yes)
            {
                arAllitas(true);
            }
        }

        private void arAllitas(bool b)
        {
            tbxHetfo.IsEnabled = b;
            tbxKedd.IsEnabled = b;
            tbxSzerda.IsEnabled = b;
            tbxCsutortok.IsEnabled = b;
            tbxPentek.IsEnabled = b;
            tbxSzombat.IsEnabled = b;
            tbxVasarnap.IsEnabled = b;
        }

        private void btnAlkalmaz_Click(object sender, RoutedEventArgs e)
        {
            bool negativ = false;
            if (int.Parse(tbxHetfo.Text) <= 0) negativ = true;

            else if (int.Parse(tbxKedd.Text) <= 0) negativ = true;

            else if (int.Parse(tbxSzerda.Text) <= 0) negativ = true;

            else if (int.Parse(tbxCsutortok.Text) <= 0) negativ = true;

            else if (int.Parse(tbxPentek.Text) <= 0) negativ = true;

            else if (int.Parse(tbxSzombat.Text) <= 0) negativ = true;

            else if (int.Parse(tbxVasarnap.Text) <= 0) negativ = true;

            if (!negativ) arAllitas(false);
        }

        private void tbx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (int.Parse((sender as TextBox).Text) <= 0)
                (sender as TextBox).Background = Brushes.Red;
            else
                (sender as TextBox).Background = Brushes.White;
        }

        private void btnLegolcsobb_Click(object sender, RoutedEventArgs e)
        {
            // Hétfő
            string nap = btnHetfo.Content.ToString();
            int osszeg = int.Parse(tbxHetfo.Text) * nap.Length;

            // Kedd
            string nap2 = btnKedd.Content.ToString();
            int osszeg2 = int.Parse(tbxKedd.Text) * nap2.Length;
            if (osszeg > osszeg2)
            {
                nap = nap2;
                osszeg = osszeg2;
            }

            // Szerda
            nap2 = btnSzerda.Content.ToString();
            osszeg2 = int.Parse(tbxSzerda.Text) * nap2.Length;
            if (osszeg > osszeg2)
            {
                nap = nap2;
                osszeg = osszeg2;
            }

            // Csütörtök
            nap2 = btnCsutortok.Content.ToString();
            osszeg2 = int.Parse(tbxCsutortok.Text) * nap2.Length;
            if (osszeg > osszeg2)
            {
                nap = nap2;
                osszeg = osszeg2;
            }

            // Péntek
            nap2 = btnPentek.Content.ToString();
            osszeg2 = int.Parse(tbxPentek.Text) * nap2.Length;
            if (osszeg > osszeg2)
            {
                nap = nap2;
                osszeg = osszeg2;
            }

            // Szombat
            nap2 = btnSzombat_Copy2.Content.ToString();
            osszeg2 = int.Parse(tbxSzombat.Text) * nap2.Length;
            if (osszeg > osszeg2)
            {
                nap = nap2;
                osszeg = osszeg2;
            }

            // Vasárnap
            nap2 = btnVasarnap_Copy2.Content.ToString();
            osszeg2 = int.Parse(tbxVasarnap.Text) * nap2.Length;
            if (osszeg > osszeg2)
            {
                nap = nap2;
                osszeg = osszeg2;
            }

            MessageBox.Show($"Legolcsóbb, ha {nap}i napon kéred meg Pöttöm Panna kezét, ekkor {osszeg} Ft-ba kerül.");
        }

        private void btnKilepes_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
