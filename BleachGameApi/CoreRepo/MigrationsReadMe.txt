to Generate or update database do the following steps:

navigate to CoreRepo in CMD

dotnet ef migrations add [MigrationName]
// this will setup a new schema to map the db to

dotnet ef database update [MigrationName]
// this will update the database based on a migration created