namespace WebApi.DAL.Contracts
{
    using System;
    using Models;

    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Company> CompanyRepository { get; }
        void Save();
    }
}