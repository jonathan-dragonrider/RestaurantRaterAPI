using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RestaurantController : ApiController
    {
        RestaurantDbContext _context = new RestaurantDbContext();

        //-- Create (POST)
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty");
            }
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();

                return Ok("You created a restaurant and it was saved!");
            }

            return BadRequest(ModelState);
        }

        //-- Read (GET)
        // Get by ID
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant != null)
            {
                return Ok(restaurant);
            }

            return NotFound();
        }
        // Get All
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok();
        }
        //-- Update (PUT)

        //-- Delete (DELETE)
    }
}
