namespace WcfService
{
    using System.ServiceModel;
    using System.Threading.Tasks;
    using Contracts;

    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        Task AddUser(UserDto dto);
    }
}