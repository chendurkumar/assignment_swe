using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Betsson.WebApi.Entities
{
    public class AccountEntity
    {
        public int Account_Id { get; set; }

        [Required]
        public string Account_Type { get; set; }

        [Required]
        public string Account_Number { get; set; }

        [Required]
        public decimal Account_Balance { get; set; }

        public int Customer_Id { get; set; }

        [JsonIgnore]
        public bool Deleted { get; set; }
    }
}