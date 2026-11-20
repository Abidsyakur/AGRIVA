using System;
using System.Data;
using AGRIVA.Models;
using AGRIVA.Repositories;

namespace AGRIVA.Controllers
{
    /// <summary>Aturan aplikasi untuk transaksi panen.</summary>
    public class PanenController
    {
        private readonly PanenRepository repository;

        public PanenController() : this(new PanenRepository()) { }

        public PanenController(PanenRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            this.repository = repository;
        }

        public void Simpan(Panen panen)
        {
            if (panen == null) throw new ArgumentNullException("panen");
            if (string.IsNullOrWhiteSpace(panen.NoTransaksi))
                throw new ArgumentException("Nomor transaksi wajib diisi.");
            if (panen.IdPetani <= 0 || panen.IdKomoditas <= 0 || panen.IdKualitas <= 0)
                throw new ArgumentException("Petani, komoditas, dan kualitas wajib dipilih.");
            if (panen.BeratKg <= 0) throw new ArgumentException("Berat panen harus lebih dari nol.");
            if (panen.HargaSaatTransaksi < 0 || panen.TotalUang < 0)
                throw new ArgumentException("Nilai harga dan total tidak valid.");
            repository.Insert(panen);
        }

        public DataTable AmbilRiwayatSetoran()
        {
            return repository.GetAllForSetoran();
        }
        public DataTable AmbilDataMuatan()
        {
            return repository.GetAllForMuatan();
        }

        public DataTable AmbilDataLaporan()
        {
            return repository.GetAllForLaporan();
        }

        public void Batalkan(int idPanen)
        {
            if (idPanen <= 0) throw new ArgumentException("Transaksi tidak valid.", "idPanen");
            repository.UpdateStatus(idPanen, 3);
        }

        public void TandaiTerkirim(System.Collections.Generic.IEnumerable<int> ids)
        {
            if (ids == null) throw new ArgumentNullException("ids");
            var daftarId = new System.Collections.Generic.List<int>(ids);
            if (daftarId.Count == 0) throw new ArgumentException("Pilih minimal satu muatan.", "ids");
            if (daftarId.Exists(id => id <= 0)) throw new ArgumentException("ID muatan tidak valid.", "ids");
            repository.UpdateStatusBatch(daftarId, 2);
        }

    }
}
