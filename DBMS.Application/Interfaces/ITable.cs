using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Application.Interfaces
{
    public interface ITable<T>
    {
        public string Path { get; set; }
        public void DeleteById(int id, CancellationToken cancellationToken);
        public void Add(string entity);
        public void UpdateById(int id, string entity, CancellationToken cancellationToken);
        public string FindById(int id);
        public List<string> GetAll();
    }
}
