using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using System.Data;
using School.Domain.Models;
using System.Collections.Generic;
using System;

namespace School.Repository.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Course> Courses { get; set; }

        //método executado ao criar o banco de dados
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // criação de um relacionamento muitos para muitos
            builder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentID, ss.SubjectID });

            builder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentID, sc.CourseID });

            builder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                    new Teacher(1, 1, "Lauro", "Oliveira"),
                    new Teacher(2, 2, "Roberto", "Soares"),
                    new Teacher(3, 3, "Ronaldo", "Marconi"),
                    new Teacher(4, 4, "Rodrigo", "Carvalho"),
                    new Teacher(5, 5, "Alexandre", "Montanha"),
                });

            builder.Entity<Course>()
                .HasData(new List<Course>{
                    new Course(1, "Tecnologia da Informação"),
                    new Course(2, "Sistemas de Informação"),
                    new Course(3, "Ciência da Computação")
                });

            builder.Entity<Subject>()
                .HasData(new List<Subject>{
                    new Subject(1, "Matemática", 1, 1),
                    new Subject(2, "Matemática", 1, 3),
                    new Subject(3, "Física", 2, 3),
                    new Subject(4, "Português", 3, 1),
                    new Subject(5, "Inglês", 4, 1),
                    new Subject(6, "Inglês", 4, 2),
                    new Subject(7, "Inglês", 4, 3),
                    new Subject(8, "Programação", 5, 1),
                    new Subject(9, "Programação", 5, 2),
                    new Subject(10, "Programação", 5, 3)
                });

            builder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student(1, 1, "Marta", "Kent", "33225555", DateTime.Parse("05/28/2005")),
                    new Student(2, 2, "Paula", "Isabela", "3354288", DateTime.Parse("05/28/2005")),
                    new Student(3, 3, "Laura", "Antonia", "55668899", DateTime.Parse("05/28/2005")),
                    new Student(4, 4, "Luiza", "Maria", "6565659", DateTime.Parse("05/28/2005")),
                    new Student(5, 5, "Lucas", "Machado", "565685415", DateTime.Parse("05/28/2005")),
                    new Student(6, 6, "Pedro", "Alvares", "456454545", DateTime.Parse("05/28/2005")),
                    new Student(7, 7, "Paulo", "José", "9874512", DateTime.Parse("05/28/2005"))
                });

            builder.Entity<StudentSubject>()
                .HasData(new List<StudentSubject>() {
                    new StudentSubject() {StudentID = 1, SubjectID = 2 },
                    new StudentSubject() {StudentID = 1, SubjectID = 4 },
                    new StudentSubject() {StudentID = 1, SubjectID = 5 },
                    new StudentSubject() {StudentID = 2, SubjectID = 1 },
                    new StudentSubject() {StudentID = 2, SubjectID = 2 },
                    new StudentSubject() {StudentID = 2, SubjectID = 5 },
                    new StudentSubject() {StudentID = 3, SubjectID = 1 },
                    new StudentSubject() {StudentID = 3, SubjectID = 2 },
                    new StudentSubject() {StudentID = 3, SubjectID = 3 },
                    new StudentSubject() {StudentID = 4, SubjectID = 1 },
                    new StudentSubject() {StudentID = 4, SubjectID = 4 },
                    new StudentSubject() {StudentID = 4, SubjectID = 5 },
                    new StudentSubject() {StudentID = 5, SubjectID = 4 },
                    new StudentSubject() {StudentID = 5, SubjectID = 5 },
                    new StudentSubject() {StudentID = 6, SubjectID = 1 },
                    new StudentSubject() {StudentID = 6, SubjectID = 2 },
                    new StudentSubject() {StudentID = 6, SubjectID = 3 },
                    new StudentSubject() {StudentID = 6, SubjectID = 4 },
                    new StudentSubject() {StudentID = 7, SubjectID = 1 },
                    new StudentSubject() {StudentID = 7, SubjectID = 2 },
                    new StudentSubject() {StudentID = 7, SubjectID = 3 },
                    new StudentSubject() {StudentID = 7, SubjectID = 4 },
                    new StudentSubject() {StudentID = 7, SubjectID = 5 }
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=p@ssw0rd;Persist Security Info=True;User ID=SA;Initial Catalog=school;Data Source=localhost,1433");
        }

    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../School.API/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<Context>();
            var connectionString = configuration.GetConnectionString("Default");
            builder.UseSqlServer(connectionString);
            return new Context(builder.Options);
        }
    }


}
