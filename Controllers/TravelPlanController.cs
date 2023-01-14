using AdessoRideShareAPI.Data;
using AdessoRideShareAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace AdessoRideShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelPlanController : ControllerBase
    {
        private AdessoRideShareDBContext _dbContext;

        public TravelPlanController(AdessoRideShareDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public IEnumerable<TravelPlan> Get()
        {
            return _dbContext.TravelPlans;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var travelPlan = _dbContext.TravelPlans.Find(id);
            return Ok(travelPlan);
        }

        [HttpGet("[action]")]
        public IActionResult FindTravelPlan(string frm, string to, bool isActive = true)
        {
            var travelPlans = _dbContext.TravelPlans.Where(tp => tp.From == frm && tp.To == to && tp.isActive == isActive);
            return Ok(travelPlans);
        }
        [HttpGet("[action]")]
        public IActionResult GetActiveTravelPlan()
        {
            var travelPlans = _dbContext.TravelPlans.Where(tp => tp.isActive == true);
            return Ok(travelPlans);
        }

        [HttpPost]
        public void Post([FromBody] TravelPlan travelPlan)
        {
            _dbContext.TravelPlans.Add(travelPlan);
            _dbContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TravelPlan travelPlanObj)
        {
            var travelPlan = _dbContext.TravelPlans.Find(id);
            travelPlan.isActive = travelPlanObj.isActive;
            _dbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var travelPlan = _dbContext.TravelPlans.Find(id);

            if (null == travelPlan)
            {
                return NotFound("Travel plan with ID " + id + "does not exist.");
            }

            _dbContext.TravelPlans.Remove(travelPlan);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
