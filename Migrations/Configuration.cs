namespace InstaSharp.Migrations
{
    using InstaSharp.Context;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<InstaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(InstaDbContext context)
        {
        }
    }
}
