namespace WcfService
{
    using System;

    public class UserService : IUserService
    {
        public void AddUser(string userName, string companyName)
        {
            Console.WriteLine($"{nameof(userName)} - {userName}");
            Console.WriteLine($"{nameof(companyName)} - {companyName}");
        }
    }
}
