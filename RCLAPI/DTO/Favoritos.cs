
namespace RCLAPI.DTO;
public class Favoritos
{
    public int Id { get; set; }
    public string ClienteId { get; set; }
    public int ProdutoId { get; set; }
    public Produtos Produto { get; set; }
}
