using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using TeamGreenWebApp.Configuration;
using TeamGreenWebApp.Models;

namespace TeamGreenWebApp.Context
{
    public class TeamGreenDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public TeamGreenDbContext(DbContextOptions<TeamGreenDbContext> options) : base (options)
        {

        }

        public DbSet<Mail> Mail { get; set; }
        public DbSet<Trash> Trash { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reciver> Reciver { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new MailConfiguration());
            builder.ApplyConfiguration(new TrashConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ReciverConfiguration());
        }
    }
}
