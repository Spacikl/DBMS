
//using Infrastructure;
//using Main.Controllers;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace Main
//{
//    public static class CLI
//    {
//        //string preview = "Oprion:\n1->Add new Student" +
//        //    "\n2->Find student by ID" +
//        //    "\n3->Delete student by ID" +
//        //    "\n4->Create new database" +
//        //    "\n5->Open exisiting database" +
//        //    "\n0->Exit";

//       //// private readonly StudentController _studentController;
//       // private readonly DataBaseController _dataBaseController;
//       // public CLI(StudentController studentController,
//       //     DataBaseController dataBaseController)
//       // {
//       //    // _studentController = studentController;
//       //     _dataBaseController = dataBaseController;
//       // }
//        public static void Center()
//        {
//            var option = Console.ReadLine();
//            while (true)
//            {
//                string id;
//                switch (option)
//                {
                    
//                    case "1":
//                        Console.WriteLine("Write name, surname, patronymic:\n ");
//                        var studentData = Console.ReadLine();
//                        var data = studentData.Split(' ').ToList();
//                        _studentController.CreateStudent(name: data[0],
//                            surname: data[1], patronymic: data[2]);
//                        break;

//                    case "2":
//                        Console.WriteLine("Write ID for finding: ");
//                        id = Console.ReadLine();
//                        _studentController.FindStudentById(id);
//                        break;

//                    case "3":
//                        Console.WriteLine("Write ID for deleting: ");
//                        id = Console.ReadLine();
//                        _studentController.DeleteStudentById(id);
//                        break;
                        
//                    case "4":
//                        Console.WriteLine("Write path: ");
//                        var path = Console.ReadLine();
//                        //_dataBaseController.CreateNewDataBase(path);
//                        break;

//                    case "5":

//                        break;

//                    case "0":
//                        return;

//                    default:
//                        Console.WriteLine(preview);
//                        break;
//                }
//            }
//        }
//    }
//}
