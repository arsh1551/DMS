namespace CoreEntites.DomainContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DomainMigration : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.ConnectionString",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DBName = c.String(maxLength: 100, unicode: false),
                        ServerName = c.String(maxLength: 100, unicode: false),
                        ServerUserName = c.String(maxLength: 50, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                        PlanId = c.Int(),
                        AccountingFirmID = c.Long(),
                        SubDomainName = c.String(maxLength: 50),
                        CreatedBy = c.Long(),
                        ModifiedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountingFirms", t => t.AccountingFirmID)
                .Index(t => t.AccountingFirmID);
            
            CreateTable(
                "dbo.Individuals",
                c => new
                    {
                        IndividualRecordId = c.Long(nullable: false, identity: true),
                        Prefix = c.String(maxLength: 50, unicode: false),
                        BirthDate = c.DateTime(),
                        SSN = c.String(maxLength: 250, unicode: false),
                        Phone = c.String(maxLength: 50, unicode: false),
                        CreatedDate = c.DateTime(),
                        EmailAddress = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        Suffix = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        Password = c.String(maxLength: 250, unicode: false),
                        CreatedBy = c.Long(),
                        IsActive = c.Boolean(),
                        IsDeleted = c.Boolean(),
                        ModifiedBy = c.Long(),
                    })
                .PrimaryKey(t => t.IndividualRecordId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        IndividualRecordId = c.Long(),
                        UserName = c.String(maxLength: 100, unicode: false),
                        Password = c.String(maxLength: 250, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Long(),
                        ModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Individuals", t => t.IndividualRecordId)
                .Index(t => t.IndividualRecordId);
            
            CreateTable(
                "dbo.LogInfoes",
                c => new
                    {
                        ModuleName = c.String(nullable: false, maxLength: 128),
                        FieldName = c.String(unicode: false),
                        PreviousValue = c.String(),
                        NewValue = c.String(),
                        ModifiedBy = c.String(),
                        UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ModuleName);
            
            CreateTable(
                "dbo.LogProperties",
                c => new
                    {
                        TypeKey = c.String(nullable: false, maxLength: 128),
                        Key = c.String(nullable: false, maxLength: 128),
                        Name = c.String(unicode: false),
                        LogValues = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        ModifiedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.TypeKey, t.Key });
            
            CreateTable(
                "dbo.LogPropertyChanges",
                c => new
                    {
                        LogPropertyChangeId = c.Guid(nullable: false),
                        LogId = c.Guid(nullable: false),
                        PropertyKey = c.String(),
                        PreviousValue = c.String(),
                        NewValue = c.String(unicode: false),
                        EncryptionKey = c.String(),
                        CreatedBy = c.Long(),
                        ModifiedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.LogPropertyChangeId)
                .ForeignKey("dbo.Logs", t => t.LogId, cascadeDelete: true)
                .Index(t => t.LogId);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogId = c.Guid(nullable: false),
                        ObjectId = c.Int(),
                        ParentId = c.Int(),
                        TypeKey = c.String(),
                        OperationKey = c.String(),
                        UserId = c.Int(),
                        Message = c.String(unicode: false),
                        Created = c.DateTime(),
                        Processed = c.Boolean(nullable: false),
                        ProcessedDate = c.DateTime(),
                        SendEmail = c.Boolean(nullable: false),
                        WriteAsFile = c.Boolean(nullable: false),
                        Representative = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        ModifiedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.LogId);
            
            CreateTable(
                "dbo.LogTypes",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128, unicode: false),
                        Name = c.String(),
                        IdName = c.String(),
                        ClientIdName = c.String(),
                        ParentIdName = c.String(),
                        CreatedBy = c.Long(),
                        ModifiedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Key);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LogPropertyChanges", "LogId", "dbo.Logs");
            DropForeignKey("dbo.Users", "IndividualRecordId", "dbo.Individuals");
            DropForeignKey("dbo.ConnectionString", "AccountingFirmID", "dbo.AccountingFirms");
            DropIndex("dbo.LogPropertyChanges", new[] { "LogId" });
            DropIndex("dbo.Users", new[] { "IndividualRecordId" });
            DropIndex("dbo.ConnectionString", new[] { "AccountingFirmID" });
            DropTable("dbo.LogTypes");
            DropTable("dbo.Logs");
            DropTable("dbo.LogPropertyChanges");
            DropTable("dbo.LogProperties");
            DropTable("dbo.LogInfoes");
            DropTable("dbo.Users");
            DropTable("dbo.Individuals");
            DropTable("dbo.ConnectionString");
            DropTable("dbo.AccountingFirms");
        }
    }
}
