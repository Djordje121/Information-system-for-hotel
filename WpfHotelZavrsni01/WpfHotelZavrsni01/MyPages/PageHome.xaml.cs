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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class PageHome : Page
    {    
        private RezervacijaDal rezDal = new RezervacijaDal();
        public PageHome()
        {
            InitializeComponent();
            Prikazi();
        }
      
        private void Prikazi()
        {
           StringBuilder sb = new StringBuilder();
            int oneBed= rezDal.VratiBrojSlobodnih(1);
            int twoBed= rezDal.VratiBrojSlobodnih(2);
            int treeBed=rezDal.VratiBrojSlobodnih(3);
            int apartmans= rezDal.VratiBrojSlobodnih(4);
            ;
            sb.AppendLine("Jedonokrevetne");
            sb.AppendLine($"br.slobodnih : {oneBed}\n");
            sb.AppendLine("Dvokrevetne");
            sb.AppendLine($"br.slobodnih : {twoBed}\n");
            sb.AppendLine("Trokrevetne");
            sb.AppendLine($"br. slobodnih : {treeBed}\n");
            sb.AppendLine("Apartmani");
            sb.AppendLine($"br. slobodnih : {apartmans}\n");



            textboxStatus.Text = sb.ToString();
        }
        
    }
}
