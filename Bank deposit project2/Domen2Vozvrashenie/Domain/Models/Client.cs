using System.ComponentModel.DataAnnotations;

namespace Domen2Vozvrashenie.Domain.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string? Passport { get; set; }
        public string? Ticket { get; set; }
    }
}

