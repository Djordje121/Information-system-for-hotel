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
    /// Interaction logic for PageCekiranje.xaml
    /// </summary>
    public partial class PageCekiranje : Page
    {
        public  CekiranjeView ckView { get; set; }
        public PageCekiranje()
        {
            InitializeComponent();
            PrikaziCekiranja();
            
        }
        public void PrikaziCekiranja(string ime="")
        {
            datagridCekiranja.Items.Clear();
            CekiranjeViewDal.VratiView(ime)?.ForEach(ck => datagridCekiranja.Items.Add(ck));
        }

        private void datagridCekiranja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagridCekiranja.SelectedIndex < 0)
                return;

            this.ckView =(CekiranjeView)datagridCekiranja.SelectedItem;
        }

        
    }
}
