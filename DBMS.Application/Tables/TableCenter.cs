using DBMS.Application.Interfaces;
using DBMS.Domain;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
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
            {
                File.Create(Path).Close();
                if (typeof(T) == typeof(StudentVariantMark))
                    File.AppendAllText(Path, "FullName\t\t\t Path to File\t\t\t Mark\n");
            }
            else UpdateIndex();
        }

        private void UpdateIndex()
        {
            var lastLine = File.ReadAllLines(Path).Last();
            var id = int.TryParse(lastLine.Split(' ').First(), out int index);
            if (id) { 
                IdIndex = index + 1;
            }
        }

        public async void Add(string entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            if (CheckUnique(entity))
            {
                File.AppendAllText(Path, IdIndex + " " + entity + "\n");
                IdIndex++;
            }
            else
            {
                Console.WriteLine("Такая сущность уже есть!");
            }
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
            if (CheckUnique(entity))
            {
                for (int i = 0; i < allData.Length; i++)
                {
                    if (allData[i].Split(' ').First() == id.ToString())
                    {
                        allData[i] = id.ToString() + " " + entity;
                        break;
                    }
                }
                File.Delete(Path);
                File.AppendAllLines(Path, allData);
            }
            else Console.WriteLine("Такой элемент уже есть");
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

        public bool CheckUnique(string data)
        {
            var allData = File.ReadAllLines(Path);
            foreach (var str in allData)
            {
                if (str.Contains(data))
                    return false;
            }
            return true;
        }
    }
}