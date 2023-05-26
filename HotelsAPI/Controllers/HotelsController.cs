using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsAPI.Models;
using HotelsAPI.Repository.Hotel;
using Microsoft.AspNetCore.Authorization;

namespace HotelsAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsRepo hotelsRepo;

        public HotelsController(IHotelsRepo hotelsRepo)
        {
            this.hotelsRepo = hotelsRepo;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotels>>> Gethotels()
        {
            return await hotelsRepo.Gethotels();
   
        }

       
        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotels>> GetHotelById(int id)
        {
            try
            {
                var hotel = await hotelsRepo.GetHotelById(id);
                return Ok(hotel);
            }

            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Hotels>>> UpdateHotel (int id, Hotels hot)
        {
           
            try
            {
               var hotel = await hotelsRepo.UpdateHotel(id,hot);
                return Ok(hotel);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<List<Hotels>>> AddHotel(Hotels hot)
        {
            var hotel= await hotelsRepo.AddHotel(hot);
            return Ok(hotel);
        }

        // DELETE: api/Hotels/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Hotels>>> DeleteHotelById(int id)
        {
            try
            {
                var hotel = await hotelsRepo.DeleteHotelById(id);
                return Ok(hotel);   
            }
            catch(ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

 
        
    }
}
