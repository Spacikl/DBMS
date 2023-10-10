using DBMS.Application.Tables;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DBMS.Domain
{
    public class StudentVariantTable : TableCenter<StudentVariant>
    {
        public List<StudentVariant> StudentVariants { get; set; } = new();
        public StudentVariantTable(string path) : base(path){ }


        public void DeleteVariantStudent(string id, CancellationToken cancellationToken)
        {
            File.WriteAllLines(Path,
                File.ReadAllLines(Path)
                .Where(e => e.Split(' ')
                .ToList()
                .Last() != id)
                .ToList());
        }
        public List<string> FindStudentsByVariantId(string id)
        {
            var allData = File.ReadAllLines(Path).ToList();
            var studentIdList = new List<string>();
            
            for (int i = 0; i < allData.Count; i++)
            {
                var parsedData= allData[i].Split(' ').ToList();
                if (parsedData[1] == id)
                {
                    studentIdList.Add(parsedData[0]);
                    allData[i] = "-1";
                }
            }
            File.WriteAllLines(Path, allData.Where(x => x != "-1"));
            return studentIdList;
        }
        public List<string> FindStudentsByVariantIdUpdate(string id)
        {
            var allData = File.ReadAllLines(Path).ToList();
            var studentIdList = new List<string>();

            for (int i = 0; i < allData.Count; i++)
            {
                var parsedData = allData[i].Split(' ').ToList();
                if (parsedData[1] == id)
                    studentIdList.Add(parsedData[0]);
                
            }
            return studentIdList;
        }
    }

}
