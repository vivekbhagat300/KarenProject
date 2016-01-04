namespace KarenProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class karen011 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.section1Model", "ContactState", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.section1Model", "ContactState", c => c.String(nullable: false));
        }
    }
}
