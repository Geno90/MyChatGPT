using ChatGPT.DataAccess.Data.DbEntities;
using ChatGPT.DataAccess.Data.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.DataContext
{
    public class ChatDbContext : DbContext
    {
        // Konstruktor som tar options som parameter
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
        }

        // Definiera DbSets för varje entitet
        public DbSet<Instance> Instances { get; set; }

        // Konfigurera databasmodellerna (om nödvändigt)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
