using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHotelZavrsni01
{
  public class CekiranjeView
    {
        public int CekiranjeId { get; set; }
        public string Gost { get; set; }
        public string VrstaSobe { get; set; }
        public DateTime DatumCekiranja { get; set; }
        public DateTime DatumOdlaska { get; set; }

        public int SobaId { get; set; }
        public int UslugaId { get; set; }


        public string CekiranjeDatum
        {
            get { return DatumCekiranja.ToString("dd.MM.yyyy"); }
        }
        public string OdlazakDatum
        {
            get { return DatumOdlaska.ToString("dd.MM.yyyy"); }
        }
    }
}
