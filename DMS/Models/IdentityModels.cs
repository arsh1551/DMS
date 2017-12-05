using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here<DirectedGraph xmlns="http://schemas.microsoft.com/vs/2009/dgml">
//  <Nodes>
//    <Node Id="(@1 @2)" Visibility="Hidden" />
//    <Node Id="(@3 Namespace=DMS.Models Type=ApplicationDbContext Member=.ctor)" Visibility="Hidden" />
//    <Node Id="@4" Category="CodeSchema_Class" CodeSchemaProperty_IsPublic="True" CommonLabel="ApplicationDbContext" Icon="Microsoft.VisualStudio.Class.Public" IsDragSource="True" Label="ApplicationDbContext" SourceLocation="(Assembly=file:///E:/DMS/DMS/Models/IdentityModels.cs StartLineNumber=20 StartCharacterOffset=17 EndLineNumber=20 EndCharacterOffset=37)" />
//  </Nodes>
//  <Links>
//    <Link Source="(@1 @2)" Target="@4" Category="Contains" />
//    <Link Source="@4" Target="(@3 Namespace=DMS.Models Type=ApplicationDbContext Member=.ctor)" Category="Contains" />
//  </Links>
//  <Categories>
//    <Category Id="CodeSchema_Class" Label="Class" BasedOn="CodeSchema_Type" Icon="CodeSchema_Class" />
//    <Category Id="CodeSchema_Type" Label="Type" Icon="CodeSchema_Class" />
//    <Category Id="Contains" Label="Contains" Description="Whether the source of the link contains the target object" IsContainment="True" />
//  </Categories>
//  <Properties>
//    <Property Id="CodeSchemaProperty_IsPublic" Label="Is Public" Description="Flag to indicate the scope is Public" DataType="System.Boolean" />
//    <Property Id="CommonLabel" DataType="System.String" />
//    <Property Id="Icon" Label="Icon" DataType="System.String" />
//    <Property Id="IsContainment" DataType="System.Boolean" />
//    <Property Id="IsDragSource" Label="IsDragSource" Description="IsDragSource" DataType="System.Boolean" />
//    <Property Id="Label" Label="Label" Description="Displayable label of an Annotatable object" DataType="System.String" />
//    <Property Id="SourceLocation" Label="Start Line Number" DataType="Microsoft.VisualStudio.GraphModel.CodeSchema.SourceLocation" />
//    <Property Id="Visibility" Label="Visibility" Description="Defines whether a node in the graph is visible or not" DataType="System.Windows.Visibility" />
//  </Properties>
//  <QualifiedNames>
//    <Name Id="Assembly" Label="Assembly" ValueType="Uri" />
//    <Name Id="File" Label="File" ValueType="Uri" />
//    <Name Id="Member" Label="Member" ValueType="System.Object" />
//    <Name Id="Namespace" Label="Namespace" ValueType="System.String" />
//    <Name Id="Type" Label="Type" ValueType="System.Object" />
//  </QualifiedNames>
//  <IdentifierAliases>
//    <Alias n="1" Uri="Assembly=$(VsSolutionUri)/DMS/DMS.csproj" />
//    <Alias n="2" Uri="File=$(VsSolutionUri)/DMS/Models/IdentityModels.cs" />
//    <Alias n="3" Uri="Assembly=$(ef9386cf-d92e-4dcc-a21b-73ec9f28bd3b.OutputPathUri)" />
//    <Alias n="4" Id="(@3 Namespace=DMS.Models Type=ApplicationDbContext)" />
//  </IdentifierAliases>
//  <Paths>
//    <Path Id="ef9386cf-d92e-4dcc-a21b-73ec9f28bd3b.OutputPathUri" Value="file:///E:/DMS/DMS/bin/DMS.dll" />
//    <Path Id="VsSolutionUri" Value="file:///E:/DMS" />
//  </Paths>
//</DirectedGraph>
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}