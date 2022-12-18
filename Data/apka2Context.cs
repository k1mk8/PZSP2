using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apka2.Models;

namespace apka2.Data
{
    public class apka2Context : DbContext
    {
        public apka2Context (DbContextOptions<apka2Context> options)
            : base(options)
        {
        }

        public DbSet<apka2.Models.Patient> Patient { get; set; } = default!;

        public DbSet<apka2.Models.ClinicalCenter> ClinicalCenter { get; set; }

        public DbSet<apka2.Models.ClinicalDiagnosis> ClinicalDiagnosis { get; set; }

        public DbSet<apka2.Models.Doctor> Doctor { get; set; }

        public DbSet<apka2.Models.Servey> Servey { get; set; }

        public DbSet<apka2.Models.Procedure> Procedure { get; set; }

        public DbSet<apka2.Models.ProcedureSession> ProcedureSession { get; set; }
    }
}
