namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b0fc33ee-4d1d-494b-9c70-ebc5cf5696f3', N'guest@gmail.com', 0, N'AFJyBs9jZHFg/zrwLnJx+sMX0Hke+BRT99Rdvlazbf5Oz7g8X6N69uuWvwS+t/8u0Q==', N'deb6167c-4391-458d-a874-1e6dae0227bb', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd43f5e12-7d87-44e5-8c14-f1e0ab50e5e0', N'admin@vidly.com', 0, N'ADJTYoWsDirjAK9jnCDL17EaDo6jH/ft2hLTUabpl9r8F+ZdxkJLrpjQLGLtEUgifw==', N'7746c5f8-336f-4ac6-87e1-2912a0634b47', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'53326b0e-a392-4fe9-92f4-138cde0eaab0', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd43f5e12-7d87-44e5-8c14-f1e0ab50e5e0', N'53326b0e-a392-4fe9-92f4-138cde0eaab0')
             ");
        }
        
        public override void Down()
        {
        }
    }
}
