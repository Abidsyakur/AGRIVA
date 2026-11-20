namespace AGRIVA.Models
{
    /// <summary>Data akun pengguna aplikasi.</summary>
    public class Pengguna
    {
        public int IdPengguna { get; set; }
        public string NamaLengkap { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Peran { get; set; }
        public int IdRole { get; set; }
        public int IsAktif { get; set; }
    }
}
