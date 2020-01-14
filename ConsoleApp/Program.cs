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
