using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Domain
{
    public class VariantTable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<Variant> Variants{ get; set; }
    }
}
