namespace ITSupport.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addchanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FormMsts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.FormMsts", "FormAccessCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FormMsts", "FormAccessCode", c => c.String());
            AlterColumn("dbo.FormMsts", "Name", c => c.String());
        }
    }
}
