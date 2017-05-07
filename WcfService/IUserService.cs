namespace WcfService
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        void AddUser(string userName, string companyName);
    }
}