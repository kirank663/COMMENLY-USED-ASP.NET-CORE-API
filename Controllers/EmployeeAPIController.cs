using CommenReactProjectAPI.IModelRepository;
using CommenReactProjectAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CommenReactProjectAPI.Controllers
{
      [Route("api/Employee")]
      [ApiController]
      public class EmployeeAPIController : ControllerBase
      {
            private readonly IEmployeeRepository _empIRepository;
            public EmployeeAPIController(IEmployeeRepository empIRepository)
            {
                  _empIRepository = empIRepository;
            }

            [HttpGet("Employee")]
            public IActionResult GetEmployees()
            {
                  if(_empIRepository.GetEmployeesList().ToList().Count > 0)
                  {
                        return new JsonResult(_empIRepository.GetEmployeesList().ToList());
                  }
                  else
                  {
                        return NotFound();
                  }
            }

            [HttpGet("Employee/{id}")]
            public IActionResult GetEmployeeById(int id)
            {
                  if(id == 0)
                        return BadRequest();

                  if(_empIRepository.GetEmployeeById(id).ToList().Count > 0)
                  {
                        return new JsonResult(_empIRepository.GetEmployeeById(id).ToList());
                  }
                  else
                  { 
                        return NotFound();
                  }
            }

            [HttpPost("Employee")]
            public IActionResult AddEmployee(Employee employee)
            {
                  if(employee == null)
                        return BadRequest();

                  MessageResponce msgResponce = new MessageResponce();
                  if(_empIRepository.UpdateEmployee(employee) > 0)
                  {
                        msgResponce.Status = true;
                        msgResponce.Message = "Employee added successfully.";
                  }
                  else
                  {
                        msgResponce.Status = false;
                        msgResponce.Message = "Failed to add employee.";
                  }
                  return new JsonResult(msgResponce);
            }

            [HttpPut("Employee")]
            public IActionResult UpdateEmployee(Employee employee)
            {
                  if(employee == null)
                        return BadRequest();

                  MessageResponce msgResponce = new MessageResponce();
                  if(_empIRepository.UpdateEmployee(employee) > 0)
                  {
                        msgResponce.Status = true;
                        msgResponce.Message = "Employee updated successfully.";
                  }
                  else
                  {
                        msgResponce.Status = false;
                        msgResponce.Message = "Failed to update employee.";
                  }
                  return new JsonResult(msgResponce);
            }

            [HttpDelete("Employee/{id}")]
            public IActionResult DeleteEmployee(int id)
            {
                  if(id == 0)
                        return BadRequest();

                  MessageResponce msgResponce = new MessageResponce();
                  if(_empIRepository.DeleteEmployee(id) > 0)
                  {
                        msgResponce.Status = true;
                        msgResponce.Message = "Employee deleted successfully.";
                  }
                  else
                  {
                        msgResponce.Status = false;
                        msgResponce.Message = "Failed to delete employee.";
                  }
                  return new JsonResult(msgResponce);
            }
      }
}
