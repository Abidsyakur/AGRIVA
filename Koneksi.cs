using System;
using System.Data.SQLite;
using System.IO;

namespace AGRIVA
{
    public class Koneksi
    {
        private static string dbPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "agriva.db");

        private static string connectionString =
            "Data Source=" + dbPath + ";Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void InitializeDatabase()
        {
            try
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();

                    string createTables = @"
CREATE TABLE IF NOT EXISTS tb_petani (
    id_petani INTEGER PRIMARY KEY AUTOINCREMENT,
    nama_petani TEXT NOT NULL,
    desa TEXT NOT NULL,
    no_telepon TEXT NOT NULL,
    luas_lahan_hektar REAL NOT NULL,
    is_aktif INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_komoditas (
    id_komoditas INTEGER PRIMARY KEY AUTOINCREMENT,
    nama_komoditas TEXT NOT NULL UNIQUE,
    harga_per_kg INTEGER NOT NULL,
    tgl_update_harga DATETIME,
    is_aktif INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_kualitas (
    id_kualitas INTEGER PRIMARY KEY AUTOINCREMENT,
    nama_kualitas TEXT NOT NULL,
    persen_penalti REAL NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_status_barang (
    id_status_barang INTEGER PRIMARY KEY,
    nama_status TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_status_bayar (
    id_status_bayar INTEGER PRIMARY KEY,
    nama_status TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_pengguna (
    id_pengguna INTEGER PRIMARY KEY AUTOINCREMENT,
    nama_lengkap TEXT,
    username TEXT NOT NULL,
    peran TEXT,
    id_role INTEGER NOT NULL,
    is_aktif INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS tb_panen (
    id_panen INTEGER PRIMARY KEY AUTOINCREMENT,
    no_transaksi TEXT NOT NULL,
    tgl_masuk DATETIME NOT NULL,
    id_petani INTEGER NOT NULL,
    id_komoditas INTEGER NOT NULL,
    id_kualitas INTEGER NOT NULL,
    id_petugas INTEGER NOT NULL,
    id_status_barang INTEGER NOT NULL,
    id_status_bayar INTEGER NOT NULL,
    berat_kg REAL NOT NULL,
    harga_saat_transaksi REAL NOT NULL,
    persen_penalti REAL NOT NULL,
    total_uang REAL NOT NULL
);";

                    using (SQLiteCommand cmd = new SQLiteCommand(createTables, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Seed data master
                    string seedMaster = @"
INSERT OR IGNORE INTO tb_kualitas (id_kualitas, nama_kualitas, persen_penalti) VALUES 
(1, 'Grade A', 0),
(2, 'Grade B', 5),
(3, 'Grade C', 10);

INSERT OR REPLACE INTO tb_status_barang (id_status_barang, nama_status) VALUES 
(1, 'Di Gudang'),
(2, 'Terkirim'),
(3, 'Dibatalkan');

INSERT OR REPLACE INTO tb_status_bayar (id_status_bayar, nama_status) VALUES 
(1, 'Belum Bayar'),
(2, 'Sudah Bayar');

                    INSERT OR IGNORE INTO tb_pengguna (id_pengguna, nama_lengkap, username, peran, id_role, is_aktif) VALUES 
(1, 'Bu Rani', 'rani', 'Admin', 1, 0),
(2, 'Bu Sri', 'sridayanti', 'Petugas Gudang', 2, 1),
(3, 'Pak Joko', 'joko_supir', 'Supir', 3, 1),
(4, 'Pak Slamet Riyadi', 'riyad', 'Admin', 1, 1);
";
                    using (SQLiteCommand cmd = new SQLiteCommand(seedMaster, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Seed data petani contoh (sesuai Figma) jika kosong
                    using (SQLiteCommand checkPetani = new SQLiteCommand("SELECT COUNT(*) FROM tb_petani", conn))
                    {
                        long count = (long)checkPetani.ExecuteScalar();
                        if (count == 0)
                        {
                            string seedPetani = @"
INSERT INTO tb_petani (nama_petani, desa, no_telepon, luas_lahan_hektar, is_aktif) VALUES
('Bu Siti Rahayu', 'Sukamaju', '0813-2233-4455', 0.8, 0),
('Bu Wartini', 'Cibeureum', '0821-5566-7788', 0.6, 1),
('Pak Ahmad Fauzi', 'Karanganyar', '0857-9988-7766', 1.2, 1),
('Pak Joko Santoso', 'Cibeureum', '0852-1122-3344', 2.0, 1),
('Pak Subardi', 'Sukamaju', '0812-3456-7810', 1.5, 0),
('Bu Ratna Dewi', 'Sukamaju', '0815-7788-9900', 1.0, 1),
('Pak Bambang Wijaya', 'Karanganyar', '0813-8899-0011', 1.8, 1),
('Pak Hendra Gunawan', 'Cibeureum', '0822-4455-6677', 2.5, 1);
";
                            using (SQLiteCommand cmd = new SQLiteCommand(seedPetani, conn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // Seed data komoditas contoh (sesuai Figma: Jagung, Kedelai, Kopi, Padi, Cabai Rawit Merah, Bawang Putih)
                    using (SQLiteCommand checkKomoditas = new SQLiteCommand("SELECT COUNT(*) FROM tb_komoditas", conn))
                    {
                        long count = (long)checkKomoditas.ExecuteScalar();
                        if (count <= 5)
                        {
                            string seedKomoditas = @"
DELETE FROM tb_komoditas;
INSERT INTO tb_komoditas (id_komoditas, nama_komoditas, harga_per_kg, tgl_update_harga, is_aktif) VALUES
(1, 'Jagung', 5200, '2022-01-20', 0),
(2, 'Kedelai', 9800, '2019-05-17', 1),
(3, 'Kopi', 42000, '2024-09-08', 1),
(4, 'Padi', 6500, '2021-06-29', 1),
(5, 'Cabai Rawit Merah', 45000, '2025-03-22', 0),
(6, 'Bawang Putih', 25000, '2025-11-30', 1);
";
                            using (SQLiteCommand cmd = new SQLiteCommand(seedKomoditas, conn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // Seed data panen contoh jika kosong / kurang
                    using (SQLiteCommand checkPanen = new SQLiteCommand("SELECT COUNT(*) FROM tb_panen", conn))
                    {
                        long count = (long)checkPanen.ExecuteScalar();
                        if (count <= 4)
                        {
                            string seedPanen = @"
DELETE FROM tb_panen;
INSERT INTO tb_panen (no_transaksi, tgl_masuk, id_petani, id_komoditas, id_kualitas, id_petugas, id_status_barang, id_status_bayar, berat_kg, harga_saat_transaksi, persen_penalti, total_uang) VALUES
('TRX-20241101001', '2024-11-01 10:15:00', 1, 4, 1, 1, 1, 2, 6.0, 7733.33, 0.0, 46400.0),
('TRX-20250525002', '2025-05-25 14:30:00', 2, 1, 2, 1, 2, 2, 10.0, 12000.0, 5.0, 120000.0),
('TRX-20260112003', '2026-01-12 09:20:00', 4, 5, 2, 1, 3, 1, 3.0, 60000.0, 5.0, 180000.0),
('TRX-20260709004', '2026-07-09 11:45:00', 5, 6, 1, 1, 2, 2, 5.0, 22060.0, 0.0, 110300.0),
('TRX-TODAY-001', datetime('now', '-2 hours'), 2, 2, 1, 1, 1, 2, 6.0, 9800.0, 0.0, 58800.0),
('TRX-TODAY-002', datetime('now', '-30 minutes'), 4, 1, 2, 1, 1, 2, 10.0, 5200.0, 5.0, 49400.0);
";
                            using (SQLiteCommand cmd = new SQLiteCommand(seedPanen, conn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch
            {
                // Diamkan agar tidak mengganggu inisialisasi awal
            }
        }
    }
}
