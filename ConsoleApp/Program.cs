using Dal;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SchoolContext context = new SchoolContext())
            {
                Classroom c = new Classroom();
                c.Name = "Classe 1";
                c.Floor = 3;
                c.Corridor = "Rouge";
                c.Teacher = new Teacher
                {
                    FirstName = "Barney",
                    LastName = "Stinson",
                    HiringDate = DateTime.Now,
                };

                Classroom c2 = new Classroom()
                {
                    Name = "Classe 2",
                    Floor = 2,
                    Corridor = "Bleu",
                    Teacher = new Teacher()
                    {
                        FirstName = "Ted",
                        LastName = "Mosby",
                        Discipline = "Architecture 101",
                        HiringDate = new DateTime(2018, 10, 05),
                    }
                };

                context.Classrooms.Add(c);
                context.Classrooms.Add(c2);

                context.SaveChanges();

                List<Classroom> classrooms = context.Classrooms.ToList();

                foreach (Classroom item in classrooms)
                {
                    Console.WriteLine(item.Name);
                }
            }

            Console.WriteLine("OK!");
            Console.ReadLine();
        }
    }
}
