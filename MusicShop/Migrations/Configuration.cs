namespace MusicShop.Migrations
{
    using MusicShop.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MusicShop.DAL.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MusicShop.DAL.StoreContext";
        }

        protected override void Seed(MusicShop.DAL.StoreContext context)
        {
            StoreInitializer.SeadStoreData(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
