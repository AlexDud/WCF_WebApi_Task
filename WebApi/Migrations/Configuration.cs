namespace WebApi.Migrations
{
    using System.Data.Entity.Migrations;
    using DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<EfContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EfContext context)
        {

        }
    }
}
