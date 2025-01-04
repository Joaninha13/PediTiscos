using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCLAPI.DTO;

// Add profile data for application users by adding properties to the ApplicationUser class
public class Utilizador
{
    public string? Nome { get; set; }

    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    public long? NIF { get; set; }

}
