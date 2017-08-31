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
using System.Windows.Shapes;

namespace WpfHotelZavrsni01
{
    /// <summary>
    /// Interaction logic for WindowCekiranje.xaml
    /// </summary>
    public partial class WindowCekiranje : Window
    {
        private RezervacijaTermini rezTermin=null;
        private SobaDal sDal = new SobaDal();
        private DateTime datumPrijave;
        private DateTime datumOdjave;
        private decimal cenaUsluga;
        private decimal cenaSobe;
        private Cekiranje cekiranjeProp = new Cekiranje();
        internal Cekiranje CekiranjeProp
        {
            get {
               
                cekiranjeProp.GostProp.Ime = textboxImeGosta.Text;
                cekiranjeProp.GostProp.Prezime = textboxPrezime.Text;
                cekiranjeProp.GostProp.Jmbg = textboxJmbg.Text;
                cekiranjeProp.GostProp.KontaktTelefon = textboxKontaktTelefon.Text;
                if (textboxEmail.Foreground.ToString() != "#FF808080")
                    cekiranjeProp.GostProp.Email = textboxEmail.Text;
                else cekiranjeProp.GostProp.Email = "no emali";
               
             
                if(dataGridSobe.SelectedIndex>-1)
                {
                    Soba s = (Soba)dataGridSobe.SelectedItem;
                    cekiranjeProp.SobaId = s.SobaId;
                }
                if (comboBoxUsluga.SelectedIndex > -1)
                {
                    DodatnaUsluga dt = (DodatnaUsluga)comboBoxUsluga.SelectedItem;
                    cekiranjeProp.UslugaId = dt.UslugaId;
                }
                cekiranjeProp.DatumCekiranja = datepickerPrijava.SelectedDate.Value;
                cekiranjeProp.DatumOdjave = datepickerOdjava.SelectedDate.Value;
                cekiranjeProp.UkupnaCenaPoDanu = IzracunajCenu();
                return cekiranjeProp; }
            set {
                cekiranjeProp = value;
                textboxImeGosta.Text = cekiranjeProp.GostProp.Ime;
                textboxPrezime.Text = cekiranjeProp.GostProp.Prezime;
                textboxJmbg.Text = cekiranjeProp.GostProp.Jmbg;
                textboxKontaktTelefon.Text = cekiranjeProp.GostProp.KontaktTelefon;
                if(cekiranjeProp.GostProp.Email!=null)
                {
                    textboxEmail.Text = cekiranjeProp.GostProp.Email;
                }
                datepickerPrijava.SelectedDate = cekiranjeProp.DatumCekiranja;
                datepickerOdjava.SelectedDate = cekiranjeProp.DatumOdjave;
                dataGridSobe.SelectedIndex = SelektujSobu(cekiranjeProp.SobaId);
                PromeniBoju();
            }
        }

