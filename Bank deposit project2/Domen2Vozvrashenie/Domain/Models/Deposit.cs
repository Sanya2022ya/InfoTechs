using System.ComponentModel.DataAnnotations;

namespace Domen2Vozvrashenie.Domain.Models
{
    public class Deposit
    {

        [Key]
        public int DepositId { get; set; }
        public string DepositName { get; set; }
        public string Period { get; set; }
        public int Size { get; set; }
        public string Interest { get; set; }
        public string CIR { get; set; }
        public string Currency { get; set; }
    }
}
