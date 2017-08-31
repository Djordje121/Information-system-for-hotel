using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHotelZavrsni01
{
    class Rezervacija
    {

        public int RezervacijaId { get; set; }
        public int SobaId { get; set; }
        public DateTime DatumCekiranja { get; set; }
        public DateTime DatumOdjave { get; set; }

        public string CekiranjeFormat
        {
            get { return DatumCekiranja.ToString("dd.MM.yyyy"); }
        }
        public string OdjavaFormat
        {
            get { return DatumOdjave.ToString("dd.MM.yyyy"); }
        }

    }
}
