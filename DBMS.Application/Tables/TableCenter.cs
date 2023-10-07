using DBMS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Application.Tables
{
    public class TableCenter<T> : ITable<T>
    {

        public string Path { get; set; }
        public TableCenter(string path)
        {
            Path = path;
        }

        public async void Add(string entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
              
            //var parsedClass = ParseClass(entity);

            File.AppendAllText(Path, entity + "\n");
        }


        //public async void DeleteById(T entity, string path,
        //    CancellationToken cancellationToken)
        //{
        //    if (path == null || entity == null)
        //        throw new ArgumentNullException();

        //    var parsedEntity = ParseClass(entity);

        //    await File.WriteAllLinesAsync(path,
        //        File.ReadAllLines(path)
        //        .Where(e => e != parsedEntity)
        //        .ToList(), cancellationToken);
        //}

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

        //public T FindById(int id, string path, CancellationToken cancellationToken)
        //{
        //    var entity = File.ReadAllLines(path)
        //        .Where(e => e.Split(' ')
        //            .ToList()
        //            .First() == id.ToString());
        //    var ent = Activator.CreateInstance(Assembly.GetCallingAssembly().FullName, nameof(T));

        //}

        public async void UpdateById(int id, string entity, CancellationToken cancellationToken)
        {
            await File.WriteAllLinesAsync(Path,
                File.ReadAllLines(Path)
                .Where(e => e.Split(' ')
                .ToList()
                .First() != id.ToString())
                .ToList(), cancellationToken);

            File.AppendAllText(Path, entity);
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