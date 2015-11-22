namespace Sample.Data.Contracts
{
    using Data.Models.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Threading.Tasks;

    public interface ISampleDbContext
    {
        IDbSet<SampleModel> Samples { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}