using System.ComponentModel.DataAnnotations;

namespace Domen2Vozvrashenie.Domain.Models
{
    public class Position
    {

        [Key]
        public int PositionId { get; set; }
        public string? Title { get; set; }

    }
}
