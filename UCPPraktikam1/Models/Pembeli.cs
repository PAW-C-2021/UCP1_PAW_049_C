using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UCPPraktikam1.Models
{
    public partial class Pembeli
    {
        public Pembeli()
        {
            Transaksi = new HashSet<Transaksi>();
        }

        public int Idpembeli { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<Transaksi> Transaksi { get; set; }
    }
}
