using System.ComponentModel.DataAnnotations;

namespace Betsson.WebApi.Entities
{
    public class NewAccountDetailEntity
    {
        [Required]
        public string AccountType { get; set; }

        [Required]
        public string DepositAmount { get; set; }

        [Required]
        public string CustomerId { get; set; }
    }
}