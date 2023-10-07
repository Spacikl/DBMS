using DBMS.Application.Interfaces;
using DBMS.Application.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Domain
{
    public class StudentTable : TableCenter<Student>
    {
        public delegate void AddDelegate(string entity);
        public delegate void DeleteByIdDelegate(int id, CancellationToken cancellationToken);
        public delegate void UpdateByIdDelegate(int id, string entity, CancellationToken cancellationToken);
        public List<Student> Students { get; set; } = new();
        public StudentTable(string path) : base(path) 
        {
        
        }
    }
}
