using System;
using System.Data;
using System.Data.SQLite;
using AGRIVA.Models;

namespace AGRIVA.Repositories
{
    /// <summary>Akses data transaksi panen pada SQLite.</summary>
    public class PanenRepository
    {
        public void Insert(Panen panen)
        {
            if (panen == null) throw new ArgumentNullException("panen");

            const string sql = @"
INSERT INTO tb_panen
(no_transaksi, tgl_masuk, id_petani, id_komoditas, id_kualitas,
 id_petugas, id_status_barang, berat_kg, harga_saat_transaksi,
 persen_penalti, total_uang)
VALUES
(@no, datetime('now', 'localtime'), @petani, @komoditas, @kualitas,
 @petugas, @status, @berat, @harga, @penalti, @total)";

            using (var connection = Koneksi.GetConnection())
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@no", panen.NoTransaksi);
                command.Parameters.AddWithValue("@petani", panen.IdPetani);
                command.Parameters.AddWithValue("@komoditas", panen.IdKomoditas);
                command.Parameters.AddWithValue("@kualitas", panen.IdKualitas);
                command.Parameters.AddWithValue("@petugas", panen.IdPetugas);
                command.Parameters.AddWithValue("@status", panen.IdStatusBarang);
                command.Parameters.AddWithValue("@berat", panen.BeratKg);
                command.Parameters.AddWithValue("@harga", panen.HargaSaatTransaksi);
                command.Parameters.AddWithValue("@penalti", panen.PersenPenalti);
                command.Parameters.AddWithValue("@total", panen.TotalUang);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable GetAllForSetoran()
        {
            const string sql = @"SELECT p.tgl_masuk, pt.nama_petani, k.nama_komoditas,
q.nama_kualitas, p.berat_kg, pg.username, p.no_transaksi
FROM tb_panen p
JOIN tb_petani pt ON p.id_petani = pt.id_petani
JOIN tb_komoditas k ON p.id_komoditas = k.id_komoditas
JOIN tb_kualitas q ON p.id_kualitas = q.id_kualitas
JOIN tb_pengguna pg ON p.id_petugas = pg.id_pengguna
ORDER BY p.id_panen DESC";
            using (var connection = Koneksi.GetConnection())
            using (var adapter = new SQLiteDataAdapter(sql, connection))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
        public DataTable GetAllForMuatan()
        {
            const string sql = @"SELECT p.id_panen, k.nama_komoditas, pt.nama_petani,
q.nama_kualitas, p.berat_kg, p.tgl_masuk, sb.nama_status
FROM tb_panen p
JOIN tb_petani pt ON p.id_petani = pt.id_petani
JOIN tb_komoditas k ON p.id_komoditas = k.id_komoditas
JOIN tb_kualitas q ON p.id_kualitas = q.id_kualitas
JOIN tb_status_barang sb ON p.id_status_barang = sb.id_status_barang
WHERE p.id_status_barang = 1 OR sb.nama_status = 'Di Gudang' OR sb.nama_status = 'Belum Muat'
ORDER BY p.id_panen DESC";
            using (var connection = Koneksi.GetConnection())
            using (var adapter = new SQLiteDataAdapter(sql, connection))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable GetAllForLaporan()
        {
            const string sql = @"SELECT p.id_panen, p.tgl_masuk, pt.nama_petani,
k.nama_komoditas, p.berat_kg, p.total_uang, sb.nama_status
FROM tb_panen p
JOIN tb_petani pt ON p.id_petani = pt.id_petani
JOIN tb_komoditas k ON p.id_komoditas = k.id_komoditas
JOIN tb_status_barang sb ON p.id_status_barang = sb.id_status_barang
ORDER BY p.id_panen DESC";
            using (var connection = Koneksi.GetConnection())
            using (var adapter = new SQLiteDataAdapter(sql, connection))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void UpdateStatus(int idPanen, int idStatusBarang)
        {
            const string sql = "UPDATE tb_panen SET id_status_barang = @status WHERE id_panen = @id";
            using (var connection = Koneksi.GetConnection())
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@status", idStatusBarang);
                command.Parameters.AddWithValue("@id", idPanen);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateStatusBatch(System.Collections.Generic.IEnumerable<int> ids, int idStatusBarang)
        {
            if (ids == null) throw new ArgumentNullException("ids");
            using (var connection = Koneksi.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                using (var command = new SQLiteCommand("UPDATE tb_panen SET id_status_barang = @status WHERE id_panen = @id", connection, transaction))
                {
                    var statusParameter = command.Parameters.Add("@status", System.Data.DbType.Int32);
                    var idParameter = command.Parameters.Add("@id", System.Data.DbType.Int32);
                    statusParameter.Value = idStatusBarang;
                    foreach (int id in ids)
                    {
                        idParameter.Value = id;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

    }
}
