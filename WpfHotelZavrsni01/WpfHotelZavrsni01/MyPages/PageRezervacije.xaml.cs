using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for PageSobaInfo.xaml
    /// </summary>
    public partial class PageRezervacije : Page
    {
        private RezervacijaDal sbInfoDal = new RezervacijaDal();
        private SobaDal sbDal = new SobaDal();
        private CekiranjeDal ckDal = new CekiranjeDal();
        public PageRezervacije()
        {
            InitializeComponent();
            PrikaziTip();
            PrikaziCekirane();
            comboboxTipSobe.SelectedIndex = 0;
            
        }
        private void PrikaziTip()
        {
            comboboxTipSobe.Items.Clear();
            TipSobeDal.VratiTip()?.ForEach
                (t => comboboxTipSobe.Items.Add(t));
        }
        private void PrikaziCekirane()
        {
            datagridRezervisaneSobe.Items.Clear();
            List<Rezervacija> listaRezervisanih = sbInfoDal.VratiRezervisaneDistinct();
            if (listaRezervisanih != null)
                listaRezervisanih.ForEach(s => datagridRezervisaneSobe.Items.Add(s));
      
        }

       
        private void PrikaziSlobodneTermine(List<RezervacijaTermini> listaSlobodnih,int brojDana=1)
        {
            if (listaSlobodnih == null)
                return;

           // listaSlobodnih.OrderBy(t => t.BrDana);
            listaSlobodnih.Sort();
            dataGridSlobodniTermini.Items.Clear();
            foreach (RezervacijaTermini rz in listaSlobodnih)
            {
                if (rz.BrDana >= brojDana || rz.BrDana == null)
                    dataGridSlobodniTermini.Items.Add(rz);
            }
        }
        private List<RezervacijaTermini> PronadjiSlobodneTermine(int tipId)
        {
            
            List<Soba> listZauzetih = sbDal.VratiZauzete(tipId);
            List<RezervacijaTermini> slobodniTermini = new List<RezervacijaTermini>();

            if (listZauzetih.Count <5)
            {
                List<Soba> listaSlobodni = sbDal.VratiSlobodne(tipId);
                if (listaSlobodni != null)
                {
                    foreach (Soba sobaSlob in listaSlobodni)
                    {
                        slobodniTermini.Add(
                            new RezervacijaTermini
                            {
                                SobaId = sobaSlob.SobaId,
                                MoguceCekiranje = DateTime.Today,
                                MogucaOdjava = null
                            }
                            );
                    }
                }

            }
            

                foreach (Soba sobaZ in listZauzetih)
                {
                                     
                    List<Rezervacija> lista = sbInfoDal.PronadjiRezevacijuById(sobaZ.SobaId);
                    if (lista == null)
                        return null;
                    if (lista.Count== 1)
                    {
                        if (lista[0].DatumCekiranja > DateTime.Today)
                        {
                            slobodniTermini.Add(
                                new RezervacijaTermini
                                {
                                    SobaId = lista[0].SobaId,
                                    MoguceCekiranje = DateTime.Today,
                                    MogucaOdjava = lista[0].DatumCekiranja,
                                });
                        }
                        slobodniTermini.Add(
                   new RezervacijaTermini
                   {
                       SobaId = lista[0].SobaId,
                       MoguceCekiranje = lista[0].DatumOdjave,
                       MogucaOdjava = null
                   });

                    }
                    else if(lista.Count>1)
                    {
                        if (lista[0].DatumCekiranja > DateTime.Today)
                        {
                            slobodniTermini.Add(
                                new RezervacijaTermini
                                {
                                    SobaId = lista[0].SobaId,
                                    MoguceCekiranje = DateTime.Today,
                                    MogucaOdjava = lista[0].DatumCekiranja
                                });
                        }

                        for (int i = 0; i < lista.Count - 1; i++)
                        {
                            slobodniTermini.Add(
                                new RezervacijaTermini
                                {
                                    SobaId = lista[i].SobaId,
                                    MoguceCekiranje = lista[i].DatumOdjave,
                                    MogucaOdjava = lista[i + 1].DatumCekiranja
                                });
                        }

                        slobodniTermini.Add(new RezervacijaTermini
                        {
                            SobaId = lista[lista.Count - 1].SobaId,
                            MoguceCekiranje = lista[lista.Count - 1]
                      .DatumOdjave,
                            MogucaOdjava = null
                        });
                    }
                }
            

            return slobodniTermini;
        }      
        private void buttonPretrazi_Click(object sender, RoutedEventArgs e)
        {
            if (comboboxTipSobe.SelectedIndex < 0)
                return;

            TipSobe tip = (TipSobe)comboboxTipSobe.SelectedItem;
            int brojDana;

            if (int.TryParse(textboxBrojDana.Text, out brojDana) && brojDana > 0)
            {
                PrikaziSlobodneTermine(PronadjiSlobodneTermine(tip.TipSobeId), brojDana);
            }
            else
            {
                MessageBox.Show("neispravan unos");
                textboxBrojDana.Clear();
                textboxBrojDana.Focus();
            }

        }
        private void comboboxTipSobe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxTipSobe.SelectedIndex < 0)
                return;

            TipSobe tip = (TipSobe)comboboxTipSobe.SelectedItem;
            PrikaziSlobodneTermine(PronadjiSlobodneTermine(tip.TipSobeId));
           
        }

        private void buttonRezervisi_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridSlobodniTermini.SelectedIndex<0)
            {
                MessageBox.Show("Selektujte termin");
                return;
            }


            RezervacijaTermini rz = (RezervacijaTermini)dataGridSlobodniTermini.SelectedItem;
            WindowCekiranje w1 = new WindowCekiranje(rz);
            w1.Title = "Rezervacija";
            if (w1.ShowDialog() == true)
            {
                if (ckDal.InsertInto(w1.CekiranjeProp))
                {
                    MessageBox.Show("Cekiranje uspesno");
                    TipSobe tip = (TipSobe)w1.comboboxTipSobe.SelectedItem;
                    PrikaziSlobodneTermine(PronadjiSlobodneTermine(tip.TipSobeId));
                    PrikaziCekirane();
                }
                else MessageBox.Show("Greska");
            }
            
        }
    }
}
