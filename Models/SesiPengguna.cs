namespace AGRIVA.Models
{
    /// <summary>Menyimpan identitas akun yang sedang masuk selama aplikasi berjalan.</summary>
    public static class SesiPengguna
    {
        public static Pengguna SaatIni { get; set; }
        public static void Akhiri() { SaatIni = null; }
    }
}
