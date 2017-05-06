namespace WebApi.DAL
{
    using System;
    using Contracts;
    using Models;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EfContext context;
        private readonly IGenericRepository<User> userRepository;
        private readonly IGenericRepository<Company> companyRepository;

        public UnitOfWork(EfContext context)
        {
            this.context = context;
        }

        public IGenericRepository<User> UserRepository => userRepository ?? new GenericRepository<User>(context);

        public IGenericRepository<Company> CompanyRepository => companyRepository ?? new GenericRepository<Company>(context);

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}