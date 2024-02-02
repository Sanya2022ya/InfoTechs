using System.ComponentModel.DataAnnotations;

namespace Domen2Vozvrashenie.Domain.Models
{
    public class Factoftreatment
    {
        [Key]
        public int TreatmentId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public string ticket { get; set; }
        public string Passport { get; set; }
        public Employee? Employee { get; set; }
        public Client? Client { get; set; }
    }
}
