using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PortourgalAPI.Models;
using PortourgalAPI.Services;

namespace PortourgalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _userService.Get();
        }

        // GET: api/Users/5
        [HttpGet("{email}", Name = "GetUser")]
        public ActionResult<User> GetByEmail(string email)
        {
            var user = _userService.GetByEmail(email);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        // POST: api/Users
        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            _userService.Create(user);
            return CreatedAtRoute("GetUser", new { email = user.Email }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(string id,User userIn)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, userIn);

            return NoContent();
        }

        // PUT: api/Users/admin
        [HttpPut("{email}")]
        public IActionResult PutByEmail(string email, User userIn)
        {
            var user = _userService.GetByEmail(email);

            if (user == null)
            {
                return NotFound();
            }

            _userService.UpdateByEmail(email, userIn);

            return NoContent();
        }


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Remove(user.Id);

            return NoContent();
        }


        // DELETE: api/Users/5
        [HttpDelete("{email}")]
        public IActionResult DeleteByEmail(string email)
        {
            var user = _userService.GetByEmail(email);

            if (user == null)
            {
                return NotFound();
            }

            _userService.RemoveByEmail(user.Email);

            return NoContent();
        }
    }
}
