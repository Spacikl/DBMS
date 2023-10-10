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
        public void DeleteById(string id, CancellationToken cancellationToken);
        public void Add(string entity);
        public void UpdateById(string id, string entity, CancellationToken cancellationToken);
        public string FindById(string id);
        public List<string> GetAll();
        public bool CheckUnique(string data);
    }
}
