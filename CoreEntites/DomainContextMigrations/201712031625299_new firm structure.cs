namespace CoreEntites.DomainContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfirmstructure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConnectionString", "AccountingFirmID", "dbo.AccountingFirms");
            DropIndex("dbo.ConnectionString", new[] { "AccountingFirmID" });
            CreateTable(
                "dbo.Firms",
                c => new
                    {
                        FirmId = c.Long(nullable: false, identity: true),
                        FirmName = c.String(maxLength: 50),
                        FirmEmail = c.String(maxLength: 50),
                        CreatedBy = c.Long(),
                        ModifiedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.FirmId);
            
            AddColumn("dbo.ConnectionString", "FirmID", c => c.Long());
            AddColumn("dbo.Users", "Firm_FirmId", c => c.Long());
            CreateIndex("dbo.ConnectionString", "FirmID");
            CreateIndex("dbo.Users", "Firm_FirmId");
            AddForeignKey("dbo.ConnectionString", "FirmID", "dbo.Firms", "FirmId");
            AddForeignKey("dbo.Users", "Firm_FirmId", "dbo.Firms", "FirmId");
            DropColumn("dbo.ConnectionString", "AccountingFirmID");
            DropTable("dbo.AccountingFirms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AccountingFirms",
                c => new
                    {
                        AccountingFirmId = c.Long(nullable: false, identity: true),
                        FirmName = c.String(maxLength: 50),
                        FirmEmail = c.String(maxLength: 50),
                        CreatedBy = c.Long(),
                        ModifiedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.AccountingFirmId);
            
            AddColumn("dbo.ConnectionString", "AccountingFirmID", c => c.Long());
            DropForeignKey("dbo.Users", "Firm_FirmId", "dbo.Firms");
            DropForeignKey("dbo.ConnectionString", "FirmID", "dbo.Firms");
            DropIndex("dbo.Users", new[] { "Firm_FirmId" });
            DropIndex("dbo.ConnectionString", new[] { "FirmID" });
            DropColumn("dbo.Users", "Firm_FirmId");
            DropColumn("dbo.ConnectionString", "FirmID");
            DropTable("dbo.Firms");
            CreateIndex("dbo.ConnectionString", "AccountingFirmID");
            AddForeignKey("dbo.ConnectionString", "AccountingFirmID", "dbo.AccountingFirms", "AccountingFirmId");
        }
    }
}
