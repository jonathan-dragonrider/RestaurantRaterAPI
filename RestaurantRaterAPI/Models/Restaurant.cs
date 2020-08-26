using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    // Restaurant Entity (The class that gets stored in the database)
    public class Restaurant
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Rating
        {
            get
            {
                // Calculate a total average score based on Ratings
                double totalAverageRating = 0;
                foreach (var rating in Ratings)
                {
                    totalAverageRating += rating.AverageRating;
                }

                // Return Average of Total if the count is above 0
                return (Ratings.Count > 0) ? totalAverageRating / Ratings.Count : 0;
            }
        }

        // Average Food Score
        public double FoodScore
        {
            get
            {
                double totalAverageFoodScore = 0;
                foreach (var rating in Ratings)
                {
                    totalAverageFoodScore += rating.FoodScore;
                }

                return (Ratings.Count > 0) ? totalAverageFoodScore / Ratings.Count : 0;
            }
        }

        // Average Atmosphere Score
        public double AtmosphereScore
        {
            get
            {
                IEnumerable<double> scores = Ratings.Select(rating => rating.AtmosphereScore);

                double totalAtmsosphereScore = scores.Sum();

                return (Ratings.Count > 0) ? totalAtmsosphereScore / Ratings.Count : 0;
            }
        }
        // Average Cleanliness Score
        public double CleanlinessScore
        {
            get
            {
                var totalCleanlinessScore = Ratings.Select(r => r.CleanlinessScore).Sum();
                return (Ratings.Count > 0) ? totalCleanlinessScore / Ratings.Count : 0;
            }
        }



        // public bool IsRecommended => Rating > 3.5;
        public bool IsRecommended
        {
            get
            {
                return Rating >= 7.5;

                //return (Rating > 3.5) ? true : false;

                //if (Rating > 3.5)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
        }

        // All of the associated Rating objects from the database
        // based on the Foreign Key relationship
        // magic
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}