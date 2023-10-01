using DBMS.Application.Commands;
using DBMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    
    public class StudentController
    {
        private readonly TableCommands<Student> _commands;
        private readonly string _path;
        public StudentController(TableCommands<Student> commands, string dbStudents)
        {
            _commands = commands;
            _path = Path.Combine(Environment.CurrentDirectory, dbStudents);
        }

        public void CreateStudent(string name, 
            string surname, string patronymic)
        {
            var student = new Student();
            student.Name = name;
            student.Surname = surname;
            student.Patronymic = patronymic;
            student.Id = Guid.NewGuid();
            _commands.WriteEntityInFile(student, _path);
        }

        public void DeleteStudentById(string id)
        {
            if (_commands.DeleteEntity(id,_path).Result)
                Console.WriteLine("Student was deleted!");
            else Console.WriteLine("Student wasn't found!");
    }
        
        public void UpdateStudentById(Guid id)
        {
            
        }
        
        public void FindStudentById(string id)
        {
            var student = _commands.FindEntity(id, _path).Result;
            if (student == null) 
                Console.WriteLine("NOT FOUND");
            Console.WriteLine($"Found: {student}");
        }
}

