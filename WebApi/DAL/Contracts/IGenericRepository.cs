namespace WebApi.DAL.Contracts
{
    public interface IGenericRepository<TEntity>
    {
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}
