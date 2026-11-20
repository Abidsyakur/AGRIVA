using System;
using System.Collections.Generic;
using AGRIVA.Models;
using AGRIVA.Repositories;

namespace AGRIVA.Controllers
{
    /// <summary>Penghubung tampilan dengan data master kualitas.</summary>
    public class KualitasController
    {
        private readonly KualitasRepository repository;

        public KualitasController() : this(new KualitasRepository()) { }

        public KualitasController(KualitasRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            this.repository = repository;
        }

        public List<Kualitas> AmbilSemua()
        {
            return repository.GetAll();
        }
    }
}
