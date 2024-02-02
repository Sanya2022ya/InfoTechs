using System.ComponentModel.DataAnnotations;

namespace Domen2Vozvrashenie.Domain.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
    }
}
