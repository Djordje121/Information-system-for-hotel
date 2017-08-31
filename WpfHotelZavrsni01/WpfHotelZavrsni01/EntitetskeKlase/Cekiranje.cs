using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHotelZavrsni01
{
    class Cekiranje
    {
        public int CekiranjeId { get; set; }
        public int GostId { get; set; }
        public int SobaId { get; set; }
        public int UslugaId { get; set; }
        public DateTime DatumCekiranja { get; set; }
        public DateTime DatumOdjave { get; set; }
        public decimal UkupnaCenaPoDanu { get; set; }


        private Gost gostProp=new Gost();
        public Gost GostProp
        {
            get { return gostProp; }
            set { gostProp = value; }
        }

    }
}
