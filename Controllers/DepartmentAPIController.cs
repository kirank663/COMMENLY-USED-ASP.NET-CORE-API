using CommenReactProjectAPI.IModelRepository;
using CommenReactProjectAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CommenReactProjectAPI.Controllers
{
      [Route("api/Department")]
      [ApiController]
      public class DepartmentAPIController : ControllerBase
      {
            private readonly IDepartmentRepository _deptRepository;
            public DepartmentAPIController(IDepartmentRepository deptRepository)
            {
                  _deptRepository = deptRepository;
            }

            [HttpGet("Department")]
            public IActionResult GetDepartments()
            {
                  if(_deptRepository.GetDepartmentList().ToList().Count > 0)
                  {
                        return new JsonResult(_deptRepository.GetDepartmentList().ToList());
                  }
                  else
                  {
                        return NotFound();
                  }
            }

            [HttpGet("Department/{id}")]
            public IActionResult GetDepartmentById(int id)
            {
                  if(id == 0)
                        return BadRequest();

                  if(_deptRepository.GetDepartmentById(id).ToList().Count > 0)
                  {
                        return new JsonResult(_deptRepository.GetDepartmentList().ToList());
                  }
                  else
                  {
                        return NotFound();
                  }
            }

            [HttpPost("Department")]
            public IActionResult AddDepartment(Department department)
            {
                  MessageResponce msgResponce = new MessageResponce();
                  if(_deptRepository.AddDepartment(department) > 0)
                  {
                        msgResponce.Status = true;
                        msgResponce.Message = "Department added successfully.";
                  }
                  else
                  {
                        msgResponce.Status = false;
                        msgResponce.Message = "Failed to add department.";
                  }
                  return new JsonResult(msgResponce);
            }

            [HttpPut("Department")]
            public IActionResult UpdateDepartment(Department department)
            {
                  if(department == null)
                        return BadRequest();

                  MessageResponce msgResponce = new MessageResponce();
                  if(_deptRepository.UpdateDepartment(department) > 0)
                  {
                        msgResponce.Status = true;
                        msgResponce.Message = "Department updated successfully.";
                  }
                  else
                  {
                        msgResponce.Status = false;
                        msgResponce.Message = "Failed to updated department.";
                  }
                  return new JsonResult(msgResponce);
            }

            [HttpDelete("Department/{id}")]
            public IActionResult DeleteDepartment(int id)
            {
                  if(id == 0)
                        return BadRequest();

                  MessageResponce msgResponce = new MessageResponce();
                  if(_deptRepository.DeleteDepartment(id) > 0)
                  {
                        msgResponce.Status = true;
                        msgResponce.Message = "Department deleted successfully.";
                  }
                  else
                  {
                        msgResponce.Status = false;
                        msgResponce.Message = "Failed to delete department.";
                  }
                  return new JsonResult(msgResponce);
            }
      }
}
