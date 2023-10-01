using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Domain
{
    public class StudentVariant
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid VariantId { get; set; }
    }
}
