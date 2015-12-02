using System.ComponentModel.DataAnnotations;

namespace Betsson.WebApi.Entities
{
    public class AuthenticationEntity
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}