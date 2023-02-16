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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

    }
}
