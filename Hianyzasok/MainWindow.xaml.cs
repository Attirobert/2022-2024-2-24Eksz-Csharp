using System;
using System.Collections.Generic;
using System.IO;
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

namespace Hianyzasok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        struct Hianyzok
        {
            public string Nev,
                Osztaly;
            public int Elso,
                Utolso,
                M_Orak;
        }

        Button[] buttons;
        string inFile = @"..\..\..\szeptember.csv";

        // Fájl adatainak eltárolására
        List<Hianyzok> adatok = new List<Hianyzok>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonLoad(Button[] bt)
        {
            bt = { btn1f, btn2f, btn3f, btn4f, btn5f, btn6f};
        }

        private void btn1f1_Click(object sender, RoutedEventArgs e)
        {
            Hianyzok adat = new Hianyzok();

            string[] darabol;   // Ebbe daraboljuk fel a beolvasott sort

            using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
            {
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    darabol = sr.ReadLine().Split(";");
                    adat.Nev = darabol[0];
                    adat.Osztaly = darabol[1];
                    adat.Elso = int.Parse(darabol[2]);
                    adat.Utolso = Convert.ToInt32(darabol[3]);
                    adat.M_Orak = int.Parse(darabol[4]);

                    adatok.Add(adat);
                }

                sr.Close();

                // Elérhetővé tesszük a gombokat
                btn1f.IsEnabled = false; // Ne töltsük be újra
                for (int i = 1; i < buttons.Length; i++)
                {
                    buttons[i].IsEnabled = true;
                }
            }
        }
    }
}
