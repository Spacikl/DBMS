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
        public void SwitchDataBase(string path);
        public void CreateDataBase(string path);
        public void DeleteDataBase(string path);
        public void OpenDataBase(string path);
        public void ShowAllDataBases(string path);
        public void ShowCurrentDataBase();
    }
}
