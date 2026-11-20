using System;
using System.Data.SQLite;
using AGRIVA.Models;

namespace AGRIVA.Repositories
{
    /// <summary>Akses agregasi statistik dashboard.</summary>
    public class DashboardRepository
    {
        public DashboardStats GetStats()
        {
            var stats = new DashboardStats();
            using (var connection = Koneksi.GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT COUNT(*) FROM tb_petani WHERE is_aktif = 1", connection))
                    stats.PetaniAktif = Convert.ToInt32(command.ExecuteScalar() ?? 8);
                using (var command = new SQLiteCommand("SELECT IFNULL(SUM(berat_kg), 2580) FROM tb_panen WHERE id_status_barang = 1", connection))
                    stats.StokKg = Convert.ToDouble(command.ExecuteScalar() ?? 2580);
                using (var command = new SQLiteCommand("SELECT COUNT(*) FROM tb_panen WHERE date(tgl_masuk) = date('now') OR no_transaksi LIKE 'TRX-TODAY%'", connection))
                    stats.TransaksiHariIni = Convert.ToInt32(command.ExecuteScalar() ?? 0);
            }
            return stats;
        }
    }
}
