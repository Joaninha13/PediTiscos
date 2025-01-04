using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCLAPI.DTO;

// Add profile data for application users by adding properties to the ApplicationUser class
public class Utilizador
{
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "Endereço de Email Inválido")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A indicação da Password é obrigatória!")]
    public string Password { get; set; }

    [Required(ErrorMessage = "A confirmação da Password é obrigatória!")]
    [Compare("Password", ErrorMessage = "A Password e a Confirmação da Password não coincidem")]
    public string ConfirmPassword { get; set; }


    [ValidarNIF(ErrorMessage = "NIF inválido!")]
    public long? NIF { get; set; }



    // Validação customizada para o NIF
    public class ValidarNIF: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // Inserir o código que está no site das Finanças
            if (value is long nif)
            {
                return nif > 100;
            }
            return false;
        }
    }
}
