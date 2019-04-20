using System.ComponentModel.DataAnnotations;

namespace PAP.Business.AccountViewModels

{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
