namespace WcfService
{
    using System;
    using System.Configuration;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        public async Task AddUser(string userName, string companyName)
        {
            Console.WriteLine($"{nameof(userName)} - {userName}");
            Console.WriteLine($"{nameof(companyName)} - {companyName}");

            var userDto = new {userName, companyName};
            var webApiUrl = ConfigurationManager.AppSettings["WebApiUrl"];

            HttpClient client = new HttpClient();
            var result = await client.PostAsync($"{webApiUrl}/api/v1/users/add",
                new StringContent(userDto.ToString(), Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
                Console.WriteLine("\nUser successfully passed through WCF service to WebAPi service");
            else
                Console.WriteLine("\nError! Please verify your WCF and WebApi services settings");
        }
    }
}