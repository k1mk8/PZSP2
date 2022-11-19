using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apka.Models;

namespace apka.Data
{
    public class apkaContext : DbContext
    {
        public apkaContext (DbContextOptions<apkaContext> options)
            : base(options)
        {
        }

        public DbSet<apka.Models.Patient> Patient { get; set; } = default!;
    }
}
