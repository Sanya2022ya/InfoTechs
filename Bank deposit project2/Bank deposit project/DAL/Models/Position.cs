using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Position
    {

        [Key]
        public int PositionId { get; set; }
        public string? Title { get; set; }
    }
}
