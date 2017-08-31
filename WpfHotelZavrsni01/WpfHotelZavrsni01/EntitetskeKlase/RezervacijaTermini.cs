using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHotelZavrsni01
{
   public class RezervacijaTermini:IComparable<RezervacijaTermini>
    {
        public int SobaId { get; set; }
        public DateTime MoguceCekiranje { get; set; }
        public DateTime? MogucaOdjava { get; set; }
        private int? brDana;

        public int? BrDana
        {
            get
            {
                TimeSpan ts = new TimeSpan(12, 00, 00);
                MoguceCekiranje = MoguceCekiranje.Date + ts;
                if (MogucaOdjava != null)
                {
                    MogucaOdjava = MogucaOdjava?.Date + ts;
                    return (MogucaOdjava - MoguceCekiranje)?.Days;
                }
                else return null;
              
            }
            set { brDana = value; }
        }

        public int CompareTo(RezervacijaTermini other)
        {
            return MoguceCekiranje.CompareTo(other.MoguceCekiranje);
        }

        public string CekiranjeFormat
        {
            get {
                if (MoguceCekiranje.Date == DateTime.Today)
                    return "danas";
                return MoguceCekiranje.ToString("dd.MM.yyyy");
            }
        }

        public string OdjavaFormat
        {
            get {if (this.MogucaOdjava != null)
                    return MogucaOdjava?.ToString("dd.MM.yyyy");
                else return "uvek dostupno"; }
        }

        public string BrojDanaFormat
        {
            get { if (this.BrDana.HasValue)
                    return this.BrDana.ToString();

                else return "neodredjeno"; }
        }

    }
}
