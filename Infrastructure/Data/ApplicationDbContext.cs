using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Professor> Professors => Set<Professor>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<Subject> Subjects => Set<Subject>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<User>("User")
                .HasValue<Client>("Client")
                .HasValue<Professor>("Professor")
                .HasValue<Admin>("Admin");

            modelBuilder.Entity<User>()
                    .Property(d => d.Role)
                    .HasConversion(
                        v => v.ToString(),
                        v => (UserRole)Enum.Parse(typeof(UserRole), v));

            modelBuilder.Entity<Enrollment>()
                .HasKey(e => e.EnrollmentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Client)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Subject)
                .WithMany(a => a.Enrollments)
                .HasForeignKey(e => e.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Subject>()
                .HasOne(a => a.Professor)
                .WithMany(p => p.Subjects)
                .HasForeignKey(a => a.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Professor>()
            .HasMany(p => p.Subjects)
            .WithOne(s => s.Professor)
            .HasForeignKey(s => s.ProfessorId);
        } //fin
    }
}
