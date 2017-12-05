namespace CoreEntites.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using CoreEntites.SubDomain;
    using System.Data.Entity.Infrastructure;
    using CoreEntites.Domain.Master;

    public partial class DmsSubDomainContext : DbContext
    {
        public DmsSubDomainContext()
            : base("name=DmsSubDomainContext")
        {

            Database.SetInitializer<DmsDomainContext>(new DropCreateDatabaseIfModelChanges<DmsDomainContext>());
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<IndividualClient> IndividualClient { get; set; }
        public virtual DbSet<Invitations> Invitations { get; set; }

        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UsersRole> UsersRole { get; set; }        

    }
}
