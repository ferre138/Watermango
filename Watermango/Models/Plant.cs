using System;
using System.ComponentModel.DataAnnotations;

namespace Watermango.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        [Display(Name = "Last Watered")]
        public DateTime LastWatered { get; set; }
    }
}