namespace WcfService
{
    using System;
    using System.Configuration;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Newtonsoft.Json;

    public class UserService : IUserService
    {
        public async Task AddUser(UserDto dto)
        {
            Console.WriteLine($"{nameof(dto.UserName)} - {dto.UserName}");
            Console.WriteLine($"{nameof(dto.CompanyName)} - {dto.CompanyName}");

            var webApiUrl = ConfigurationManager.AppSettings["WebApiUrl"];

            HttpClient client = new HttpClient();
            var serializedDto = JsonConvert.SerializeObject(dto);
            var result = await client.PostAsync($"{webApiUrl}/api/v1/users/add",
                new StringContent(serializedDto, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
                Console.WriteLine("User successfully passed through WCF service to WebAPi service\n");
            else
                Console.WriteLine("Error! Please verify your WCF and WebApi services settings\n");
        }
    }
}