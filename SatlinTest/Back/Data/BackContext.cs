using Microsoft.EntityFrameworkCore;
using SatlinTest.Models;

namespace SatlinTest.Back.Data
{
    public class BackContext: DbContext
    {
        public BackContext(DbContextOptions<BackContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Geo> Geo { get; set; }

    }
}
