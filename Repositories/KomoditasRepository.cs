using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using AGRIVA.Models;

namespace AGRIVA.Repositories
{
    public class KomoditasRepository
    {
        public DataTable GetAll()
        {
            const string query = @"SELECT id_komoditas, nama_komoditas, harga_per_kg,
                tgl_update_harga, is_aktif, CASE WHEN is_aktif = 1 THEN 'Aktif' ELSE 'Tidak Aktif' END AS status
                FROM tb_komoditas ORDER BY id_komoditas";
            using (var connection = Koneksi.GetConnection())
            using (var adapter = new SQLiteDataAdapter(query, connection))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }


        public List<Komoditas> GetActive()
        {
            const string query = @"SELECT id_komoditas, nama_komoditas, harga_per_kg,
                tgl_update_harga, is_aktif FROM tb_komoditas WHERE is_aktif = 1 ORDER BY nama_komoditas";
            var result = new List<Komoditas>();
            using (var connection = Koneksi.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Komoditas
                        {
                            IdKomoditas = Convert.ToInt32(reader["id_komoditas"]),
                            NamaKomoditas = reader["nama_komoditas"].ToString(),
                            HargaPerKg = Convert.ToInt32(reader["harga_per_kg"]),
                            TanggalUpdateHarga = reader["tgl_update_harga"] == DBNull.Value ? "" : reader["tgl_update_harga"].ToString(),
                            IsAktif = Convert.ToInt32(reader["is_aktif"])
                        });
                    }
                }
            }
            return result;
        }

        public Komoditas GetById(int id)
        {
            const string query = @"SELECT id_komoditas, nama_komoditas, harga_per_kg,
                tgl_update_harga, is_aktif FROM tb_komoditas WHERE id_komoditas = @id";
            using (var connection = Koneksi.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read()) return null;
                    return new Komoditas
                    {
                        IdKomoditas = Convert.ToInt32(reader["id_komoditas"]),
                        NamaKomoditas = reader["nama_komoditas"].ToString(),
                        HargaPerKg = Convert.ToInt32(reader["harga_per_kg"]),
                        TanggalUpdateHarga = reader["tgl_update_harga"] == DBNull.Value ? "" : reader["tgl_update_harga"].ToString(),
                        IsAktif = Convert.ToInt32(reader["is_aktif"])
                    };
                }
            }
        }

        public void Save(Komoditas komoditas)
        {
            bool isNew = komoditas.IdKomoditas <= 0;
            string query = isNew
                ? @"INSERT INTO tb_komoditas (nama_komoditas, harga_per_kg, tgl_update_harga, is_aktif)
                    VALUES (@nama, @harga, @tanggal, @status)"
                : @"UPDATE tb_komoditas SET nama_komoditas=@nama, harga_per_kg=@harga,
                    tgl_update_harga=@tanggal, is_aktif=@status WHERE id_komoditas=@id";
            using (var connection = Koneksi.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nama", komoditas.NamaKomoditas);
                command.Parameters.AddWithValue("@harga", komoditas.HargaPerKg);
                command.Parameters.AddWithValue("@tanggal", DateTime.Now.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@status", komoditas.IsAktif);
                if (!isNew) command.Parameters.AddWithValue("@id", komoditas.IdKomoditas);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Deactivate(int id)
        {
            const string query = "UPDATE tb_komoditas SET is_aktif = 0 WHERE id_komoditas = @id";
            using (var connection = Koneksi.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
