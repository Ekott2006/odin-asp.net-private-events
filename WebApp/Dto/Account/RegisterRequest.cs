using System.ComponentModel.DataAnnotations;

namespace WebApp.Dto.Account;

public class RegisterRequest: BaseAccountRequest
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public required string Email { get; set; }

    
}