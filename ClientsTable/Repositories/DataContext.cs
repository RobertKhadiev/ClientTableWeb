using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientsTable.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientsTable.repositories
{
    public class DataContext : DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<CityEntity> Cities { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
    : base(options)
        {
            Database.EnsureCreated();
        }
    } 
}
