using System;
using System.Data;
using System.Data.SQLite;
using AGRIVA.Models;

namespace AGRIVA.Repositories
{
    /// <summary>Akses data akun pengguna pada SQLite.</summary>
    public class PenggunaRepository
    {
        public Pengguna GetByUsername(string username)
        {
            const string sql = @"SELECT id_pengguna, nama_lengkap, username, peran, id_role, is_aktif, password_hash
FROM tb_pengguna WHERE username=@username COLLATE NOCASE LIMIT 1";
            using (var connection = Koneksi.GetConnection())
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read()) return null;
                    return new Pengguna
                    {
                        IdPengguna = Convert.ToInt32(reader["id_pengguna"]),
                        NamaLengkap = Convert.ToString(reader["nama_lengkap"]),
                        Username = Convert.ToString(reader["username"]),
                        Peran = Convert.ToString(reader["peran"]),
                        IdRole = Convert.ToInt32(reader["id_role"]),
                        IsAktif = Convert.ToInt32(reader["is_aktif"]),
                        PasswordHash = Convert.ToString(reader["password_hash"])
                    };
                }
            }
        }

        public DataTable GetAll()
        {
            const string sql = @"SELECT id_pengguna, COALESCE(nama_lengkap, username), username,
COALESCE(peran, 'Admin'), is_aktif FROM tb_pengguna ORDER BY id_pengguna ASC";
            using (var connection = Koneksi.GetConnection())
            using (var adapter = new SQLiteDataAdapter(sql, connection))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Add(Pengguna pengguna)
        {
            if (pengguna == null) throw new ArgumentNullException("pengguna");
            const string sql = @"INSERT INTO tb_pengguna
(nama_lengkap, username, peran, id_role, is_aktif, password_hash)
VALUES (@nama, @username, @peran, @role, @aktif, @password)";
            Execute(sql, pengguna, false);
        }

        public void Update(Pengguna pengguna)
        {
            if (pengguna == null) throw new ArgumentNullException("pengguna");
            const string sql = @"UPDATE tb_pengguna SET nama_lengkap=@nama, username=@username,
peran=@peran, id_role=@role, is_aktif=@aktif WHERE id_pengguna=@id";
            Execute(sql, pengguna, true);
        }

        private void Execute(string sql, Pengguna pengguna, bool includeId)
        {
            using (var connection = Koneksi.GetConnection())
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@nama", pengguna.NamaLengkap);
                command.Parameters.AddWithValue("@username", pengguna.Username);
                command.Parameters.AddWithValue("@peran", pengguna.Peran);
                command.Parameters.AddWithValue("@role", pengguna.IdRole);
                command.Parameters.AddWithValue("@aktif", pengguna.IsAktif);
                if (!includeId) command.Parameters.AddWithValue("@password", PasswordHasher.Hash("12345"));
                if (includeId) command.Parameters.AddWithValue("@id", pengguna.IdPengguna);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
