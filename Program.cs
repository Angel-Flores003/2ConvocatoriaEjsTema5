using EjsTema5.DAOs;
using EjsTema5.DTOs;
using EjsTema5.Mapping;

namespace EjsTema5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=EjsTema5;Integrated Security=True";
            IStudentDAO studentDAO = new StudentDAO(connectionString);

            // Afegir estudiant
            StudentDTO newStudent = new StudentDTO(1, "John", "Doe");
            studentDAO.AddStudent(newStudent);

            Console.WriteLine("Student added successfully.");

            //Mostrar estudiants
            List<StudentDTO> students = studentDAO.GetAllStudents();
            Console.WriteLine("List of students:");
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, First Name: {student.FirstName}, Last Name: {student.LastName}");
            }

            // Eliminar estudiant
            int studentIdToDelete = 1; // Assuming we want to delete the student with Id 1
            studentDAO.DeleteStudent(studentIdToDelete);
            Console.WriteLine($"Student with Id {studentIdToDelete} deleted successfully.");
        }
    }
}