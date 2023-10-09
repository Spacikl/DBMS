using DBMS.Application.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Domain
{
    public class StudentVariantTable : TableCenter<StudentVariant>
    {
        public List<StudentVariant> StudentVariants { get; set; } = new();
        public StudentVariantTable(string path) : base(path){ }

    }
}
