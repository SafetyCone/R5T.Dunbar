using System;


namespace R5T.Dunbar.Example.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var designTimeDbContextFactory = new DesignTimeDbContextFactory();

            var exampleDbContext = designTimeDbContextFactory.CreateDbContext(args);
        }
    }
}
