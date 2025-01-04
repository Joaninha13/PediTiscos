namespace RCLAPI.DTO;

public class ItensEncomendados{

    public int Id { get; set; }
    public int? EncomendaId { get; set; }
    public Encomendas Encomenda { get; set; }
    public int? ProdutoId { get; set; }
    public Produto Produto { get; set; }
    public int? Quantidade { get; set; }

}
