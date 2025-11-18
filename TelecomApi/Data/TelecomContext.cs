
using TelecomApi.Models;
using Microsoft.EntityFrameworkCore;
 namespace TelecomApi.Data
    {
        public class TelecomContext : DbContext
        {
            public TelecomContext(DbContextOptions<TelecomContext> options) : base(options) { }

            public DbSet<Abonent> Abonents { get; set; }
            public DbSet<Payment> Payments { get; set; }
        }
    }


