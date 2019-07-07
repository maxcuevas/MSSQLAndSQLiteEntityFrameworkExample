# MSSQLAndSQLiteEntityFrameworkExample

Example of how to take data from a MSSQL database and transfer that data to a SQLite database.

The MSSQL and SQLite Databases have the same schema.

Notes about this experience:

1. The appconfig is not built correctly when including all of the required NUGET packages for SQLite.
The APP.config is missing this line

```
  <provider invariantName="System.Data.SQLite" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6"/>
```

That line needs to be added as a child to the ```<providers>``` section.

Is that line is not added the exception thrown will look like this: **System.InvalidOperationException: 'No Entity Framework provider found for the ADO.NET provider with invariant name 'System.Data.SQLite'. Make sure the provider is registered in the 'entityFramework' section of the application config file. **


2. Any calls involving dbcontexts should be in using statements

3. When using using statements with tables that have child tables errors will occur.
For example, main_table has a child table which is the employee table.
When trying to get a record from the main_table the referenced employee keep being null/exception.
This is due to the lazy execution that happens with EntityFramework. To fix this issue you need to add an Include call with the name of the table/class

```
 using (var msSqlDbContext = new Model1("mssql"))
{
    mainTableData = msSqlDbContext.main_table.Include("employee").ToList();
};
```
4. Any work with EntityFramework requires Absolute paths to the file, in our example the sqlite db.
This code will fix the path in app.config at runtime. As long as the file is in the same directory as the exe

```
string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
string path = (System.IO.Path.GetDirectoryName(executable));
AppDomain.CurrentDomain.SetData("DataDirectory", path);
```

For the projects purposes I decided to not have the db in the built directories. 

```
string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
string path = (System.IO.Path.GetDirectoryName(executable));
path = path.Replace(@"\bin\Debug", "");
AppDomain.CurrentDomain.SetData("DataDirectory", path);
```

Instead the sqlite file is in the same directory as the code, my preference/opinion.








