using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookingRoles.Models.Store
{
    public class Discount
    {
        [Key]
        public int DiscId { get; set; }
        [Display(Name = "Disc Name")]
        public string DiscName { get; set; }

        [Display(Name = "Disc Percentage")]
        public int DiscPercentage { get; set; }

        [Display(Name = "Visibilty")]
        public bool isVisible { get; set; }
    }
}