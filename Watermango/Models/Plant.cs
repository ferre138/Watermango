using System;

namespace Watermango.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime LastWatered { get; set; }
    }
}