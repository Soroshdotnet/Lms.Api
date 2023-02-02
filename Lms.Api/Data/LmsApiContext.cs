using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lms.Core.Enteties;

namespace Lms.Api.Data
{
    public class LmsApiContext : DbContext
    {
        public LmsApiContext (DbContextOptions<LmsApiContext> options)
            : base(options)
        {
        }

        public DbSet<Lms.Core.Enteties.Tournament> Tournament { get; set; } = default!;

        public DbSet<Lms.Core.Enteties.Game> Game { get; set; } = default!;
    }
}
