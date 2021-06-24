using System;
using FluentMigrator;

namespace Crumbs.Data.Migrations
{
    [Migration(202106231010)]
    public class AddCrumbsTypesTable : Migration
    {
        public override void Up()
        {
            Create.Table("CrumbsTypes")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Uuid").AsGuid()
                .WithColumn("Name").AsString()
                .WithColumn("Description").AsString();

            Insert.IntoTable("CrumbsTypes")
                .Row(
                    new
                    {
                        Uuid = Guid.NewGuid(), Name = "Appoitment", Description = "Just an apoitment"
                    });

            Insert.IntoTable("CrumbsTypes")
                .Row(
                    new
                    {
                        Uuid = Guid.NewGuid(), Name = "Clock counter", Description = "Clock counter with alarm"
                    });
        }

        public override void Down()
        {
            Delete.Table("CrumbsTypes");
        }
    }
}