using RCLAPI.DTO;

namespace RCLAPI.Services;

public interface IApiServices{

    //Produtos
    public Task<List<Produtos>> GetAllProdutos();
    public Task<List<Produtos>> GetProdutosPorCategoria(int categoriaId);
    public Task<List<Produtos>> GetProdutosPorSubCategoria(int subCategoriaId);
    public Task<List<Produtos>> GetProdutosEmPromocao();
    public Task<List<Produtos>> GetProdutosPorComMaisVendas();
    public Task<Produtos> GetProdutoDetails(int id);

    //Encomenda
    public Task<List<Encomendas>> GetEncomendas(string utilizadorId);
    public Task<Encomendas> AdicionarEncomenda(string utilizadorId);
    public Task<(bool Data, string? ErrorMessage)> EncomendarEncomenda(string utilizadorId);

    //Carrinho de compras
    public Task<List<ItensEncomendados>> GetCarrinhoComprasAsync(int encomendaId);
    public Task<(bool Data, string? ErrorMessage)> AdicionarProdutoCarrinho(int encomendaId, int produtoId, int quantidade);
    public Task<(bool Data, string? ErrorMessage)> RemoverProdutoCarrinho(int id);
    public Task<(bool Data, string? ErrorMessage)> AtualizarQuantidadeProdutoCarrinho(int encomendaId, int produtoId, int quantidade);


    //Categorias
    public Task<List<Categorias>> GetCategorias();


    //subCategorias
    public Task<List<SubCategorias>> GetSubCategorias();
    public Task<List<SubCategorias>> GetSubCategoriasPorCategoria(int categoriaId);


    //Favoritos
    public Task<List<Favoritos>> GetFavoritos(string utilizadorId);
    public Task<(bool Data, string? ErrorMessage)> AddFavorito(string utilizadorId, int produtoId);
    public Task<(bool Data, string? ErrorMessage)> DeleteFavorito(int id);


    //User
    public Task<ApiResponse<bool>> RegistarUtilizador(Utilizador novoUtilizador);
    public Task<ApiResponse<bool>> Login(LoginModel login);

}
