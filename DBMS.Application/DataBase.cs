using DBMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DataBase
    {
        public string PathToDataBase;
        public StudentTable Students;
        public VariantTable Variants;
        public StudentVariantTable StudentVariants;
        public StudentVariantMarkTable StudentVariantMarks;
        public DataBase(string path)
        { 
            PathToDataBase = path;
            Students = new StudentTable(Path.Combine(path, "DbStudents.txt"));
            Variants = new VariantTable(Path.Combine(path, "DbVariants.txt"));
            StudentVariants = new StudentVariantTable(Path.Combine(path, "DbStudentVariants.txt"));
            StudentVariantMarks = new StudentVariantMarkTable(Path.Combine(path, "DbStudentVariantMarks.txt"));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (!File.Exists(Students.Path)) 
                File.Create(Students.Path).Close();
            if (!File.Exists(Variants.Path)) 
                File.Create(Variants.Path).Close();
            if (!File.Exists(StudentVariants.Path)) 
                File.Create(StudentVariants.Path).Close();
            if (!File.Exists(StudentVariantMarks.Path)) 
                File.Create(StudentVariantMarks.Path).Close();
        }
    }
}
