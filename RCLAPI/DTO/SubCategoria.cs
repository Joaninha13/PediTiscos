using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;


namespace RCLAPI.DTO;

public class SubCategoria{

    public int Id { get; set; }
    public string? Nome { get; set; }
    public int? Ordem { get; set; }
    public int? CategoriaId { get; set; }
    public Categoria Categoria { get; set; }

    public string? UrlImagem { get; set; }
    public byte[]? Imagem { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; set; }

}
