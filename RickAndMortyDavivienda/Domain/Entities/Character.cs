using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public int? OriginId { get; set; }
        [ForeignKey("OriginId")]
        public Location? Origin { get; set; }
        public int? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location? Location { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
    } 
}
