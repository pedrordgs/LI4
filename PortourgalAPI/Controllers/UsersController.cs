using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("{email}")]
        public ActionResult<User> Get(string email)
        {
            var user = _userService.Get(email);

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
            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{email}")]
        public IActionResult Put(string email,User userIn)
        {
            var user = _userService.Get(email);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(email, userIn);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{email}")]
        public IActionResult Delete(string email)
        {
            var user = _userService.Get(email);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Remove(user.Id);

            return NoContent();
        }
    }
}
