using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UCPPraktikam1.Models
{
    public partial class Sapi
    {
        public Sapi()
        {
            Transaksi = new HashSet<Transaksi>();
        }

        public int IdSapi { get; set; }
        public string NamaSapi { get; set; }
        public int? Stocksapi { get; set; }
        public int? HargaSapi { get; set; }

        public virtual ICollection<Transaksi> Transaksi { get; set; }
    }
}
