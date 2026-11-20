using System;

namespace AGRIVA.Models
{
    /// <summary>Representasi satu transaksi penerimaan hasil panen.</summary>
    public class Panen
    {
        public int IdPanen { get; set; }
        public string NoTransaksi { get; set; }
        public DateTime TanggalMasuk { get; set; }
        public int IdPetani { get; set; }
        public int IdKomoditas { get; set; }
        public int IdKualitas { get; set; }
        public int IdPetugas { get; set; }
        public int IdStatusBarang { get; set; }
        public double BeratKg { get; set; }
        public double HargaSaatTransaksi { get; set; }
        public double PersenPenalti { get; set; }
        public double TotalUang { get; set; }
    }
}
