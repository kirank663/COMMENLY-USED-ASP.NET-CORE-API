using CommenReactProjectAPI.Model;
using System.Collections.Generic;

namespace CommenReactProjectAPI.IModelRepository
{
      public interface IStudentRepository
      {
            List<Student> GetStudentList();

            List<Student> GetStudentById(int id);

            int AddStudent(Student student);

            int DeleteStudent(int id);

            int UpdateStudent(Student student);
      }
}
