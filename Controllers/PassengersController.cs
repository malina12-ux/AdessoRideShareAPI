using AdessoRideShareAPI.Data;
using AdessoRideShareAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace AdessoRideShareAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private AdessoRideShareDBContext _dbContext;

        public PassengersController(AdessoRideShareDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public IEnumerable<Passengers> Get()
        {
            return _dbContext.Passengers;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var passenger = _dbContext.Passengers.Find(id);
            return Ok(passenger);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Passengers passengers)
        {
            var travelPlans =
                _dbContext.TravelPlans
                .Where(tp => tp.Id == passengers.TravelPlanID)
                .Include(tp => tp.Passengers)
                .FirstOrDefault();


            if (null == travelPlans)
            {
                return NotFound("Travel Plan with ID " + passengers.TravelPlanID + " does not exist.");
            }
            if (travelPlans.isActive == false)
            {
                return Conflict("Travel Plan with ID " + passengers.TravelPlanID + " is not active.");
            }
            if (travelPlans.Seats == travelPlans.Passengers.Count)
            {
                return Conflict("Travel Plan is full!");
            }

            _dbContext.Passengers.Add(passengers);
            _dbContext.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var passenger = _dbContext.Passengers.Find(id);
            if(null == passenger) 
            {
                return NotFound("Passenger with ID " + id + "does not exist.");
            }
            _dbContext.Passengers.Remove(passenger);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
