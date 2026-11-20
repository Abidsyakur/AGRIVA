using System;
using System.Data;
using AGRIVA.Models;
using AGRIVA.Repositories;

namespace AGRIVA.Controllers
{
    /// <summary>Aturan aplikasi untuk manajemen pengguna.</summary>
    public class PenggunaController
    {
        private readonly PenggunaRepository repository;
        public PenggunaController() : this(new PenggunaRepository()) { }
        public PenggunaController(PenggunaRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            this.repository = repository;
        }
        public DataTable AmbilSemua() { return repository.GetAll(); }
        public void Simpan(Pengguna pengguna)
        {
            if (pengguna == null) throw new ArgumentNullException("pengguna");
            if (string.IsNullOrWhiteSpace(pengguna.NamaLengkap)) throw new ArgumentException("Nama lengkap wajib diisi.");
            if (string.IsNullOrWhiteSpace(pengguna.Username)) throw new ArgumentException("Nama pengguna wajib diisi.");
            if (pengguna.IdRole <= 0) throw new ArgumentException("Peran pengguna tidak valid.");
            if (pengguna.IsAktif != 0 && pengguna.IsAktif != 1) throw new ArgumentException("Status pengguna tidak valid.");
            if (pengguna.IdPengguna <= 0) repository.Add(pengguna);
            else repository.Update(pengguna);
        }
    }
}
