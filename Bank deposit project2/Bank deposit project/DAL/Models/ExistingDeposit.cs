using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class ExistingDeposit
    {
        [Key]
        public int AgreementId { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int DepositId { get; set; }
        public int ClientAge { get; set; }
        public int EmployeeId { get; set; }
        public string Place { get; set; }
        
    }
}
