namespace DummyPerceptualProj.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DummyPerceptualProj.Models.DummyPerceptualCont>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DummyPerceptualProj.Models.DummyPerceptualCont context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.Users.Any())
            {
                context.Users.AddOrUpdate(
                    new Models.User { Name = "Kowalski", Login = "kowalski", Password = "kowalski90" },
                    new Models.User { Name = "Nowak", Login = "nowak", Password = "nowak123" }
                    );
                context.SaveChanges();
            }
}
    }
}
