using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public Dictionary<string, DataBase> DataBaseList = new Dictionary<string, DataBase>();
        public DataBase DataBase { get; set; }
        public void SwitchDataBase(string path)
        {
            if (path == null)
                throw new ArgumentNullException();
            
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Нельзя переключиться на несуществующую директорию");
                return;
            }    

            //если такая бд существует, то выбираем ее
            if (DataBaseList.ContainsKey(path))
                 DataBase = DataBaseList[path];
            //если такой бд в словаре нет, то считаем ее из файла и добавляем в словарь
            else
            {
                var db = new DataBase(path);
                DataBaseList.Add(path, db);
                DataBase = db;
            }
        }

        public void CreateDataBase(string path)
        {
            if (path == null)
                throw new ArgumentNullException();

            if (Directory.Exists(path))
            {
                Console.WriteLine("База данных с таким именем уже существует");
                return;
            }

            var db = new DataBase(path);
            DataBaseList.Add(path, db);
            DataBase = db;
            Directory.CreateDirectory(path);
        }

        public void DeleteDataBase(string path)
        {
            if (path == null)
                throw new ArgumentNullException();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Нельзя удалить несуществующую базу данных");
                return;
            }

            Directory.Delete(path, true);

            if (DataBaseList.ContainsKey(path))
                DataBaseList.Remove(path);

            if (DataBase.PathToDataBase == path)
                DataBase = null;
        }

        public void OpenDataBase(string path)
        {
            if (path == null)
                throw new ArgumentNullException();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Нельзя восстановить базу данных, которая не существует");
                return;
            }
            var db = new DataBase(path);
            DataBaseList.Add(path, db);
            DataBase = db;
        }

        public void ShowAllDataBases(string path)
        {
            var dbs = Directory.GetDirectories(path, "db*");
            foreach (var db in dbs)
                Console.WriteLine(db);
        }
        public void ShowCurrentDataBase()
        {
            if (DataBase == null)
            {
                Console.WriteLine("Не выбрана ни одна директрия"); 
                return;
            }
            Console.WriteLine(DataBase.PathToDataBase);
        }
    }
}
