using System;
using AGRIVA.Models;
using AGRIVA.Repositories;

namespace AGRIVA.Controllers
{
    /// <summary>Menyiapkan data ringkasan untuk halaman dashboard.</summary>
    public class DashboardController
    {
        private readonly DashboardRepository repository;
        public DashboardController() : this(new DashboardRepository()) { }
        public DashboardController(DashboardRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            this.repository = repository;
        }
        public DashboardStats AmbilStatistik() { return repository.GetStats(); }
    }
}
