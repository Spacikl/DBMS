﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        
        public string _commonDirectory = Path.Combine(Environment.
                GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "DataBases");

        public Dictionary<string, DataBase> DataBaseList = new Dictionary<string, DataBase>();
        public DataBase DataBase { get; set; }

        public ApplicationDbContext()
        {
            Directory.CreateDirectory(_commonDirectory);
        }

        public void SwitchDataBase(string dbName)
        {
            if (dbName == null)
                throw new ArgumentNullException();

            var newDbPath = Path.Combine(_commonDirectory, dbName);

            if (!Directory.Exists(newDbPath))
            {
                Console.WriteLine("Нельзя переключиться на несуществующую директорию");
                return;
            }    

            //если такая бд существует, то выбираем ее
            if (DataBaseList.ContainsKey(newDbPath))
                 DataBase = DataBaseList[newDbPath];
            //если такой бд в словаре нет, то считаем ее из файла и добавляем в словарь
            else
            {
                var db = new DataBase(newDbPath);
                DataBaseList.Add(newDbPath, db);
                DataBase = db;
            }
        }

        public void CreateDataBase(string dbName)
        {
            if (dbName == null)
                throw new ArgumentNullException();

            var newDbPath = Path.Combine(_commonDirectory, dbName);

            if (Directory.Exists(newDbPath))
            {
                Console.WriteLine("База данных с таким именем уже существует");
                return;
            }

            var db = new DataBase(newDbPath);
            DataBaseList.Add(newDbPath, db);
            DataBase = db;
            Directory.CreateDirectory(newDbPath);
        }

        public void DeleteDataBase(string dbName)
        {
            if (dbName == null)
                throw new ArgumentNullException();

            var newDbPath = Path.Combine(_commonDirectory, dbName);

            if (!Directory.Exists(newDbPath))
            {
                Console.WriteLine("Нельзя удалить несуществующую базу данных");
                return;
            }

            Directory.Delete(newDbPath, true);

            if (DataBaseList.ContainsKey(newDbPath))
                DataBaseList.Remove(newDbPath);

            if (DataBase != null && DataBase.PathToDataBase == newDbPath)
                DataBase = null;
        }

        public void OpenDataBase(string dbName)
        {
            if (dbName == null)
                throw new ArgumentNullException();

            var newDbPath = Path.Combine(_commonDirectory, dbName);

            if (!Directory.Exists(newDbPath))
            {
                Console.WriteLine("Нельзя восстановить базу данных, которая не существует");
                return;
            }
            var db = new DataBase(newDbPath);
            DataBaseList.Add(newDbPath, db);
            DataBase = db;
        }

        public List<string> ShowAllDataBases()
        {
            var dbs = Directory.GetDirectories(_commonDirectory, "db*").ToList();
            return dbs;
        }
        public string ShowCurrentDataBase()
        {
            if (DataBase == null)
            {
                Console.WriteLine("Не выбрана ни одна директрия"); 
                return string.Empty;
            }
            return DataBase.PathToDataBase;
        }

        public void GenerateTable()
        {
            if (DataBase == null)
            {
                Console.WriteLine("Не выбрана ни одна бд");
                return;
            }
            var dbStudents = DataBase.Students.GetAll();
            var dbVariants = DataBase.Variants.GetAll();

            Shuffle(dbVariants);
            
            var generatedList = new List<string>();
            var completedList = new List<string>();
            if (dbStudents.Count > 0 && dbVariants.Count > 0)
            {
                int j = 0;
                for (int i = 0; i < dbStudents.Count; i++)
                {
                    if (i >= dbVariants.Count)
                        j = 0;
                    
                    var parseVar = dbVariants[j].Split(' ');
                    var parseStudent = dbStudents[i].Split(' ');
                    generatedList.Add(parseStudent.First() + " " + parseVar.First());
                    completedList.Add($"{parseStudent[1]} {parseStudent[2]}\t {parseVar[1]}\t {0}");
                    j++;
                }
            }
            File.WriteAllLines(DataBase.StudentVariants.Path, generatedList);
            File.WriteAllLines(DataBase.StudentVariantMarks.Path, completedList);
        }

        public void Shuffle(List<string> array)
        {
            if (array.Count < 1)
                return;
            var random = new Random();
            for (int i = 0; i < array.Count; i++)
            {
                var key = array[i];
                var rnd = random.Next(i, array.Count);
                array[i] = array[rnd];
                array[rnd] = key;
            }
        }
    }
}
