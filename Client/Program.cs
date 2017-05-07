namespace Client
{
    using System;
    using Contracts;

    class Program
    {
        static void Main(string[] args)
        {
            var service = new WcfService.UserServiceClient();

            Console.WriteLine("Input user name:");
            var userName = Console.ReadLine();
            Console.WriteLine("Input company name:");
            var companyName = Console.ReadLine();

            service.AddUser(new UserDto { UserName = userName, CompanyName = companyName });

            Console.ReadKey();
        }
    }
}