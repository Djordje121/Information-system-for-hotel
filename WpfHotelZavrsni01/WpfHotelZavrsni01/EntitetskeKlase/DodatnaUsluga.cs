using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHotelZavrsni01
{
    class DodatnaUsluga
    {
        public int UslugaId { get; set; }
        public string NazivUsluge { get; set; }
        public decimal Cena { get; set; }

        public override string ToString()
        {
            return NazivUsluge;
        }
    }
}
