using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsAPI.Models;
using HotelsAPI.Repository.Users;
using HotelsAPI.Repository.Hotel;

namespace HotelsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo userRepo;

        public UsersController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetuserDetails()
        {
            return await userRepo.GetuserDetails();

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                var users = await userRepo.GetUserById(id);
                return Ok(users);
            }

            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User user)
        {

            try
            {
                var users = await userRepo.UpdateUser(id, user);
                return Ok(users);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            var users = await userRepo.AddUser(user);
            return Ok(users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteuserById(int id)
        {
            try
            {
                var users = await userRepo.DeleteUserById(id);
                return Ok(users);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
