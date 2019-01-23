using EspaceClient.Entities;
using EspaceClient.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EspaceClient.Data.Context
{
    public class EspaceClientContext : DbContext
    {
        public EspaceClientContext(DbContextOptions<EspaceClientContext> options)
        : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public DbQuery<ClientVMs> ClientVMs { get; set; }
    }
}
