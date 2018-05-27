namespace rm.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RidgeContext : DbContext
    {
        public RidgeContext()
            : base("name=RidgeContext")
        {
        }

        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<ActionJournal> ActionJournals { get; set; }
        public virtual DbSet<Fetuse> Fetuses { get; set; }
        public virtual DbSet<Ground> Grounds { get; set; }
        public virtual DbSet<Lapm> Lapms { get; set; }
        public virtual DbSet<Ridge> Ridges { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Scenario> Scenarios { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>()
                .HasMany(e => e.ActionJournals)
                .WithRequired(e => e.Action)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fetuse>()
                .HasMany(e => e.Ridges)
                .WithRequired(e => e.Fetuse)
                .HasForeignKey(e => e.FetuseType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ground>()
                .HasMany(e => e.Ridges)
                .WithRequired(e => e.Ground)
                .HasForeignKey(e => e.GroundType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ridge>()
                .HasMany(e => e.ActionJournals)
                .WithRequired(e => e.Ridge)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ridge>()
                .HasMany(e => e.Lapms)
                .WithRequired(e => e.Ridge)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role1)
                .HasForeignKey(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Scenario>()
                .HasMany(e => e.Ridges)
                .WithRequired(e => e.Scenario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Ridges)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Owner_idUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.start_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.end_ip_address)
                .IsUnicode(false);
        }
    }
}
