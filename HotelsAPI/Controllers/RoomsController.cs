using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsAPI.Models;
using HotelsAPI.Repository.Room;
using HotelsAPI.Repository.Hotel;
using Microsoft.AspNetCore.Authorization;

namespace HotelsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsRepo roomsRepo;

        public RoomsController(IRoomsRepo roomsRepo)
        {
           this.roomsRepo = roomsRepo;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rooms>>> GetRoomDetails()
        {
            return await roomsRepo.GetRoomDetails();

        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rooms>> GetRoomDetailById(int id)
        {
            try
            {
                var room = await roomsRepo.GetRoomDetailById(id);
                return Ok(room);
            }

            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Rooms>>> UpdateRoomDetail(int id, Rooms roomm)
        {

            try
            {
                var room = await roomsRepo.UpdateRoomDetail(id, roomm);
                return Ok(room);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<List<Rooms>>> AddRoomDetail(Rooms roomm)
        {
            var room = await roomsRepo.AddRoomDetail(roomm);
            return Ok(room);
        }

        // DELETE: api/Rooms/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Rooms>>> DeleteRoomDetailById(int id)
        {
            try
            {
                var room = await roomsRepo.DeleteRoomDetailById(id);
                return Ok(room);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
