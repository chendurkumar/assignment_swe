using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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