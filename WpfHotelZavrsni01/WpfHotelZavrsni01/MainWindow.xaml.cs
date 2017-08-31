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

namespace WpfHotelZavrsni01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CekiranjeDal ckDal = new CekiranjeDal();
        private RezervacijaDal rDal = new RezervacijaDal();
        private PageCekiranje p1 = new PageCekiranje();
        private GostDal gDal = new GostDal();
        public MainWindow()
        {
            InitializeComponent();
            frame1.Navigate(new PageHome());
        }
       
        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
           
        
            WindowCekiranje wc = new WindowCekiranje();
            wc.Title = "Cekiranje gostiju";
            if (wc.ShowDialog() == true)
            {
                if (ckDal.InsertInto(wc.CekiranjeProp))
                {
                    MessageBox.Show("Cekiranje uspesno");
                    p1.PrikaziCekiranja();
                    frame1.Navigate(new PageHome());
                    
                }
                else MessageBox.Show("Greska");
            }
            else MessageBox.Show("Odustali ste od cekiranja");
        }

        private void menuHome_Click(object sender, RoutedEventArgs e)
        {
            borderFrame.BorderThickness = new Thickness(1);
            frame1.Navigate(new PageHome());
            p1.datagridCekiranja.SelectedIndex = -1;
        }

        private void menuRezervacije_Click(object sender, RoutedEventArgs e)
        {
            borderFrame.BorderThickness = new Thickness(1);
            frame1.Navigate(new PageRezervacije());
            p1.datagridCekiranja.SelectedIndex = -1;

        }

        private void menuCekiranje_Click(object sender, RoutedEventArgs e)
        {
            borderFrame.BorderThickness = new Thickness(1);
            frame1.Navigate(p1);
         
        }

        private void btnPromeni_Click(object sender, RoutedEventArgs e)
        {
           if(p1.datagridCekiranja.SelectedIndex<0)
            {
                MessageBox.Show("Selektujte cekiranje");
                frame1.Navigate(p1);
                return;
            }
           

            Cekiranje c = ckDal.PronadjiCekiranjePoGostu(p1.ckView.CekiranjeId);
            if (c == null)
                return;

            int id1 = c.SobaId;
            c.GostProp = gDal.PronadjiGosta(c.GostId);
            WindowCekiranje w1 = new WindowCekiranje();
            w1.Title = "Promena";
            w1.CekiranjeProp = c;
            w1.comboboxTipSobe.SelectedIndex = w1.SelektujTip(p1.ckView.VrstaSobe);
            w1.comboBoxUsluga.SelectedIndex = w1.SelektujUslugu(c.UslugaId);
            w1.dataGridSobe.SelectedIndex = w1.SelektujSobu(c.SobaId);
            if(w1.ShowDialog()==true)
            {
                if (ckDal.Update(w1.CekiranjeProp))
                {
                    Rezervacija r = new Rezervacija();
                    r.RezervacijaId = w1.CekiranjeProp.CekiranjeId;
                    r.SobaId = w1.CekiranjeProp.SobaId;
                    r.DatumCekiranja = w1.CekiranjeProp.DatumCekiranja;
                    r.DatumOdjave = w1.CekiranjeProp.DatumOdjave;
                    if (rDal.Update(r))
                    {
                        if (ckDal.PromeniStanjeSobe(id1, r.SobaId))
                        {
                            MessageBox.Show("Uspesno izvrsena promena");
                            p1.PrikaziCekiranja();
                            frame1.Navigate(p1);                          
                        }                      
                    }
                }
                else MessageBox.Show("Greska");
            }
                  
        }

        private void textboxPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            p1.PrikaziCekiranja(textboxPretraga.Text);
           
        }

        private void ButtonPretraga_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(p1);
        }

        private void menuGalerija_Click(object sender, RoutedEventArgs e)
        {
            borderFrame.BorderThickness = new Thickness(0);
            p1.datagridCekiranja.SelectedIndex = -1;
            frame1.Navigate(new PageGalerija());         

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (p1.datagridCekiranja.SelectedIndex < 0)
            {
                MessageBox.Show("Selektujte cekiranje");
                frame1.Navigate(p1);
                return;
            }


            Cekiranje c = ckDal.PronadjiCekiranjePoGostu(p1.ckView.CekiranjeId);
            if (c == null)
                return;

            Rezervacija r = rDal.PronadjiRezervaciju(c.CekiranjeId);
             Gost g = gDal.PronadjiGosta(c.GostId);
            if (g == null)
                return;
            if (r == null)
                return;

            c.GostProp = g;
            if (ckDal.Delete(c))
            {
                if (rDal.Delete(r))
                {
                    MessageBox.Show("Brisanje uspesno");
                    p1.PrikaziCekiranja();
                    frame1.Navigate(p1);
                }
                else MessageBox.Show("r");
            }
            else MessageBox.Show("Greska gost");

        }
    }
}
