using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    public class Rating
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Foreign Key (Restaurant Key)
        public int RestaurantId { get; set; }

        [Required]
        [Range(0, 10)]
        public double FoodScore { get; set; }

        [Required, Range(0, 10)]
        public double AtmosphereScore { get; set; }

        [Required][Range(0, 10)]
        public double CleanlinessScore { get; set; }

        // Add all scores and get the average out of 10
        public double AverageRating
        {
            get
            {
                var totalScore = FoodScore + AtmosphereScore + CleanlinessScore;
                return totalScore / 3;
            }
        }
    }
}