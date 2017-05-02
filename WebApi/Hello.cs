namespace WebApi
{
    public class Hello : IHello
    {
        public string SayHello(string name)
        {
            return $"Hello {name}";
        }
    }
}