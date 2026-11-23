# AGRIVA.Tests

Proyek pengujian otomatis untuk source code AGRIVA R10.

## Teknologi

- Target Framework: .NET Framework 4.8 (`net48`)
- Test framework: MSTest
- Test runner: Microsoft.NET.Test.Sdk
- Referensi aplikasi: `AGRIVA.csproj`

## Menjalankan pengujian

Buka terminal pada folder yang berisi `AGRIVA.sln`, lalu jalankan:

```powershell
dotnet restore AGRIVA.sln
dotnet test AGRIVA.sln
```

Untuk menjalankan hanya proyek test:

```powershell
dotnet test AGRIVA.Tests/AGRIVA.Tests.csproj
```

## Prasyarat

- Windows
- .NET SDK yang mendukung target `net48`
- .NET Framework 4.8 Developer Pack / Targeting Pack
- MSBuild dan dependensi NuGet aplikasi AGRIVA tersedia

Karena aplikasi utama menggunakan proyek Windows Forms .NET Framework lama (non-SDK-style),
`dotnet test` perlu dijalankan pada lingkungan Windows yang memiliki toolchain .NET Framework.
Jika build gagal karena targeting pack atau referensi paket lama, itu adalah masalah lingkungan/build
yang perlu dibereskan sebelum hasil test dapat dinilai.

## Cakupan test awal

### Models
- Pembuatan hash PBKDF2-SHA256
- Verifikasi password benar dan salah
- Salt acak
- Input kosong/null dan format hash rusak

### Controllers
- Validasi input transaksi panen
- Validasi ID saat pembatalan
- Validasi daftar ID saat menandai muatan terkirim

## Batasan tahap awal

Test controller panen saat ini hanya menguji validasi sebelum repository dipanggil.
Belum ada integration test SQLite, test login berbasis database, test hak akses, atau test UI.
Hal-hal tersebut akan ditambahkan setelah jalur koneksi database dapat diisolasi agar test tidak
menyentuh `agriva.db` milik aplikasi.
