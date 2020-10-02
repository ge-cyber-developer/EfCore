using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EfCore.Domains;

namespace EfCore.Contexts
{
    public class PedidoContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source-=N -15-DEV-16/SQLEXPRESS;Initial Catalog= boletim; User ID =sa; Password = 123");
            }
        }
    }
}
