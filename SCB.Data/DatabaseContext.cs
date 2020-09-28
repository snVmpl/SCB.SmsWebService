using Microsoft.EntityFrameworkCore;
using SCB.Data.Entities;
using System.Linq;

namespace SCB.Data
{
    public sealed class DatabaseContext : DbContext
    {
        public IQueryable<Invite> Invites => base.Set<Invite>();
        public IQueryable<Message> Messages => base.Set<Message>();

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invite>().ToTable("Invites");
            modelBuilder.Entity<Invite>().HasKey(c => c.Id);
            modelBuilder.Entity<Invite>().HasKey(c => c.Id);
            modelBuilder.Entity<Invite>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Invite>().HasOne(c => c.Message).WithMany(c => c.Invites);

            modelBuilder.Entity<Message>().ToTable("Messages");
            modelBuilder.Entity<Message>().HasKey(c => c.Id);
            modelBuilder.Entity<Message>().Property(c => c.Id).ValueGeneratedOnAdd();
        }
    }
}
