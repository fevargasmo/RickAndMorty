namespace Application.DTOs
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public int OriginId { get; set; }
        public int LocationId { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
    }
}
