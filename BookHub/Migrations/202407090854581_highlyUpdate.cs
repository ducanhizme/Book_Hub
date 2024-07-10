namespace BookHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class highlyUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Books", "Publisher_PublisherId", "dbo.Publishers");
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "Publisher_PublisherId" });
            DropColumn("dbo.Books", "PublisherId");
            RenameColumn(table: "dbo.Books", name: "Publisher_PublisherId", newName: "PublisherId");
            DropPrimaryKey("dbo.BookCategories");
            AddColumn("dbo.Books", "image", c => c.String(unicode: false));
            AddColumn("dbo.Users", "Role", c => c.String(unicode: false));
            AlterColumn("dbo.BookCategories", "BookCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "PublisherId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.BookCategories", new[] { "BookId", "CategoryId" });
            CreateIndex("dbo.Books", "PublisherId");
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Publishers", "PublisherId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropPrimaryKey("dbo.BookCategories");
            AlterColumn("dbo.Books", "PublisherId", c => c.Int());
            AlterColumn("dbo.BookCategories", "BookCategoryId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Users", "Role");
            DropColumn("dbo.Books", "image");
            AddPrimaryKey("dbo.BookCategories", "BookCategoryId");
            RenameColumn(table: "dbo.Books", name: "PublisherId", newName: "Publisher_PublisherId");
            AddColumn("dbo.Books", "PublisherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "Publisher_PublisherId");
            CreateIndex("dbo.Books", "PublisherId");
            AddForeignKey("dbo.Books", "Publisher_PublisherId", "dbo.Publishers", "PublisherId");
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Publishers", "PublisherId");
        }
    }
}
