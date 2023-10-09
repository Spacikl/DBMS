using DBMS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DBMS.Application.Tables
{
    public class TableCenter<T> : ITable<T>
    {
        public int IdIndex = 0;

        public string Path { get; set; }
        public TableCenter(string path)
        {
                Path = path;
            if (!File.Exists(Path))
                File.Create(Path).Close();
            //else UpdateIndex();
        }

        private void UpdateIndex()
        {
            var lastLine = File.ReadAllLines(Path).Last();
            IdIndex = int.Parse(lastLine
                .Split(' ')
                .ToList()
                .First());
        }

        public async void Add(string entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
              
            //var parsedClass = ParseClass(entity);

            File.AppendAllText(Path, IdIndex + " " + entity + "\n");
            IdIndex++;
        }


        public string FindById(int id)
        {
            var entity = File.ReadLines(Path)
                .Where(x => x.Split(' ').ToList().First() == id.ToString());

            if (entity.Count() == 0)
                return new string($"Не найдено :( ");

            return entity.First();
        }

        public List<string> GetAll()
            => File.ReadAllLines(Path).ToList();
        

        public async void DeleteById(int id,
            CancellationToken cancellationToken)
        {
            await File.WriteAllLinesAsync(Path,
                File.ReadAllLines(Path)
                .Where(e => e.Split(' ')
                .ToList()
                .First() != id.ToString())
                .ToList(), cancellationToken);
        }

        
        public async void UpdateById(int id, string entity,
            CancellationToken cancellationToken)
        {
            var allData = File.ReadAllLines(Path);
            for (int i = 0; i < allData.Length; i++)
            {
                if (allData[i].Split(' ').First() == id.ToString())
                {
                    allData[i] = id.ToString() + " " + entity;
                    break;
                }
            }
            File.Delete(Path);
            File.AppendAllLines(Path,allData);
        }

        public string ParseClass(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            var properties = typeof(T).GetProperties().ToList();
            var propertiesList = new List<string>();

            foreach (var p in properties)
                propertiesList.Add(p.GetValue(entity).ToString());


            var str = string.Join(" ", propertiesList);
            return str;
        }
    }
}