using System;
using System.Collections.Generic;
using System.Data.SQLite;
using AGRIVA.Models;

namespace AGRIVA.Repositories
{
    /// <summary>Akses data master kualitas dari SQLite.</summary>
    public class KualitasRepository
    {
        public List<Kualitas> GetAll()
        {
            const string sql = @"SELECT id_kualitas, nama_kualitas, persen_penalti
FROM tb_kualitas ORDER BY id_kualitas";
            var result = new List<Kualitas>();
            using (var connection = Koneksi.GetConnection())
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Kualitas
                        {
                            IdKualitas = Convert.ToInt32(reader["id_kualitas"]),
                            NamaKualitas = reader["nama_kualitas"].ToString(),
                            PersenPenalti = Convert.ToDouble(reader["persen_penalti"])
                        });
                    }
                }
            }
            return result;
        }
    }
}
