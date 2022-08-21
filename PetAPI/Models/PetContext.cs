using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAPI.Models
{
    public class PetContext : DbContext
    {

        public PetContext(DbContextOptions<PetContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Pet> Pets { get; set; }
    }
}
