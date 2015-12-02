using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

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