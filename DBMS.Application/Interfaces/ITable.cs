using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Application.Interfaces
{
    public interface ITable<T>
    {
        public void DeleteTable(string path);
        public void WriteEntityInFileAsync(T entity, string path, CancellationToken cancellationToken);
        public Task<bool> DeleteEntityAsync(string id, string path, CancellationToken cancellationToken);
        public Task<string> FindEntityAsync(string id, string path, CancellationToken cancellationToken);
        public string ParseClass(T entity);
        public T CreateEntityFromString();
    }
}
