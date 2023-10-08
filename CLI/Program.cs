//using DBMS.Application.Interfaces;
//using DBMS.Application.Tables;
//using DBMS.Domain;
//using Infrastructure;
//using Main.Controllers;
//using Microsoft.EntityFrameworkCore.Metadata.Conventions;
//using Microsoft.Extensions.DependencyInjection;

//var services = new ServiceCollection();
//var appDbContext = new ApplicationDbContext();


//Console.WriteLine("1->create db\n" +
//                  "2->delete db\n" +
//                  "3->open db\n" +
//                  "4->Get all directories\n" +
//                  "5->switch db\n" +
//                  "6->show current db\n" +
//                  "10->Work with data\n");
//while (true)
//{
//    string path;
//    var a = Console.ReadLine();
//    switch (a)
//    {
//        case "1":
//            Console.WriteLine("Write name of db: ");
//            path = Console.ReadLine();
//            appDbContext.CreateDataBase(Path.Combine(Directory.GetCurrentDirectory(), path));
//            break;

//        case "2":
//            Console.WriteLine("Write name to delete: ");
//            path = Console.ReadLine();
//            appDbContext.DeleteDataBase(Path.Combine(Directory.GetCurrentDirectory(), path));
//            break;

//        case "3":
//            Console.WriteLine("Write name to open: ");
//            path = Console.ReadLine();
//            appDbContext.OpenDataBase(Path.Combine(Directory.GetCurrentDirectory(), path));
//            break;

//        case "4":
//            appDbContext.ShowAllDataBases(Directory.GetCurrentDirectory());
//            break;

//        case "5":
//            Console.WriteLine("Write name to switch: ");
//            path = Console.ReadLine();
//            appDbContext.SwitchDataBase(Path.Combine(Directory.GetCurrentDirectory(), path));
//            break;

//        case "6":
//            appDbContext.ShowCurrentDataBase();
//            break;

//        case "10":
//            Console.WriteLine("Write table name: \n");
//            var tableName = Console.ReadLine();
//            switch (tableName)
//            {
//                case "s":
//                    appDbContext.DataBase.Students.UpdateById(12, "12 aaa kdsadr ddsdmitr", new CancellationToken());
//                    break;

//                case "v":
//                    break;

//                case "sv":
//                    break;

//                case "svm":
//                    break;

//                default:
//                    return;
//            }
//            break;
//        default:
//            return;
//    }
//}