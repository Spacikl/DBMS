using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Application.Delegates
{
    public class Delegates
    {
        public delegate void AddDelegate(string entity);
        public delegate void DeleteByIdDelegate(int id, CancellationToken cancellationToken);
        public delegate void UpdateByIdDelegate(int id, string entity, CancellationToken cancellationToken);
        
    }
}
