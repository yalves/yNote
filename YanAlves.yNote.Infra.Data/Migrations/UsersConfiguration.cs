namespace YanAlves.yNote.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class UsersConfiguration : DbMigrationsConfiguration<YanAlves.yNote.Infra.Data.Contexts.IdentityEntityContextDb>
    {
        public UsersConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(YanAlves.yNote.Infra.Data.Contexts.IdentityEntityContextDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}