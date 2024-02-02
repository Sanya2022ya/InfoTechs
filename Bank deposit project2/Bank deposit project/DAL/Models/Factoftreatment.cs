using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Factoftreatment
    {
        [Key]
        public int TreatmentId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public string ticket { get; set; }
        public string Passport { get; set; }
    }
}
