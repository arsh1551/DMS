using CoreEntites;
using CoreEntites.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IEntitiesContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void Dispose();
        int SaveChanges();
        DbChangeTracker ChangeTracker { get; }

        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new();

        Database Database { get; }
    }
}
