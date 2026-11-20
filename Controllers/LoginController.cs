using AGRIVA.Models;
using AGRIVA.Repositories;

namespace AGRIVA.Controllers
{
    /// <summary>Validasi autentikasi akun AGRIVA.</summary>
    public class LoginController
    {
        private readonly PenggunaRepository repository;
        public LoginController() : this(new PenggunaRepository()) { }
        public LoginController(PenggunaRepository repository) { this.repository = repository; }

        public Pengguna Masuk(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password)) return null;
            Pengguna pengguna = repository.GetByUsername(username.Trim());
            if (pengguna == null || pengguna.IsAktif != 1) return null;
            return PasswordHasher.Verify(password, pengguna.PasswordHash) ? pengguna : null;
        }
    }
}
