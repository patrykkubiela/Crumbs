using System.Data;
using FluentMigrator;

namespace Crumbs.Data.Migrations
{
    [Migration(20210411112600)]
    public class AddLogTable : Migration
    {
        public override void Up()
        {
            Execute.WithConnection(CustomConnection);
        }

        public override void Down()
        {
            Delete.Table("Log");
        }

        private void CustomConnection(IDbConnection arg1, IDbTransaction arg2)
        {
            Create.Table("Log")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Text").AsString();
        }
    }
}
