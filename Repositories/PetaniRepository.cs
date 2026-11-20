using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System;
using AGRIVA.Models;

namespace AGRIVA.Repositories
{
    public class PetaniRepository
    {
        public DataTable GetAll()
        {
            const string query = @"SELECT id_petani, nama_petani, desa, no_telepon,
                luas_lahan_hektar, is_aktif FROM tb_petani ORDER BY id_petani";
            using (var connection = Koneksi.GetConnection())
            using (var adapter = new SQLiteDataAdapter(query, connection))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }


        public List<Petani> GetActive()
        {
            const string query = @"SELECT id_petani, nama_petani, desa, no_telepon,
                luas_lahan_hektar, is_aktif FROM tb_petani WHERE is_aktif = 1 ORDER BY nama_petani";
            var result = new List<Petani>();
            using (var connection = Koneksi.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Petani
                        {
                            IdPetani = Convert.ToInt32(reader["id_petani"]),
                            NamaPetani = reader["nama_petani"].ToString(),
                            Desa = reader["desa"].ToString(),
                            NoTelepon = reader["no_telepon"].ToString(),
                            LuasLahanHektar = Convert.ToDouble(reader["luas_lahan_hektar"]),
                            IsAktif = Convert.ToInt32(reader["is_aktif"])
                        });
                    }
                }
            }
            return result;
        }

        public void Save(Petani petani)
        {
            bool isNew = petani.IdPetani <= 0;
            string query = isNew
                ? @"INSERT INTO tb_petani (nama_petani, desa, no_telepon, luas_lahan_hektar, is_aktif)
                    VALUES (@nama, @desa, @telepon, @luas, @status)"
                : @"UPDATE tb_petani SET nama_petani=@nama, desa=@desa, no_telepon=@telepon,
                    luas_lahan_hektar=@luas, is_aktif=@status WHERE id_petani=@id";
            using (var connection = Koneksi.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nama", petani.NamaPetani);
                command.Parameters.AddWithValue("@desa", petani.Desa);
                command.Parameters.AddWithValue("@telepon", petani.NoTelepon);
                command.Parameters.AddWithValue("@luas", petani.LuasLahanHektar);
                command.Parameters.AddWithValue("@status", petani.IsAktif);
                if (!isNew) command.Parameters.AddWithValue("@id", petani.IdPetani);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Add(Petani petani)
        {
            const string query = @"INSERT INTO tb_petani
                (nama_petani, desa, no_telepon, luas_lahan_hektar, is_aktif)
                VALUES (@nama, @desa, @telepon, @luas, @status)";
            using (var connection = Koneksi.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nama", petani.NamaPetani);
                command.Parameters.AddWithValue("@desa", petani.Desa);
                command.Parameters.AddWithValue("@telepon", petani.NoTelepon);
                command.Parameters.AddWithValue("@luas", petani.LuasLahanHektar);
                command.Parameters.AddWithValue("@status", petani.IsAktif);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
