using EjsTema5.DTOs;

namespace EjsTema5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentDTO student = new StudentDTO(1, "John", "Doe");
            Console.WriteLine($"Student ID: {student.Id}, Name: {student.FirstName} {student.LastName}");
        }
    }
}