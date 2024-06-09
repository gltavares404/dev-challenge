using API_FullTrack.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API_FullTrack.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=API_FullTrackDB3;ConnectRetryCount=0");
        }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}