namespace WcfService
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;

    //Run from VS with Administrator rights if you got an exception like "you don't have permissions ..."
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = null;
            try
            {
                //Base Address for UserService
                Uri httpBaseAddress = new Uri("http://localhost:4322/UserService");

                //Instantiate ServiceHost
                serviceHost = new ServiceHost(typeof(UserService), httpBaseAddress);

                //Add Endpoint to Host
                serviceHost.AddServiceEndpoint(typeof(IUserService), new WSHttpBinding(), "");

                //Metadata Exchange
                ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior();
                serviceBehavior.HttpGetEnabled = true;
                serviceHost.Description.Behaviors.Add(serviceBehavior);

                //Open
                serviceHost.Open();
                Console.WriteLine("Service is live now at : {0}", httpBaseAddress);
                Console.ReadKey();
            }

            catch (Exception ex)
            {
                serviceHost = null;
                Console.WriteLine("There is an issue with UserService" + ex.Message);
            }
        }
    }
}