using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IApplicationDbContext
    {
        public DataBase DataBase { get; set; }
        public void SwitchDataBase(string dbName);
        public void CreateDataBase(string dbName);
        public void DeleteDataBase(string dbName);
        public void OpenDataBase(string dbName);
        public List<string> ShowAllDataBases();
        public string ShowCurrentDataBase();
        public void GenerateTable();
        public void Shuffle(List<string> array);
        public void AutoFill(string path_to_name, string path_to_var);
    }
}
