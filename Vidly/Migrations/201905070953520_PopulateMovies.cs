namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES ('Szybcy i Wœciekli', 1, '2006-12-23', '2019-05-07', 5)");
            
        }
        
        public override void Down()
        {
        }
    }
}
