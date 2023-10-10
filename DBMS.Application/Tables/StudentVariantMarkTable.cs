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
        public void AddMark(string student, string mark)
        {
            var allData = File.ReadAllLines(Path);

            if (allData.Count() == 0)
            {
                Console.WriteLine("Таблица пуста");
                return;
            }

            var parsedStudent = student.Split(' ');

            for (int i = 0; i < allData.Length; i++)
            {
                var parsedData = allData[i].Split(' '); 
                if (parsedData[0] == parsedStudent[0] && parsedData[1] == parsedStudent[1]
                    && parsedData[2] == parsedStudent[2])
                {
                    parsedData[parsedData.Length - 1] = mark;
                    allData[i] = string.Join(" ",parsedData);
                    break;
                }
            }
            File.Delete(Path);
            File.AppendAllLines(Path, allData);
        }
        public void DeleteStudent(string student)
        {
            var allData = File.ReadAllLines(Path).ToList();

            if (allData.Count() == 0)
            {
                Console.WriteLine("Таблица пуста");
                return;
            }

            var parsedStudent = student.Split(' ');

            for (int i = 0; i < allData.Count(); i++)
            {
                var parsedData = allData[i].Split(' ');
                if (parsedData[0] == parsedStudent[0] && parsedData[1] == parsedStudent[1]
                    && parsedData[2] == parsedStudent[2])
                {
                    allData.RemoveAt(i);
                    break;
                }
            }
            File.Delete(Path);
            File.AppendAllLines(Path, allData);
        }
        public void DeleteStudentsVariant(string surname, string name, string patronymic)
        {
            var allData = File.ReadAllLines(Path);

            if (allData.Count() == 0)
            {
                Console.WriteLine("Таблица пуста");
                return;
            }

            for (int i = 0; i < allData.Length; i++)
            {
                var parsedData = allData[i].Split(' ');
                if (parsedData[0] == surname && parsedData[1] == name
                    && parsedData[2] == patronymic)
                {   
                    parsedData[parsedData.Length - 1 - 23] = "Отсутствует";
                    allData[i] = string.Join(" ", parsedData);
                    break;
                }
            }
            File.Delete(Path);
            File.AppendAllLines(Path, allData);
        }
    }
}
