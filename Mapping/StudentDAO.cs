using EjsTema5.DAOs;
using EjsTema5.DTOs;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjsTema5.Mapping
{
    public class StudentDAO : IStudentDAO
    {
        private readonly string _ConnectionString;
        public StudentDAO(string connectionstring)
        {
            _ConnectionString = connectionstring;
        }

        public void AddStudent(StudentDTO students)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {                
                string query = "INSERT INTO Students (Id, FirstName, LastName) VALUES (@Id, @FirstName, @LastName)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", students.Id);
                    command.Parameters.AddWithValue("@FirstName", students.FirstName);
                    command.Parameters.AddWithValue("@LastName", students.LastName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<StudentDTO> GetAllStudents()
        {
            List<StudentDTO> students = new List<StudentDTO>();
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                string query = "SELECT Id, FirstName, LastName FROM Students";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);
                            students.Add(new StudentDTO(id, firstName, lastName));
                        }
                    }
                }
            }
            return students;
        }

        public void DeleteStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM Students WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}