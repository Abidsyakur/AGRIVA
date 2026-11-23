using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGRIVA.Controllers;
using AGRIVA.Models;
using AGRIVA.Repositories;

namespace AGRIVA.Tests.Controllers
{
    [TestClass]
    public class PanenControllerValidationTests
    {
        private PanenController CreateController()
        {
            // Seluruh skenario di kelas ini berhenti pada validasi controller,
            // sehingga tidak mengakses database aplikasi.
            return new PanenController(new PanenRepository());
        }

        private Panen CreateValidPanen()
        {
            return new Panen
            {
                NoTransaksi = "TRX-TEST-001",
                IdPetani = 1,
                IdKomoditas = 1,
                IdKualitas = 1,
                IdPetugas = 1,
                IdStatusBarang = 1,
                BeratKg = 10,
                HargaSaatTransaksi = 5000,
                PersenPenalti = 0,
                TotalUang = 50000
            };
        }

        [TestMethod]
        public void Simpan_WithNullPanen_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => CreateController().Simpan(null));
        }

        [TestMethod]
        public void Simpan_WithoutTransactionNumber_ThrowsArgumentException()
        {
            Panen panen = CreateValidPanen();
            panen.NoTransaksi = " ";

            Assert.ThrowsException<ArgumentException>(
                () => CreateController().Simpan(panen));
        }

        [TestMethod]
        public void Simpan_WithMissingRequiredMasterId_ThrowsArgumentException()
        {
            Panen panen = CreateValidPanen();
            panen.IdPetani = 0;

            Assert.ThrowsException<ArgumentException>(
                () => CreateController().Simpan(panen));
        }

        [TestMethod]
        public void Simpan_WithZeroOrNegativeWeight_ThrowsArgumentException()
        {
            Panen zeroWeight = CreateValidPanen();
            zeroWeight.BeratKg = 0;

            Panen negativeWeight = CreateValidPanen();
            negativeWeight.BeratKg = -1;

            Assert.ThrowsException<ArgumentException>(
                () => CreateController().Simpan(zeroWeight));
            Assert.ThrowsException<ArgumentException>(
                () => CreateController().Simpan(negativeWeight));
        }

        [TestMethod]
        public void Simpan_WithNegativePriceOrTotal_ThrowsArgumentException()
        {
            Panen negativePrice = CreateValidPanen();
            negativePrice.HargaSaatTransaksi = -1;

            Panen negativeTotal = CreateValidPanen();
            negativeTotal.TotalUang = -1;

            Assert.ThrowsException<ArgumentException>(
                () => CreateController().Simpan(negativePrice));
            Assert.ThrowsException<ArgumentException>(
                () => CreateController().Simpan(negativeTotal));
        }

        [TestMethod]
        public void Batalkan_WithInvalidId_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(
                () => CreateController().Batalkan(0));
            Assert.ThrowsException<ArgumentException>(
                () => CreateController().Batalkan(-1));
        }

        [TestMethod]
        public void TandaiTerkirim_WithNullIds_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => CreateController().TandaiTerkirim(null));
        }

        [TestMethod]
        public void TandaiTerkirim_WithEmptyIds_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(
                () => CreateController().TandaiTerkirim(new int[0]));
        }

        [TestMethod]
        public void TandaiTerkirim_WithNonPositiveId_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(
                () => CreateController().TandaiTerkirim(new[] { 1, 0 }));
        }
    }
}
