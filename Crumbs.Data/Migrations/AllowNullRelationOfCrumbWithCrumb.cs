using FluentMigrator;

namespace Crumbs.Data.Migrations
{
    [Migration(202106241806)]
    public class AllowNullRelationOfCrumbWithCrumb : Migration
    {
        public override void Up()
        {
            Alter.Column("BroadcasterId")
                .OnTable("Crumbs")
                .AsInt64()
                .Nullable();
        }

        public override void Down()
        {
            Alter.Column("BroadcasterId")
                .OnTable("Crumbs")
                .AsInt64()
                .NotNullable();
        }
    }
}