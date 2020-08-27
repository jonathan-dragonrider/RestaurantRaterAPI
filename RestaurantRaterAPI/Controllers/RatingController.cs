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
    public class RatingController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        // Create new ratings
        [HttpPost]
        public async Task<IHttpActionResult> CreateRating(Rating model)
        {
            // Check to see if the model is NOT valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the targeted restaurant
            var restaurant = await _context.Restaurants.FindAsync(model.RestaurantId);
            if (restaurant == null)
            {
                return BadRequest($"The target restaurant with the ID of {model.RestaurantId} does not exist.");
            }

            // The restaurant isn't null, so we can successfully rate it
            _context.Ratings.Add(model);
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok($"You rated {restaurant.Name} successfully!");
            }

            return InternalServerError();
        }

        // Get a rating by its ID
        [HttpGet]
        public async Task<IHttpActionResult> GetRatingById(int id)
        {
            List<Rating> ratings = await _context.Ratings.ToListAsync();
            Rating rating = ratings.FirstOrDefault(r => r.Id == id);

            if (rating != null)
            {
                return Ok(rating);
            }

            return NotFound();
        }

        // Get all ratings for a specific restaurant ID
        [HttpGet]
        public async Task<IHttpActionResult> GetRatingsByRestaurant(int restaurantId)
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok();
        }

        // Update Rating

        // Delete Rating
    }
}
