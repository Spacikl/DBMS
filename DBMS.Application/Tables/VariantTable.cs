using DBMS.Application.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Domain
{
    public class VariantTable : TableCenter<Variant>
    {
        public List<Variant> Variants { get; set; } = new();
        public VariantTable(string path) : base(path) { }
    }
}
