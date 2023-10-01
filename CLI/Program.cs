
using builder;
using DBMS.Application.Commands;
using DBMS.Domain;
using Main;
using Microsoft.Extensions.DependencyInjection;

var builder = new ConcreteBuilder();
var services = new ServiceCollection();



var studentController = new StudentController(new TableCommands<Student>(), "Students.txt");
var cli = new CLI(studentController);
cli.Center();

