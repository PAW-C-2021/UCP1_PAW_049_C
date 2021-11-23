using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UCPPraktikam1.Models
{
    public partial class Pembayaran
    {
        public int Idpembayaran { get; set; }
        public int? Idtranksaksi { get; set; }
        public int? Totalembayaran { get; set; }

        public virtual Transaksi IdtranksaksiNavigation { get; set; }
    }
}
