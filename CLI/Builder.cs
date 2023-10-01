using DBMS.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace builder;
/// <summary>
/// Check if the table with name="dbName" exist
/// </summary>
/// <param name="dbName"></param>
/*public void ExistCheck(string[] dbName)
{
    foreach (var tableName in dbName)
    {
        var dbExistsCheck = File.Exists(Path
            .Combine(Environment.CurrentDirectory, tableName));

        if (dbExistsCheck)
            continue;

        using (File.Create(tableName)) { };
    }
}*/

public abstract class Builder
{
    public string _path { get; set; } = Environment.CurrentDirectory;
    public abstract StudentTable CreateStudentTable();
    public abstract VariantTable CreateVariantTable();
    public abstract StudentVariantMarkTable CreateResultsTable();
    public abstract StudentVariantTable CreateStudentVariantTable();

}

class ConcreteBuilder: Builder
{
    public override StudentVariantMarkTable CreateResultsTable()
    {
        var resultsTable = new ResultsTable(Path.Combine(Environment.CurrentDirectory, "ResultsTable.txt"));
        resultsTable.Id = new Guid();
        CreateFile(resultsTable.Path);
        return resultsTable;

    }
    public override StudentTable CreateStudentTable()
    {
        var studentTable = new StudentTable(Path.Combine(Environment.CurrentDirectory, dbName));
        studentTable.Id = new Guid();
        CreateFile(studentTable.Path);
        return studentTable;
    }

    public override StudentVariantTable CreateStudentVariantTable()
    {
        var studentVariantTable = new StudentVariantTable(Path.Combine(Environment.CurrentDirectory, dbName));
        studentVariantTable.Id = new Guid();
        CreateFile(studentVariantTable.Path);
        return studentVariantTable;
    }

    public override VariantTable CreateVariantTable()
    {
        var variantTable = new VariantTable(Path.Combine(Environment.CurrentDirectory, dbName));
        variantTable.Id = new Guid();
        CreateFile(variantTable.Path);
        return variantTable;
    }
    public bool CreateFile(string path)
    {
        if (File.Exists(path))
            return false;
        using (File.Create(path)) { };
        return true;
    }
}




