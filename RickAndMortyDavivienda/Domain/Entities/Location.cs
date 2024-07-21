﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Dimension { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
    }
}
