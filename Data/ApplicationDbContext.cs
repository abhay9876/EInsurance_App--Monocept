using Microsoft.EntityFrameworkCore;
using Monocept.Models;

namespace Monocept.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tables
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InsuranceAgent> InsuranceAgents { get; set; }
        public DbSet<InsurancePlan> InsurancePlans { get; set; }
        public DbSet<Scheme> Schemes { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<EmployeeScheme> EmployeeSchemes { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Admin>()
                .HasIndex(a => a.Email)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<InsuranceAgent>()
                .HasIndex(a => a.Email)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            
            modelBuilder.Entity<EmployeeScheme>()
                .HasOne(es => es.Employee)
                .WithMany(e => e.EmployeeSchemes)
                .HasForeignKey(es => es.EmployeeID);

            modelBuilder.Entity<EmployeeScheme>()
                .HasOne(es => es.Scheme)
                .WithMany(s => s.EmployeeSchemes)
                .HasForeignKey(es => es.SchemeID);


            modelBuilder.Entity<Commission>()
                .HasOne(c => c.Policy)
                .WithMany(p => p.Commissions)
                .HasForeignKey(c => c.PolicyID)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Commission>()
                .HasOne(c => c.Agent)
                .WithMany(a => a.Commissions)
                .HasForeignKey(c => c.AgentID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Policy)
                .WithMany(pol => pol.Payments)
                .HasForeignKey(p => p.PolicyID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Customer)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}