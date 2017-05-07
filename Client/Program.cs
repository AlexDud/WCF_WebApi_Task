namespace Client
{
    using System;
    using Contracts;
    using WcfService;

    class Program
    {
        static void Main(string[] args)
        {
            var service = new UserServiceClient();

            var response = new ConsoleKeyInfo();

            try
            {
                while (response.Key != ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    AddUser(service);
                    Console.WriteLine("\nDo you want to add one more user? Press any key to continue or 'Esc' for exit");
                    response = Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddUser(UserServiceClient service)
        {
            Console.Write("Input user name: ");
            var userName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Input company name: ");
            var companyName = Console.ReadLine();
            Console.WriteLine();

            service.AddUser(new UserDto {UserName = userName, CompanyName = companyName});
        }
    }
}