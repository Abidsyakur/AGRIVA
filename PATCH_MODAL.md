# Perbaikan dialog/modal AGRIVA

Perubahan hanya pada frontend `Views/DashboardForm.cs`.

- Menambahkan `HideAllModalCards()` agar semua kartu dialog ditutup sebelum dialog baru dibuka.
- Menambahkan `ShowModalCard()` agar hanya satu kartu modal tampil di overlay dan berada di lapisan paling depan.
- Semua alur buka/tutup modal Petani, Produk, Pembatalan, dan Pengguna menggunakan mekanisme eksklusif yang sama.
- Semua kartu modal dipastikan tersembunyi saat Dashboard pertama kali dimuat.

Tidak ada perubahan pada database, repository, controller, atau fitur bisnis.

Setelah mengekstrak ZIP, buka solution di Visual Studio/VS Code dan lakukan rebuild. Jalankan aplikasi hasil build terbaru, bukan executable lama dari folder `bin`.
