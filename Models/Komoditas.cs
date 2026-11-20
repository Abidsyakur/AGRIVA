namespace AGRIVA.Models
{
    public class Komoditas
    {
        public int IdKomoditas { get; set; }
        public string NamaKomoditas { get; set; }
        public int HargaPerKg { get; set; }
        public string TanggalUpdateHarga { get; set; }
        public int IsAktif { get; set; }
    }
}
