using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Application.Exceptions
{
    public class NullDirectoryException : Exception {
        public NullDirectoryException(string name, string path) 
        : base($"Directory with name: [{name}] not found at path: [{path}]") { }
    }
}
