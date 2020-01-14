using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dal
{
    internal class SchoolInitializer : DropCreateDatabaseAlways<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            #region Classrooms
            var classrooms = new List<Classroom>()
            {
                new Classroom
                {
                    Name = "Salle Bill Gates",
                    Floor = 5,
                    Corridor = "Rouge",
                },
                new Classroom
                {
                    Name = "Salle Scott Hanselman",
                    Floor = 3,
                    Corridor = "Bleu",
                },
            };
            context.Classrooms.AddRange(classrooms);
            #endregion

            #region Teachers
            var teachers = new List<Teacher>()
            {
                new Teacher()
                {
                    FirstName = "Barney",
                    LastName = "Stinson",
                    Discipline = "Economie",
                    HiringDate = new DateTime(2008, 08, 30),
                    Classroom = classrooms[0],
                },
                new Teacher()
                {
                    FirstName = "Perry",
                    LastName = "Cox",
                    Discipline = "Medecine",
                    HiringDate = new DateTime(2000, 05, 15),
                    Classroom = classrooms[1],
                },
            };
            context.Teachers.AddRange(teachers);
            #endregion

            #region Students
            var students = new List<Student>()
            {
                new Student()
                {
                    FirstName = "Ted",
                    LastName = "Mosby",
                    Average = 12.0,
                    IsClassDelegate = false,
                    Classroom = classrooms[0],
                },
                new Student()
                {
                    FirstName = "John",
                    LastName = "Dorian",
                    Average = 19.0,
                    IsClassDelegate = true,
                    Classroom = classrooms[0],
                },
                new Student()
                {
                    FirstName = "Marshall",
                    LastName = "Eriksen",
                    Average = 9.0,
                    IsClassDelegate = false,
                    Classroom = classrooms[0],
                },
                new Student()
                {
                    FirstName = "Robin",
                    LastName = "Scherbatsky",
                    Average = 13.0,
                    IsClassDelegate = false,
                    Classroom = classrooms[1],
                },
                new Student()
                {
                    FirstName = "Lily",
                    LastName = "Aldrin",
                    Average = 14.0,
                    IsClassDelegate = false,
                    Classroom = classrooms[1],
                },
            };

            context.Students.AddRange(students);
            #endregion

            base.Seed(context);
        }
    }
}
