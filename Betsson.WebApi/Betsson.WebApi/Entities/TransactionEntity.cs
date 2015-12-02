using System.ComponentModel.DataAnnotations;

namespace Betsson.WebApi.Entities
{
    public class TransactionEntity
    {
        [Required]
        public int AccountId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public bool IsDeposit { get; set; }

        public string Message { get; set; }

        public string Details { get; set; }
    }
}