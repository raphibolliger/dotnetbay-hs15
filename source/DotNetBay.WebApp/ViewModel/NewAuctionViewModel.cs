using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetBay.WebApp.ViewModel
{
    public class NewAuctionViewModel
    {
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start Price")]
        [Range(1, 10000)]
        public double StartPrice { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

    }
}