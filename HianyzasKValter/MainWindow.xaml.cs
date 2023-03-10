using Microsoft.Win32;
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
        struct OsztalyHiany
        {
            public string osztaly;
            public int orak;
        }
        struct Hianyzasok
        {
            public string nev;
            public string osztaly;
            public int elsoNap;
            public int utolsoNap;
            public int mulasztottOrak;
        }

        List<Hianyzasok> hianyzasok = new List<Hianyzasok>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn1Feladat_Click(object sender, RoutedEventArgs e)
        {
            lbListaKiir.Items.Clear();

            string fileNev = "";

            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == true)
            {
                fileNev = ofd.FileName;
            }

            Hianyzasok adat = new Hianyzasok();

            string sor;
            string[] darabol;

            using (StreamReader sr = new StreamReader(fileNev))
            {
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    sor = sr.ReadLine();
                    lbListaKiir.Items.Add(sor);

                    darabol = sor.Split(';');
                    adat.nev = darabol[0];
                    adat.osztaly = darabol[1];
                    adat.elsoNap = int.Parse(darabol[2]);
                    adat.utolsoNap = int.Parse(darabol[3]);
                    adat.mulasztottOrak = int.Parse(darabol[4]);

                    hianyzasok.Add(adat);
                }

                txb1FeladatEredmeny.Text = "Az adatok beolvasása sikeres volt.";
            }
        }

        private void btn2Feladat_Click(object sender, RoutedEventArgs e)
        {
            int osszesHianyzas = 0;
            for (int i = 0; i < hianyzasok.Count; i++)
            {
                osszesHianyzas += hianyzasok[i].mulasztottOrak;
            }
            txb2FeladatEredmeny.Text = osszesHianyzas.ToString();
        }

        private void btn3Feladat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn4Feladat_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < hianyzasok.Count; i++)
            {
                if (txb3FeladatNevBeker.Text == hianyzasok[i].nev)
                {
                    if (hianyzasok[i].mulasztottOrak > 0)
                    {
                        txb4FeladatEredmeny.Text = "A tanuló hiányzott szeptemberben";
                        break;
                    }
                    else
                    {
                        txb4FeladatEredmeny.Text = "A tanuló nem hiányzott szeptemberben";
                        break;
                    }
                }
            }
        }

        private void btn5Feladat_Click(object sender, RoutedEventArgs e)
        {
            lbHianyzokKiir.Items.Clear();
            for (int i = 0; i < hianyzasok.Count; i++)
            {
                if (txb3FeladatNapBeker.Text == hianyzasok[i].elsoNap.ToString())
                {
                    txbNap.Text = txb3FeladatNapBeker.Text;
                    lbHianyzokKiir.Items.Add(hianyzasok[i].nev + " (" + hianyzasok[i].osztaly + ")");
                }
            }
        }

        private void btn6Feladat_Click(object sender, RoutedEventArgs e)
        {
            bool voltOsztaly;

            // Ez a megoldás azért rossz, mert sok üres lesz a tömbben.
            // OsztalyHiany[] osztalyhiany = new OsztalyHiany[hianyzasok.Count];

            // Először meghatározzuk az osztályok számát
            int osztSzam = hianyzasok.Select(x => x.osztaly).Distinct().ToArray().Length;

            OsztalyHiany[] osztalyhiany = new OsztalyHiany[osztSzam];

            int ind = 0;
            for (int i = 0; i < hianyzasok.Count; i++)  // A meglévő adatokon iterálunk
            {
                voltOsztaly = false;
                for (int j = 0; j < ind; j++)   // Halmozott eredmény tömb
                {

                    if (hianyzasok[i].osztaly == osztalyhiany[j].osztaly)
                    {
                        osztalyhiany[j].orak += hianyzasok[i].mulasztottOrak;
                        voltOsztaly = true;
                    }
                }
                if (!voltOsztaly)
                {
                    osztalyhiany[ind].osztaly = hianyzasok[i].osztaly;
                    osztalyhiany[ind].orak = hianyzasok[i].mulasztottOrak;
                    ind++;
                }
            }

            // Berendezzük az eredményt - ez most nem működik, majd később megnézem mi a hiba
            osztalyhiany.OrderBy(x => x.osztaly);

            // Kiíratás fájlba
            SaveFileDialog sfd = new SaveFileDialog();
            // Hogy ne kelljen írogatni.
            sfd.DefaultExt = "csv";
            sfd.FileName = "osszesites";
            sfd.ShowDialog();

            using (StreamWriter sw = new StreamWriter(sfd.FileName))
            {
                for (int i = 0; i < osztalyhiany.Length; i++)
                    sw.WriteLine(osztalyhiany[i].osztaly + " / " + osztalyhiany[i].orak);
            }
        }
    }
}
