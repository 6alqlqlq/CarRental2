namespace TestCarRental3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionalCityCountry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    CountryID =c.Int(),
                    CityName = c.String(),
                    CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.Id);
                
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),                       
                        CountryName = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);          
                
        }
        
        public override void Down()
        {
            DropTable("dbo.Countries");            
            DropTable("dbo.Cities");
        }
    }
}
