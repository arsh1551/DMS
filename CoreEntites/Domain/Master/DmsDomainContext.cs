
namespace CoreEntites.Domain.Master
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using CoreEntities.Domain;
    using System.Data.Entity.Infrastructure;
    public partial class DmsDomainContext : DbContext
    {
        public DmsDomainContext()
            : base("name=DmsDomainContext")
        {

            Database.SetInitializer<DmsDomainContext>(new DropCreateDatabaseIfModelChanges<DmsDomainContext>());
        }

        public virtual DbSet<Firm> Firms { get; set; }
        public virtual DbSet<ConnectionString> ConnectionStrings { get; set; }
        public virtual DbSet<Individual> Individuals { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<LogType> LogTypes { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<LogProperty> LogProperties { get; set; }
        public virtual DbSet<LogPropertyChange> LogPropertyChanges { get; set; }
        public virtual DbSet<LogInfo> LogInfos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ConnectionString>()
                .Property(e => e.DBName)
                .IsUnicode(false);

            modelBuilder.Entity<ConnectionString>()
                .Property(e => e.ServerName)
                .IsUnicode(false);

            modelBuilder.Entity<ConnectionString>()
                .Property(e => e.ServerUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ConnectionString>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Individual>()
                .Property(e => e.Prefix)
                .IsUnicode(false);

            modelBuilder.Entity<Individual>()
                .Property(e => e.SSN)
                .IsUnicode(false);

            modelBuilder.Entity<Individual>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Individual>()
                .Property(e => e.Suffix)
                .IsUnicode(false);

            modelBuilder.Entity<Individual>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
              .Property(e => e.Message)
              .IsUnicode(false);

            modelBuilder.Entity<LogInfo>()
              .Property(e => e.FieldName)
              .IsUnicode(false);

            modelBuilder.Entity<LogType>()
              .Property(e => e.Key)
              .IsUnicode(false);

            modelBuilder.Entity<LogProperty>()
              .Property(e => e.Name)
              .IsUnicode(false);
            modelBuilder.Entity<LogPropertyChange>()
              .Property(e => e.NewValue)
              .IsUnicode(false);
        }
    }
}
