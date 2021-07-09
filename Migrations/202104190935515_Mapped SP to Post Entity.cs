namespace InstaSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MappedSPtoPostEntity : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Post_Insert",
                p => new
                    {
                        Timestamp = p.DateTime(),
                        Image = p.String(),
                        Description = p.String(),
                        User_Id = p.String(maxLength: 128),
                    },
                body:
                    @"INSERT [dbo].[Posts]([Timestamp], [Image], [Description], [User_Id])
                      VALUES (@Timestamp, @Image, @Description, @User_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Posts]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Posts] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Post_Update",
                p => new
                    {
                        Id = p.Int(),
                        Timestamp = p.DateTime(),
                        Image = p.String(),
                        Description = p.String(),
                        User_Id = p.String(maxLength: 128),
                    },
                body:
                    @"UPDATE [dbo].[Posts]
                      SET [Timestamp] = @Timestamp, [Image] = @Image, [Description] = @Description, [User_Id] = @User_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Post_Delete",
                p => new
                    {
                        Id = p.Int(),
                        User_Id = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[Posts]
                      WHERE (([Id] = @Id) AND (([User_Id] = @User_Id) OR ([User_Id] IS NULL AND @User_Id IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Post_Delete");
            DropStoredProcedure("dbo.Post_Update");
            DropStoredProcedure("dbo.Post_Insert");
        }
    }
}
