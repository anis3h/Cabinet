Example of Microsoft ASP.Net core Clean Architecture 

You can use migrations to create the database.
Open the PMC:
Tools –> NuGet Package Manager –> Package Manager Console
Run Add-Migration InitialCreate to scaffold a migration to create the initial set of tables for your model. If you receive an error stating The term 'add-migration' is not recognized as the name of a cmdlet, close and reopen Visual Studio.

Run Update-Database to apply the new migration to the database. This command creates the database before applying migrations.

PM:
1) Add-Migration -context CabinetContext -project infrastructure TestMigration
2) Update-Database -context CabinetContext -project infrastructure
