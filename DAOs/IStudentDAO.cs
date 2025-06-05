using EjsTema5.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjsTema5.DAOs
{
    public interface IStudentDAO
    {
        public void AddStudent(StudentDTO student);
        public List<StudentDTO> GetAllStudents();
        public void DeleteStudent(int id);
    }
}