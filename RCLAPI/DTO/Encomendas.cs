
namespace RCLAPI.DTO;

public class Encomendas{

    public int Id { get; set; }

    public string? ClienteId { get; set; }

    public DateTime DataEncomenda { get; set; }

    public string? Estado { get; set; } //Processamento, Concluido, Confirmado, Rejeitado

    public decimal? Total { get; set; }

}
