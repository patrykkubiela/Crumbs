dotnet ef migrations add AddCrumbsMigration --startup-project ../Crumbs.Api/Crumbs.Api.csproj --project Crumbs.Data.csproj --context CrumbsDbContext
dotnet ef database update --startup-project ../Crumbs.Api/Crumbs.Api.csproj --project Crumbs.Data.csproj --context CrumbsDbContext
