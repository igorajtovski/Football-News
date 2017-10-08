namespace euro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageGallery",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                        ImageSize = c.Int(nullable: false),
                        FileName = c.String(),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.ImageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageGallery");
        }
    }
}
