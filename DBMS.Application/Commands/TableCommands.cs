using DBMS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Application.Commands
{
    public class TableCommands<T> : ITable<T>
    {
        public void DeleteTable(string path)
            => File.Delete(path);

        public async void WriteEntityInFileAsync(T entity, string path, CancellationToken cancellationToken)
        {
            var parsedEntity = ParseClass(entity);
            if (File.Exists(path))
            {
                await File.AppendAllTextAsync(path, parsedEntity);
            }
        }

        public async Task<bool> DeleteEntityAsync(string id, string path, CancellationToken cancellationToken)
        {
            string foundEntity;
            using (StreamReader reader = new StreamReader(path))
            {
                while ((foundEntity = await reader.ReadLineAsync()) != null)
                {
                    var data = foundEntity.Split(' ');
                    var guidStr = data[0];
                    if (guidStr == id)
                        return true;
                }
            }
            return false;
        }

        public async Task<string> FindEntityAsync(string id, string path, CancellationToken cancellationToken)
        {
            string foundEntity;
            using (StreamReader reader = new StreamReader(path))
            {
                while((foundEntity = await reader.ReadLineAsync()) != null)
                {
                    var data = foundEntity.Split(' ');
                    var guidStr = data[0];
                    if (guidStr == id)
                    {
                        return data.ToString()!;
                    }
                }
            }
            return foundEntity;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken, string _path)
        {
            throw new NotImplementedException();
        }


        public string ParseClass(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            var properties = typeof(T).GetProperties().ToList();
            var propertiesList = new List<string>();

            foreach (var p in properties)
                propertiesList.Add(p.GetValue(entity).ToString());


            return string.Join(" ", propertiesList);
        }

        public T CreateEntityFromString() { throw new NotImplementedException(); }

    }
}