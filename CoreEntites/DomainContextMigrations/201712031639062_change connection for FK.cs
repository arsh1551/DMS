namespace CoreEntites.DomainContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeconnectionforFK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Firm_FirmId", newName: "FirmID");
            RenameIndex(table: "dbo.Users", name: "IX_Firm_FirmId", newName: "IX_FirmID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "IX_FirmID", newName: "IX_Firm_FirmId");
            RenameColumn(table: "dbo.Users", name: "FirmID", newName: "Firm_FirmId");
        }
    }
}
