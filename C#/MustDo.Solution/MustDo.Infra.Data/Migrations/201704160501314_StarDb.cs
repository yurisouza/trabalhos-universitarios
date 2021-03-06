namespace MustDo.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StarDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        UsuarioId = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        TarefaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Situacao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataFinalizacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UsuarioId = c.String(maxLength: 8000, unicode: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TarefaId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        UsuarioId = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, unicode: false),
                        Email = c.String(nullable: false, maxLength: 256, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 8000, unicode: false),
                        SecurityStamp = c.String(maxLength: 8000, unicode: false),
                        PhoneNumber = c.String(maxLength: 8000, unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TarefaTag",
                c => new
                    {
                        Tarefa_TarefaId = c.Int(nullable: false),
                        Tag_TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tarefa_TarefaId, t.Tag_TagId })
                .ForeignKey("dbo.Tarefas", t => t.Tarefa_TarefaId)
                .ForeignKey("dbo.Tags", t => t.Tag_TagId)
                .Index(t => t.Tarefa_TarefaId)
                .Index(t => t.Tag_TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TarefaTag", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.TarefaTag", "Tarefa_TarefaId", "dbo.Tarefas");
            DropForeignKey("dbo.Tarefas", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.TarefaTag", new[] { "Tag_TagId" });
            DropIndex("dbo.TarefaTag", new[] { "Tarefa_TarefaId" });
            DropIndex("dbo.Tarefas", new[] { "CategoriaId" });
            DropTable("dbo.TarefaTag");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tags");
            DropTable("dbo.Tarefas");
            DropTable("dbo.Categorias");
        }
    }
}
