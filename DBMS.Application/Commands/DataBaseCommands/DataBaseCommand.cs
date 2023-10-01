using DBMS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Application.Commands.DataBaseCommands
{
    public class DataBaseCommand : IDataBase
    {
        
        public DataBaseCommand()
        {
            
        }
        public void ChooseDataBase(string path, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void CreateNewDataBase(string path, CancellationToken cancellationToken)
        {
            if (CheckDataBase(path))
                Directory.CreateDirectory(path);
        }

        public void DeleteDataBase(string path, CancellationToken cancellationToken)
        {
            if (path != null && Directory.Exists(path))
                Directory.Delete(path);
        }

        public void OpenExistingDataBase(string path, CancellationToken cancellationToken)
        {
            if (path != null && Directory.Exists(path))
            {

            }
        }

        public bool CheckDataBase(string path)
        {
            if (path == null || Directory.Exists(path))
            { 
                Console.WriteLine($"!!!Database: [ {path} ] already exist!!!");
                return false;
            }
            return true;
        }
    }
}
