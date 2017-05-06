namespace WebApi.DAL.Contracts
{
    using Models;

    public interface IUnitOfWork
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Company> CompanyRepository { get; }
        void Save();
    }
}