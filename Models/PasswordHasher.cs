using System;
using System.Security.Cryptography;

namespace AGRIVA.Models
{
    /// <summary>Membuat dan memverifikasi hash kata sandi dengan PBKDF2.</summary>
    public static class PasswordHasher
    {
        private const int Iterations = 100000;
        private const int SaltSize = 16;
        private const int HashSize = 32;

        public static string Hash(string password)
        {
            if (password == null) throw new ArgumentNullException("password");
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(salt);
            byte[] hash;
            using (var derive = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
                hash = derive.GetBytes(HashSize);
            return "PBKDF2-SHA256$" + Iterations + "$" + Convert.ToBase64String(salt) + "$" + Convert.ToBase64String(hash);
        }

        public static bool Verify(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storedHash)) return false;
            try
            {
                string[] parts = storedHash.Split('$');
                if (parts.Length != 4 || parts[0] != "PBKDF2-SHA256") return false;
                int iterations = int.Parse(parts[1]);
                byte[] salt = Convert.FromBase64String(parts[2]);
                byte[] expected = Convert.FromBase64String(parts[3]);
                byte[] actual;
                using (var derive = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
                    actual = derive.GetBytes(expected.Length);
                if (actual.Length != expected.Length) return false;
                int diff = 0;
                for (int i = 0; i < actual.Length; i++) diff |= actual[i] ^ expected[i];
                return diff == 0;
            }
            catch { return false; }
        }
    }
}
