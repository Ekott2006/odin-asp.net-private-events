using System.ComponentModel.DataAnnotations;

namespace WebApp.Dto.Account;

public class LoginRequest: BaseAccountRequest
{
    [Display(Name = "Remember me?")] public bool RememberMe { get; set; }
}
