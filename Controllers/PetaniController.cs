using System.Data;
using System.Collections.Generic;
using System;
using AGRIVA.Models;
using AGRIVA.Repositories;

namespace AGRIVA.Controllers
{
    public class PetaniController
    {
        private readonly PetaniRepository repository;

        public PetaniController() : this(new PetaniRepository()) { }
        public PetaniController(PetaniRepository repository) { this.repository = repository; }

        public DataTable GetDataPetani() { return repository.GetAll(); }
        public List<Petani> AmbilPetaniAktif() { return repository.GetActive(); }
        public void SimpanPetani(Petani petani)
        {
            if (petani == null) throw new ArgumentNullException("petani");
            if (string.IsNullOrWhiteSpace(petani.NamaPetani)) throw new ArgumentException("Nama petani harus diisi.");
            repository.Save(petani);
        }
    }
}
