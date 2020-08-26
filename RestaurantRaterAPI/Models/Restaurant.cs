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

        [Required]
        public double Rating { get; set; }


        // public bool IsRecommended => Rating > 3.5;
        public bool IsRecommended
        {
            get
            {
                return Rating > 3.5;

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
    }
}