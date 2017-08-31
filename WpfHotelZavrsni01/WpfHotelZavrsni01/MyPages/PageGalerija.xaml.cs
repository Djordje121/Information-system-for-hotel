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
using System.IO;
using Microsoft.Win32;

namespace WpfHotelZavrsni01
{
    /// <summary>
    /// Interaction logic for PageGalerija.xaml
    /// </summary>
    public partial class PageGalerija : Page
    {
        private SlikaSobeDal sbDal = new SlikaSobeDal();
        private string odabranaSlika = string.Empty;
        private int wpIndex = -1;
        public PageGalerija()
        {
            InitializeComponent();
            PrikaziTipSobe();

            PrikaziSlike(1);
            Selektuj(0);
            if(comboboxTipSobe.Items.Count>0)
            comboboxTipSobe.SelectedIndex = 0;
        }
        private void Selektuj(int index)
        {
            Image img1 = null;
            foreach (Image img in wrap1.Children)
            {
                if (wrap1.Children.IndexOf(img) == index)
                    img1 = img;
            }
            if (img1 != null)
              imgBorder.Source= SlikaConverter.ConvertToBitmap(((SlikaSobe)img1.Tag).SlikaBin);
        }
        private void PrikaziSlike(int tipId=0)
        {
            List<SlikaSobe> lista = null;
            if (tipId > 0)
                lista = sbDal.FiltrirajSlike(tipId);

            else if(tipId==0)
              lista = sbDal.ReturnSelect();


            if (lista!=null)
            {
                wrap1.Children.Clear();
              
                Image img = null;
                for(int i=0;i<lista.Count;i++)
                { 
                    img = new Image();
                    img.Width = 100;
                    img.Stretch = Stretch.Fill;
                    img.Margin = new Thickness(5);
                    img.Source = SlikaConverter.ConvertToBitmap(lista[i].SlikaBin);
                    wrap1.Children.Add(img);
                 
                    img.Tag = lista[i];
                    img.MouseDown += Img_MouseDown;
                }

              
            }
           
        }

        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image im = (Image)sender;
            SlikaSobe sb =(SlikaSobe) im.Tag;
            imgBorder.Source = SlikaConverter.ConvertToBitmap(sb.SlikaBin);
            wpIndex = wrap1.Children.IndexOf(im);
        }

        private void PrikaziTipSobe()
        {
            comboboxTipSobe.Items.Clear();
            TipSobeDal.VratiTip()?.ForEach(t => comboboxTipSobe.Items.Add(t));
        }
        private void buttonDodajSliku_Click(object sender, RoutedEventArgs e)
        {
            SlikaSobe slika = new SlikaSobe();
            TipSobe t = (TipSobe)comboboxTipSobe.SelectedItem;
            slika.TipSobeId = t.TipSobeId;
            OpenFileDialog opnDig = new OpenFileDialog();
            opnDig.InitialDirectory = Environment.CurrentDirectory;
            if(opnDig.ShowDialog()==true)
            {
                odabranaSlika = opnDig.FileName;
                imgBorder.Source = new BitmapImage(new Uri(odabranaSlika));
                slika.SlikaBin = SlikaConverter.ConvertToByte(odabranaSlika);
                if(sbDal.InsertInto(slika))
                {
                    MessageBox.Show("Slika ubacena");
                    PrikaziSlike(slika.TipSobeId);
                }
            }
          
        }

        private void comboboxTipSobe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxTipSobe.SelectedIndex < 0)
                return;

            TipSobe tip = (TipSobe)comboboxTipSobe.SelectedItem;
            PrikaziSlike(tip.TipSobeId);
            Selektuj(0);
        }

        private void buttonPromeniSliku_Click(object sender, RoutedEventArgs e)
        {
            if(wpIndex<0)
            {
                MessageBox.Show("Selektujte sliku");
                return;
            }
           Image img=(Image)wrap1.Children[wpIndex];

            SlikaSobe slika =(SlikaSobe) img.Tag;

            if (sbDal.Update(slika))
            {
                TipSobe t = (TipSobe)comboboxTipSobe.SelectedItem;
                slika.TipSobeId = t.TipSobeId;
                OpenFileDialog opnDig = new OpenFileDialog();
                opnDig.InitialDirectory = Environment.CurrentDirectory;
                if (opnDig.ShowDialog() == true)
                {
                    odabranaSlika = opnDig.FileName;
                    imgBorder.Source = new BitmapImage(new Uri(odabranaSlika));
                    slika.SlikaBin = SlikaConverter.ConvertToByte(odabranaSlika);
                    if (sbDal.Update(slika))
                    {                        
                        PrikaziSlike(slika.TipSobeId);
                        Selektuj(wpIndex);
                        MessageBox.Show("Slika uspesno izmenjena");
                    }
                }

            }
            else MessageBox.Show("doslo je do greske prilikom promene");
            
        }

        private void buttonIzbrisiSliku_Click(object sender, RoutedEventArgs e)
        {
            if (wpIndex < 0)
            {
                MessageBox.Show("Selektujte sliku");
                return;
            }
            Image img = (Image)wrap1.Children[wpIndex];

            SlikaSobe slika = (SlikaSobe)img.Tag;

            if (sbDal.Delete(slika))
            {
                wpIndex = -1;
                imgBorder.Source = null;
                PrikaziSlike(slika.TipSobeId);
                MessageBox.Show("Slika uspesno obrisana");
               

            }
            else MessageBox.Show("doslo je do greske prilikom brisanja");

        }
    }
}
