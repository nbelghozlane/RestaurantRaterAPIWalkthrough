using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class RatingController : ApiController
    {

        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        // Create new ratings
        //POST api/Rating
        [HttpPost]
        public async Task<IHttpActionResult> CreateRating(Rating model)
        {
            //Check if model is null
            if (model is null)
                return BadRequest("Your request body cannot be empty.");

            //Check if ModelState is invalid
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Find the Restaurant by the model.RestaurantId and see that it exists
            var restaurantEntity = await _context.Restaurants.FindAsync(model.RestaurantId);
            if (restaurantEntity is null)
                return BadRequest($"The target restaurant with the ID of {model.RestaurantId} does not exist.");

            //Create the rating


            //Add to the rating table            Another way to create the rating
            // _context.Ratings.Add(model);

            //Add to the Restaurant entity
            restaurantEntity.Ratings.Add(model);
            if (await _context.SaveChangesAsync() == 1)
                return Ok($"You rated restaurant {restaurantEntity.Name} successfully!");

            return InternalServerError();
        }

        //Get a rating by its ID

        //Get ALL Ratings

        //Get ALL Ratings for a specific restaurant by restaurant ID

        // Update a rating

        // Delete a rating
    }
}
