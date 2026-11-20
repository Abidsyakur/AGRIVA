# AGRIVA – Struktur MVC bertahap

Aplikasi tetap Windows Forms .NET Framework 4.8 dengan SQLite. Refactoring dilakukan bertahap tanpa menambah halaman, kontrol, fitur, atau alur pengguna.

## Pemisahan tanggung jawab
- `Views/`: Windows Forms, Designer, dan presentasi UI.
- `Models/`: entitas Petani, Komoditas, Kualitas, dan Panen.
- `Repositories/`: akses SQLite untuk Petani, Komoditas, Kualitas, dan Panen.
- `Controllers/`: validasi dan penghubung View dengan Repository.
- `Data/Koneksi.cs`: koneksi dan inisialisasi database.

## Modul yang telah dipisahkan
- Petani: baca, simpan, dan operasi modul melalui repository/controller.
- Komoditas: baca dan operasi modul melalui repository/controller.
- Kualitas: data dropdown kualitas diambil melalui controller/repository.
- Panen/setoran: penyimpanan transaksi dan riwayat setoran melalui controller/repository.
- Muatan barang: pengambilan daftar muatan, penandaan terkirim secara batch, dan pembatalan transaksi melalui controller/repository.
- Laporan: pengambilan data transaksi untuk tampilan laporan melalui controller/repository; ekspor CSV dan formatting tetap menjadi tanggung jawab View.

## Batasan yang dipertahankan
- Seluruh halaman, kontrol, navigasi, dan alur UI lama dipertahankan.
- Tidak menambah CRUD kualitas atau halaman baru.
- Skema database tetap mengikuti kebutuhan aplikasi; `tb_status_bayar` dan `tb_panen.id_status_bayar` tidak digunakan.

## Pengujian
- Query SQLite untuk daftar muatan, laporan, dan riwayat setoran telah diuji terhadap database proyek.
- ZIP diuji integritasnya.
- Build C# belum dapat dijalankan pada lingkungan kerja ini karena toolchain .NET Framework/MSBuild tidak tersedia; perlu build dan uji regresi di Visual Studio.
