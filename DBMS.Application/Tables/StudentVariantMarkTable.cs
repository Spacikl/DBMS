using DBMS.Application.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Domain
{
    public class StudentVariantMarkTable : TableCenter<StudentVariantMark>
    {
        public List<StudentVariantMark> StudentVariantMarks { get; set; } = new();
        public StudentVariantMarkTable(string path) : base(path){ }
    }
}
