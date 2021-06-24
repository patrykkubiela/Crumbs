using FluentMigrator;

namespace Crumbs.Data.Migrations
{
    [Migration(202106231019)]
    public class AddCrumbsTable : Migration
    {
        public override void Up()
        {
            Create.Table("Crumbs")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Uuid").AsGuid()
                .WithColumn("Name").AsString()
                .WithColumn("Description").AsString()
                .WithColumn("CrumbTypeId").AsInt64().ForeignKey("FK_Crumbs_CrumbsTypes", "CrumbsTypes", "Id")
                .WithColumn("BroadcasterId").AsInt64().ForeignKey("FK_Crumbs_Crumbs", "Crumbs", "Id");
        }

        public override void Down()
        {
            Delete.Table("Crumbs");
        }
    }
}