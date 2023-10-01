using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Application.Interfaces
{
    public interface IDataBase
    {
        public void CreateNewDataBase(string path, CancellationToken cancellationToken);
        public void OpenExistingDataBase(string path, CancellationToken cancellationToken);
        public void DeleteDataBase(string path, CancellationToken cancellationToken);

        public void ChooseDataBase(string path, CancellationToken cancellationToken);
    }
}
