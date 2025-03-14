using CommenReactProjectAPI.IModelRepository;
using CommenReactProjectAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CommenReactProjectAPI.Controllers
{
      [Route("api/Student")]
      [ApiController]
      public class StudentMgmtAPIController : ControllerBase
      {
            private readonly IStudentRepository _studentRepo;
            public StudentMgmtAPIController(IStudentRepository studentRepo)
            {
                  _studentRepo = studentRepo;
            }

            [HttpGet("Student")]
            public IActionResult GetStudent()
            {
                  if(_studentRepo.GetStudentList().Count > 0)
                  {
                        return new JsonResult(_studentRepo.GetStudentList());
                  }
                  else
                  {
                        return NotFound();
                  }
            }

            [HttpGet("Student/{id}")]
            public IActionResult GetStudentById(int id)
            {
                  if(id == 0)
                        return BadRequest();

                  if(_studentRepo.GetStudentById(id).ToList().Count > 0)
                  {
                        return new JsonResult(_studentRepo.GetStudentById(id).ToList());
                  }
                  else
                  {
                        return NotFound();
                  }
            }

            [HttpPost("Student")]
            public IActionResult AddStudent(Student student)
            {
                  if(student == null)
                        return BadRequest();

                  MessageResponce msgResponce = new MessageResponce();
                  if(_studentRepo.AddStudent(student) > 0)
                  {
                        msgResponce.Status = true;
                        msgResponce.Message = "Student added successfully.";
                  }
                  else
                  {
                        msgResponce.Status = false;
                        msgResponce.Message = "Failed to add student.";
                  }
                  return new JsonResult(msgResponce);
            }

            [HttpPut("Student")]
            public IActionResult UpdateStudent(Student student)
            {
                  if(student == null)
                        return BadRequest();

                  MessageResponce msgResponce = new MessageResponce();
                  if(_studentRepo.UpdateStudent(student) > 0)
                  {
                        msgResponce.Status = true;
                        msgResponce.Message = "Student updated successfully.";
                  }
                  else
                  {
                        msgResponce.Status = false;
                        msgResponce.Message = "Failed to update student.";
                  }
                  return new JsonResult(msgResponce);
            }

            [HttpDelete("Employee/{id}")]
            public IActionResult DeleteStudent(int id)
            {
                  if(id==0)
                        return BadRequest();

                  MessageResponce msgResponce = new MessageResponce();
                  if(_studentRepo.DeleteStudent(id) > 0)
                  {
                        msgResponce.Status = true;
                        msgResponce.Message = "Student deleted successfully.";
                  }
                  else
                  {
                        msgResponce.Status = false;
                        msgResponce.Message = "Failed to delete student.";
                  }
                  return new JsonResult(msgResponce);
            }
      }
}
