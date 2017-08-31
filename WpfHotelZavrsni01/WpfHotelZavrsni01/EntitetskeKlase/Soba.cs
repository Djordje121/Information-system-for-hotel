using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHotelZavrsni01
{
    class Soba
    {
        public int SobaId { get; set; }
        public string BrojSobe { get; set; }
        public int Sprat { get; set; }
        public bool? StatusSobe { get; set; }
        public int TipId { get; set; }     
        public decimal CenaSobePoDanu { get; set; }


        public string VratiStatus
        {
            get
            {
                if (StatusSobe == true)
                    return "slobodna";
                else if (StatusSobe == false)
                    return "zauzeta";
                else return "rezervisana";
            }

           
        }

    }
}
