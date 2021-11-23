using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UCPPraktikam1.Models
{
    public partial class Transaksi
    {
        public Transaksi()
        {
            Pembayaran = new HashSet<Pembayaran>();
        }

        public int Idtransaksi { get; set; }
        public int? Idsapi { get; set; }
        public int? Idpembeli { get; set; }
        public int? Jumlahsapi { get; set; }
        public DateTime? Tgltransaksi { get; set; }

        public virtual Pembeli IdpembeliNavigation { get; set; }
        public virtual Sapi IdsapiNavigation { get; set; }
        public virtual ICollection<Pembayaran> Pembayaran { get; set; }
    }
}