        public WindowCekiranje(RezervacijaTermini termin=null)
        {
            InitializeComponent();
            PrikaziTip();
            PrikaziUslugu();
            if (termin==null)
            {                    
                PocetniDatum(true);
            }
            else if(termin!=null)
            {
                datepickerPrijava.SelectedDate = termin.MoguceCekiranje.Date;
                if (!termin.MogucaOdjava.HasValue)
                    datepickerOdjava.SelectedDate = datepickerPrijava.SelectedDate.Value.AddDays(1);
                else datepickerOdjava.SelectedDate = termin.MogucaOdjava?.Date;
                this.rezTermin = termin;
                Soba soba = sDal.PronadjiSobu(termin.SobaId);
                if(soba!=null)
                {
                  comboboxTipSobe.SelectedIndex=SelektujTip(soba.TipId);
                    comboboxTipSobe.IsEnabled = false;
                    if (soba.StatusSobe == false)
                    {
                        soba.StatusSobe = null;

                    }                                                         
                    dataGridSobe.Items.Clear();
                    dataGridSobe.Items.Add(soba);
                    dataGridSobe.SelectedIndex = 0;
                }
            }
           
        }
        private void PromeniBoju()
        {
            textboxImeGosta.Tag = "Ime";
            textboxPrezime.Tag = "Prezime";
            textboxJmbg.Tag = "Jmbg";
            textboxKontaktTelefon.Tag = "Telefon";
            textboxEmail.Tag = "Email";
            foreach (var item in grid1.Children)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)item;
                    tb.Foreground = Brushes.Black;
                }
            }

        }
        private bool ValidacijaDatuma()
        {
            if (!datepickerOdjava.SelectedDate.HasValue || !datepickerPrijava.SelectedDate.HasValue)
                return false;

            if(rezTermin!=null)
            {
                if (datepickerPrijava.SelectedDate < rezTermin.MoguceCekiranje.Date)
                {
                    MessageBox.Show("Neispravan datum cekiranja");
                    PocetniDatum(false);
                    return false;
                }

                if (rezTermin.MogucaOdjava.HasValue && datepickerOdjava.SelectedDate > rezTermin.MogucaOdjava?.Date)
                {
                    MessageBox.Show("Neisspravan unos odjave");
                    datepickerPrijava.SelectedDate = rezTermin.MoguceCekiranje;
                    datepickerOdjava.SelectedDate = rezTermin.MogucaOdjava;
                    return false;
                }

                if (datepickerPrijava.SelectedDate >= datepickerOdjava.SelectedDate.Value.Date)
                {
                    MessageBox.Show("Neispravan datum");
                    datepickerPrijava.SelectedDate = rezTermin.MoguceCekiranje;
                    if (rezTermin.MogucaOdjava.HasValue)
                        datepickerOdjava.SelectedDate = rezTermin.MogucaOdjava;

                    else datepickerOdjava.SelectedDate = datepickerPrijava.SelectedDate.Value.AddDays(1);

                    return false;
                }
            }

            else
            {
                if (datepickerPrijava.SelectedDate.Value >= datepickerOdjava.SelectedDate.Value)
                {
                    MessageBox.Show("Neispravan unos datuma");
                    datepickerOdjava.SelectedDate = datepickerPrijava
                        .SelectedDate.Value.AddDays(1);
                    return false;
                }
                if (datepickerPrijava.SelectedDate.Value < DateTime.Today)
                {
                    MessageBox.Show("Min danasnji datum");
                    PocetniDatum(true);
                    return false;
                }
            }
            return true;
           
        }
        private void PrikaziTip()
        {
            comboboxTipSobe.Items.Clear();
            TipSobeDal.VratiTip()?.ForEach(
                t => comboboxTipSobe.Items.Add(t));
        }
        private decimal IzracunajCenu()
        {
            TimeSpan ts = datumOdjave - datumPrijave;

            return (cenaSobe + cenaUsluga) * ts.Days;
        }
        private void FiltrirajSobe(int tipId)
        {
            dataGridSobe.Items.Clear();
            sDal.VratiSlobodne(tipId)?.ForEach(
                s => dataGridSobe.Items.Add(s));
        }
        private void PrikaziUslugu()
        {
            comboBoxUsluga.Items.Clear();
            ObrokDal.VratiObrok()?.ForEach
                (ob => comboBoxUsluga.Items.Add(ob));
        }
        private void PocetniDatum(bool rez)
        {

            if(rez)
            {
                datepickerPrijava.SelectedDate = DateTime.Today;
                datepickerOdjava.SelectedDate =
                    datepickerPrijava.SelectedDate.Value.AddDays(1);

                datumPrijave = DateTime.Today;
                datumOdjave = DateTime.Today.AddDays(1);
            }
            else
            {
                datepickerPrijava.SelectedDate = rezTermin.MoguceCekiranje.Date;
                if (rezTermin.MogucaOdjava.HasValue)
                    datepickerOdjava.SelectedDate = rezTermin.MogucaOdjava;
                else datepickerOdjava.SelectedDate = datepickerPrijava.SelectedDate.Value.AddDays(1);
            }
           
        }  
        private bool Validacija()
        {
            string boja = "#FF808080";
           if(textboxImeGosta.Foreground.ToString()==boja)
            {
                labelImeGosta.Content = "unesite ime";
                textboxImeGosta.Focus();
                return false;
            }
            if (textboxPrezime.Foreground.ToString() == boja)
            {
                labelPrezime.Content = "unesite prezime";
                textboxPrezime.Focus();
                return false;
            }
            if(textboxJmbg.Text.Length!=13)
            {
                labelJmbg.Content = "jmbg mora imati 13 cifara";
                textboxJmbg.Focus();
                return false;
            }
            foreach (char ch in textboxJmbg.Text.ToCharArray())
            {
                if (!char.IsDigit(ch))
                {
                    labelJmbg.Content = "neispravan unos jmbg-a";
                    textboxJmbg.Focus();
                    return false;
                }
            }
            if(textboxKontaktTelefon.Foreground.ToString()==boja)
            {
                labelKontaktTelefon.Content = "unesite telefon";
                textboxKontaktTelefon.Focus();
                return false;
            }
          
            if(dataGridSobe.SelectedIndex<0)
            {
                MessageBox.Show("Selektujte sobu");
                return false;
            }
            if(comboBoxUsluga.SelectedIndex<0)
            {
                MessageBox.Show("Selektujte uslugu");
                return false;
            }
            ////if(!((Soba)dataGridSobe.SelectedItem).StatusSobe)
            ////{
            ////    MessageBox.Show("Soba je zauzeta");
            ////    return false;
            ////}
            return true;
        }
        public int SelektujTip(int id)
        {
            foreach (TipSobe tip in comboboxTipSobe.Items)
            {
                if (tip.TipSobeId == id)
                    return comboboxTipSobe.Items.IndexOf(tip);
            }
            return -1;
        }
        public int SelektujSobu(int sobaId)
        {
            foreach (Soba sb1 in dataGridSobe.Items)
            {
                if(sb1.SobaId==sobaId)
                {
                    return dataGridSobe.Items.IndexOf(sb1);
                }
            }
            
            return -1;
        }
        public int SelektujTip(string naziv)
        {
            foreach (TipSobe tip in comboboxTipSobe.Items)
            {
                if (tip.Tip==naziv)
                    return comboboxTipSobe.Items.IndexOf(tip);
            }
            return -1;
        }
        public int SelektujUslugu(int id)
        {
            foreach (DodatnaUsluga dt in comboBoxUsluga.Items)
            {
                if (dt.UslugaId == id)
                    return comboBoxUsluga.Items.IndexOf(dt);
            }
            return -1;
        }
        private void btnZavrsi_Click(object sender, RoutedEventArgs e)
        {

            if (!Validacija()||!ValidacijaDatuma())
                return;

            DialogResult = true;
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void comboboxTipSobe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxTipSobe.SelectedIndex < 0)
                return;

            TipSobe t = (TipSobe)comboboxTipSobe.SelectedItem;
            FiltrirajSobe(t.TipSobeId);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        private void comboBoxUsluga_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxUsluga.SelectedIndex < 0)
                return;
            cenaUsluga = 0;

            DodatnaUsluga dtu = (DodatnaUsluga)comboBoxUsluga.SelectedItem;
            cenaUsluga = dtu.Cena;
        }

        private void text_gotFocus(object sender, RoutedEventArgs e)
        {
           
            TextBox tb = (TextBox)sender;
            if (tb.Tag != null && tb.Text != tb.Tag.ToString())
                return;
             if (tb.Tag != null && tb.Text == tb.Tag.ToString() && tb.Foreground.ToString() != "#FF808080")      
                return;

            tb.Tag = tb.Text;
            tb.Clear();
            tb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void text_lostFocus(object sender, RoutedEventArgs e)
        {
           
            TextBox tb = (TextBox)sender;
            if (!string.IsNullOrWhiteSpace(tb.Text))
                return;

            tb.Text = tb.Tag.ToString();
            tb.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void text_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            Label labela = null;
           
                foreach (var item in grid1.Children)
                {
                    if (item.GetType() == typeof(Label))
                    {
                         labela = (Label)item;
                        if (labela.Tag != null && labela.Tag.ToString() == tb.Name)
                        {
                        if (labela.Content.ToString() == "")
                            labela.Content = "*";
                        if (tb.Text.Length > 0 && tb.Foreground.ToString() != "#FF808080")
                            labela.Content = ""; 
                        
                        }
                                       
                    }
                }
                      
        }

        private void datepickerPrijava_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {       
            datumPrijave = datepickerPrijava.SelectedDate.Value;
          
        }

        private void datepickerOdjava_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {  
            datumOdjave = datepickerOdjava.SelectedDate.Value;         
        }

        private void buttonCena_Click(object sender, RoutedEventArgs e)
        {
            textboxCena.Text = Math.Round(IzracunajCenu(), 3) + " din";
        }

        private void dataGridSobe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridSobe.SelectedIndex < 0)
                return;

            Soba sb = (Soba)dataGridSobe.SelectedItem;
            cenaSobe = sb.CenaSobePoDanu;
           
        }

      
    }
}
