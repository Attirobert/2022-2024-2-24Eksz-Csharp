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
        // Adatszerkezet megadása
        struct Hianyzok
        {
            public string Nev,
                Osztaly;
            public int Elso,
                Utolso,
                M_Orak;
        }

        string inFile = @"..\..\..\szeptember.csv",
            outFile = @"..\..\..\osszesites.csv";


        // Diákok eltárolására
        List<Hianyzok> adatok = new List<Hianyzok>();

        private void btn1Olvas_Click(object sender, RoutedEventArgs e)
        {
            Hianyzok adat = new Hianyzok(); // 

            string[] darabol;

            tbxOut.Text = "\n\n1. feladat - ";

            using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
            {
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    darabol = sr.ReadLine().Split(";");
                    adat.Nev = darabol[0];
                    adat.Osztaly = darabol[1];
                    adat.Elso = Convert.ToInt32(darabol[2]);
                    adat.Utolso = Convert.ToInt32(darabol[3]);
                    adat.M_Orak = Convert.ToInt32(darabol[4]);

                    adatok.Add(adat);
                }
                sr.Close();
            }

            // Combo feltöltése
            setComboList();

            // Gombok elérhetőségének beállítása
            setGombEnabled(true);

            tbxOut.Text += "kész";
        }

        private void setComboList()
        {
            foreach (Hianyzok item in adatok)
                cbxNevek.Items.Add(item.Nev);

            cbxNevek.SelectedIndex = 0;
        }

        private void setGombEnabled(bool p)
        {
            btn1Olvas.IsEnabled = !p;
            btn2OsszMulaszt.IsEnabled =
            btn3Adatbe.IsEnabled =
            btn4DiakHianyzasa.IsEnabled =
            btn5DiakokHianyzasa.IsEnabled =
            btn6Kiiras.IsEnabled =
            cbxNevek.IsEnabled =
            dtpDatum.IsEnabled = p;
            
        }

        private void btn2OsszMulaszt_Click(object sender, RoutedEventArgs e)
        {
            tbxOut.Text += "\n\n2. feladat";
            tbxOut.Text += "\n\tÖsszes mulasztott órák száma: " + adatok.Sum(x => x.M_Orak) + " óra.";
        }

        private void btn4DiakHianyzasa_Click(object sender, RoutedEventArgs e)
        {
            int mNap = (int)dtpDatum.SelectedDate.Value.Day;
            string mNev = cbxNevek.SelectedItem.ToString();

            tbxOut.Text += "\n\n4. feladat";
            if (adatok.Count(x => x.Nev == mNev) > 0)
                tbxOut.Text += $"\n\t{mNev} tanuló hiányzott szeptemberben";
            else
                tbxOut.Text += $"\n\t{mNev} tanuló nem hiányzott szeptemberben";
        }

        private void btn5DiakokHianyzasa_Click(object sender, RoutedEventArgs e)
        {
            // Egy adott napon hiányzók kiszűrése
            int nap = (int)dtpDatum.SelectedDate.Value.Day;
            var eredm = adatok
                .Where(x => x.Elso <= nap && x.Utolso >= nap)
                .OrderBy(x => x.Nev)
                .Select(x => x.Nev)
                .ToArray();

            tbxOut.Text += "\n\n5. feladat\n";
            if (eredm.Length > 0)
                foreach (var item in eredm)
                    tbxOut.Text += item.ToString() + "\n";
        }

        private void btn6Kiiras_Click(object sender, RoutedEventArgs e)
        {
            // Kiszedem az osztályokat és sorba rendezem
            string[] osztalyok = adatok.Select(x => x.Osztaly).Distinct().ToArray();
            Array.Sort(osztalyok);

            // Külön tömbbe kigyüjtöm a hiányzásokat
            int[] osztHianyzas = new int[osztalyok.Length];
            for (int i = 0; i < osztalyok.Length; i++)
                for (int j = 0; j < adatok.Count; j++)
                    if (adatok[j].Osztaly == osztalyok[i])
                        osztHianyzas[i] += (adatok[j].M_Orak);

            // Kiíratás képernyőre
            tbxOut.Text += "\n\n6. feladat";
            for (int i = 0; i < osztalyok.Length; i++)
                tbxOut.Text += osztalyok[i] + ": " + Convert.ToString(osztHianyzas[i]) + "\n";

            // Kiíratás fájlba
            using (StreamWriter sw = new StreamWriter(outFile))
            {
                for (int i = 0; i < osztalyok.Length; i++)
                    sw.WriteLine(osztalyok[i] + ": " + Convert.ToString(osztHianyzas[i]));

                sw.Close();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            setGombEnabled(false);  // Induláskor csak a beolvasás gomb az aktív
            setDate(new DateTime(2017,9,19));
        }

        private void setDate(DateTime d)
        {
            dtpDatum.SelectedDate = d;
        }
    }
}
