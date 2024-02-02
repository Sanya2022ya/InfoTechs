using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
    }
}
