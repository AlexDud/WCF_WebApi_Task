namespace WcfService
{
    using System.ServiceModel;
    using System.Threading.Tasks;

    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        Task AddUser(string userName, string companyName);
    }
}