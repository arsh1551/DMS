namespace CoreEntites.SubDomainContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubDomainMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Long(nullable: false, identity: true),
                        AccountingFirmId = c.Int(nullable: false),
                        ClientName = c.String(),
                        ClientAddress = c.String(),
                        Phone = c.String(),
                        EmailAddress = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Password = c.String(),
                        ClientType = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        SSN = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        ModifiedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        Lastname = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        TerminationDate = c.DateTime(nullable: false),
                        Title = c.String(),
                        Address = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        ModifiedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.IndividualClients",
                c => new
                    {
                        IndividualClientRecordId = c.Long(nullable: false, identity: true),
                        IndividualRecordId = c.Long(nullable: false),
                        ClientRecordId = c.Long(nullable: false),
                        EmployeeId = c.Long(nullable: false),
                        IsIndividualClient = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        ModifiedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.IndividualClientRecordId);
            
            CreateTable(
                "dbo.UsersRoles",
                c => new
                    {
                        RecordId = c.Long(nullable: false, identity: true),
                        IndividualClientRecordId = c.Long(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        CreatedBy = c.Long(),
                        ModifiedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        InvitationRecordID = c.Long(nullable: false, identity: true),
                        ClientRecordID = c.Long(nullable: false),
                        Prefix = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        SSN = c.String(),
                        Phone = c.String(),
                        Suffix = c.String(),
                        IsClient = c.Boolean(nullable: false),
                        HasAccepted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        ModifiedBy = c.Long(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.InvitationRecordID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Invitations");
            DropTable("dbo.Roles");
            DropTable("dbo.UsersRoles");
            DropTable("dbo.IndividualClients");
            DropTable("dbo.Employees");
            DropTable("dbo.Clients");
        }
    }
}
