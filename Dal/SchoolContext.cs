using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class SchoolContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        static SchoolContext()
        {
            Database.SetInitializer<SchoolContext>(new SchoolInitializer());
        }

        public SchoolContext()
            : base("SchoolDb")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        //fluent api
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classroom>().ToTable("Classroom");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Student>().ToTable("Student");

            modelBuilder.Entity<Classroom>()
                .HasRequired(c => c.Teacher)
                .WithOptional(t => t.Classroom);

            base.OnModelCreating(modelBuilder);
        }
    }
}
