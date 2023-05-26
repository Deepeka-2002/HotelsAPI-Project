using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsAPI.Models;
using HotelsAPI.Repository.Hotel;
using HotelsAPI.Repository.Reservation;
using Microsoft.AspNetCore.Authorization;

namespace HotelsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationsRepo reservationsRepo;

        public ReservationsController(ReservationsRepo reservationsRepo)
        {
            this.reservationsRepo = reservationsRepo;
        }

        // GET: api/Reservations
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservations>>> GetReservationDetails()
        {
            return await reservationsRepo.GetReservationDetails();

        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservations>> GetReservationDetailById(int id)
        {
            try
            {
                var res = await reservationsRepo.GetReservationDetailById(id);
                return Ok(res);
            }

            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Reservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Reservations>>> UpdateReservationDetail(int id, Reservations reserve)
        {

            try
            {
                var res = await reservationsRepo.UpdateReservationDetail(id,reserve);
                return Ok(res);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }


        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<Reservations>>> AddReservationDetail(Reservations reserve)
        {
            var res = await reservationsRepo.AddReservationDetail(reserve);
            return Ok(res);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Reservations>>> DeleteReservationDetailById(int id)
        {
            try
            {
                var res = await reservationsRepo.DeleteReservationDetailById(id);
                return Ok(res);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
