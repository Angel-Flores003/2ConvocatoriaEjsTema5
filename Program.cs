using EjsTema5.DAOs;
using EjsTema5.DTOs;
using EjsTema5.Mapping;

namespace EjsTema5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();

            context.Database.EnsureCreated();

            context.Students.Add(new StudentDTO(1, "John", "Doe"));
            context.SaveChanges();

            foreach (var student in context.Students)
            {
                Console.WriteLine($"Id: {student.Id}, FirstName: {student.FirstName}, LastName: {student.LastName}");
            }
        }
    }
}