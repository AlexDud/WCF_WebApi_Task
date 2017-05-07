namespace WebApi.DAL.Contracts
{
    public interface IGenericRepository<TEntity>
    {
        void Insert(TEntity entity);
    }
}
