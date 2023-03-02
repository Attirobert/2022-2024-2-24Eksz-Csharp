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

        public MainWindow()
        {
            InitializeComponent();
            keszletLoad();
            arAllitas(false);
        }

        private void keszletLoad()
        {
            Keszlet klt = new Keszlet();

            Button[] b = { btnHetfo, btnKedd, btnSzerda, btnCsutortok, btnPentek, btnSzombat, btnVasarnap };
            TextBox[] t = { tbxHetfo, tbxKedd, tbxSzerda, tbxCsutortok, tbxPentek, tbxSzombat, tbxVasarnap };

            for (int i = 0; i < b.Length; i++)
            {
                klt.nap = b[i];
                klt.ar = t[i];
                keszlet.Add(klt);
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                string msg = (string)(sender as Button).Content;

                // Megkeresem, hogy melyik gomb lett lenyomva
                foreach (var klt in keszlet)
                    if (msg == klt.nap.Content.ToString())
                    {
                        msg += ": " + klt.ar.Text + " Ft";
                        break;
                    }
                MessageBox.Show(msg);
            }

        }

        private void btnBeallitas_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult valasz = MessageBox.Show("Megváltoztatja az árakat?", "Figyelmeztetés", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (valasz == MessageBoxResult.Yes)
                arAllitas(true);
        }

        private void arAllitas(bool b)
        {
            foreach (var klt in keszlet)
                klt.ar.IsEnabled = b;
        }

        private void btnAlkalmaz_Click(object sender, RoutedEventArgs e)
        {
            bool negativ = false;
            foreach (var klt in keszlet)
                if (int.Parse(klt.ar.Text) <= 0)
                {
                    negativ = true;
                    break;
                }

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
            string eredmNap = "";
            int osszeg, eredmOsszeg = int.MaxValue;

            foreach (var klt in keszlet)
            {
                osszeg = int.Parse(klt.ar.Text) * klt.nap.Content.ToString().Length;
                if (osszeg < eredmOsszeg)
                {
                    eredmOsszeg = osszeg;
                    eredmNap = klt.nap.Content.ToString();
                }
            }

            MessageBox.Show($"Legolcsóbb, ha {eredmNap}i napon kéred meg Pöttöm Panna kezét, ekkor {eredmOsszeg} Ft-ba kerül.");
        }

        private void btnKilepes_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
