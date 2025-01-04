using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCLAPI.DTO;

// Add profile data for application users by adding properties to the ApplicationUser class
public class Utilizador
{
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O email � obrigat�rio")]
    [EmailAddress(ErrorMessage = "Endere�o de Email Inv�lido")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A indica��o da Password � obrigat�ria!")]
    public string Password { get; set; }

    [Required(ErrorMessage = "A confirma��o da Password � obrigat�ria!")]
    [Compare("Password", ErrorMessage = "A Password e a Confirma��o da Password n�o coincidem")]
    public string ConfirmPassword { get; set; }


    [ValidarNIF(ErrorMessage = "NIF inv�lido!")]
    public long? NIF { get; set; }



    // Valida��o customizada para o NIF
    public class ValidarNIF: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // Inserir o c�digo que est� no site das Finan�as
            if (value is long nif)
            {
                return nif > 100;
            }
            return false;
        }
    }
}
