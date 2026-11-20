using System;
using System.Data;
using System.Collections.Generic;
using AGRIVA.Models;
using AGRIVA.Repositories;

namespace AGRIVA.Controllers
{
    public class KomoditasController
    {
        private readonly KomoditasRepository repository;
        public KomoditasController() : this(new KomoditasRepository()) { }
        public KomoditasController(KomoditasRepository repository) { this.repository = repository; }
        public DataTable AmbilSemua() { return repository.GetAll(); }
        public List<Komoditas> AmbilKomoditasAktif() { return repository.GetActive(); }
        public Komoditas AmbilBerdasarkanId(int id) { return repository.GetById(id); }
        public void Simpan(Komoditas komoditas)
        {
            if (komoditas == null) throw new ArgumentNullException("komoditas");
            if (string.IsNullOrWhiteSpace(komoditas.NamaKomoditas)) throw new ArgumentException("Nama produk harus diisi.");
            if (komoditas.HargaPerKg <= 0) throw new ArgumentException("Harga harus berupa angka lebih dari 0!");
            repository.Save(komoditas);
        }
        public void Nonaktifkan(int id) { repository.Deactivate(id); }
    }
}
