namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES ('Titanic', 4, '1998-02-12', '2019-01-03', 1)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES ('Minionki', 5, '2014-02-10', '2018-02-12', 3)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES ('Helikopter w Ogniu', 3, '2010-01-16', '2019-04-05', 2)");
        }
        
        public override void Down()
        {
        }
    }
}
