using CommenReactProjectAPI.IModelRepository;
using CommenReactProjectAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CommenReactProjectAPI.Controllers
{
      [Route("api/Users")]
      [ApiController]
      public class UsersAPIController : ControllerBase
      {
            private readonly IUserRepository _userRepository;
            public UsersAPIController(IUserRepository userRepository)
            {
                  _userRepository = userRepository;
            }

            [HttpGet("User")]
            public IActionResult GetUser()
            {
                  if(_userRepository.GetUserList().ToList().Count > 0)
                  {
                        return new JsonResult(_userRepository.GetUserList().ToList());
                  }
                  else
                  {
                        return NotFound();
                  }
            }

            [HttpGet("User/{id}")]
            public IActionResult GetStudentById(int id)
            {
                  if(id == 0)
                        return BadRequest();

                  if(_userRepository.GetUserDetailsById(id).ToList().Count > 0)
                  {
                        return new JsonResult(_userRepository.GetUserDetailsById(id).ToList());
                  }
                  else
                  {
                        return NotFound();
                  }
            }

            [HttpPost("User")]
            public IActionResult AddUser(User user)
            {
                  if(user==null)
                        return BadRequest();

                  MessageResponce msgResponce = new MessageResponce();
                  if(_userRepository.IsUserExistIntoTable(user.Phone , user.Email))
                  {
                        msgResponce.Status = false;
                        msgResponce.Message = "User already exist.";
                        return new JsonResult(msgResponce);
                  }
                  
                  if(_userRepository.AddUser(user) > 0)
                  {
                        msgResponce.Status = true;
                        msgResponce.Message = "User added successfully.";
                  }
                  else
                  {
                        msgResponce.Status = false;
                        msgResponce.Message = "Failed to add user.";
                  }
                  return new JsonResult(msgResponce);
            }

            [HttpPut("User")]
            public IActionResult UpdateUser(User user)
            {
                  if(user == null)
                        return BadRequest();

                  MessageResponce msgResponce = new MessageResponce();
                  if(_userRepository.UpdateUser(user) > 0)
                  {
                        msgResponce.Status = true;
                        msgResponce.Message = "User updated successfully.";
                  }
                  else
                  {
                        msgResponce.Status = false;
                        msgResponce.Message = "Failed to update user.";
                  }
                  return new JsonResult(msgResponce);
            }

            [HttpDelete("User/{id}")]
            public IActionResult DeleteUser(int id)
            {
                  if(id == 0)
                        return BadRequest();

                  MessageResponce msgResponce = new MessageResponce();
                  if(_userRepository.DeleteUser(id) > 0)
                  {
                        msgResponce.Status = true;
                        msgResponce.Message = "User deleted successfully.";
                  }
                  else
                  {
                        msgResponce.Status = false;
                        msgResponce.Message = "Failed to delete user.";
                  }
                  return new JsonResult(msgResponce);
            }
      }
}
