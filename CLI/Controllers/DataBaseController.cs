using DBMS.Domain;
using DBMS.Application.Interfaces;

namespace Main.Controllers
{
    public class DataBaseController
    {
        private readonly IDataBase _dataBase;
        public DataBaseController(IDataBase dataBase)
        {
            _dataBase = dataBase;
        }

        public void CreateDirectory(string dirPath)
        {
            
        }
        public void DeleteDirectory(string dirPath)
        {

        }
        
    }
}
