using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Domain
{
    public class DataBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public StudentTable StudentTable { get; set; }
        public StudentTable VariantTable { get; set; }
        public StudentVariantTable StudentVariantTable { get; set; }
        public StudentVariantMarkTable ResultsTable { get; set; }
    }
}
