﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHotelZavrsni01
{
    class TipSobe
    {
        public int TipSobeId { get; set; }
        public string Tip { get; set; }
        public string Opis { get; set; }

        public override string ToString()
        {
            return Tip;
        }
    }
}
