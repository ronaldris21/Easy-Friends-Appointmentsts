using Microsoft.EntityFrameworkCore;
using Summary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summary.Core.Abstraction
{
    public interface IDbContext
    {
        public Task<int> SaveChangeAsync( CancellationToken cancellationToken = default);

        public DbSet<Friend> Friend { get; set; }
        public DbSet<Appointment> Appointment { get; set; }


    }
}
