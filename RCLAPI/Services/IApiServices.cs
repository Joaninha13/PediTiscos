using RCLAPI.DTO;

namespace RCLAPI.Services;

public interface IApiServices{

    //Produtos
    public Task<List<Produto>> GetAllProdutos();
    public Task<List<Produto>> GetProdutosPorCategoria(int categoriaId);
    public Task<List<Produto>> GetProdutosPorSubCategoria(int subCategoriaId);
    public Task<List<Produto>> GetProdutosEmPromocao();
    public Task<List<Produto>> GetProdutosPorComMaisVendas();
    public Task<Produto> GetProdutoDetails(int id);

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
    public Task<List<Categoria>> GetCategorias();


    //subCategorias
    public Task<List<SubCategoria>> GetSubCategorias();
    public Task<List<SubCategoria>> GetSubCategoriasPorCategoria(int categoriaId);


    //Favoritos
    public Task<List<Favoritos>> GetFavoritos(string utilizadorId);
    public Task<(bool Data, string? ErrorMessage)> AddFavorito(string utilizadorId, int produtoId);
    public Task<(bool Data, string? ErrorMessage)> DeleteFavorito(int id);


    //User
    public Task<ApiResponse<bool>> RegistarUtilizador(Utilizador novoUtilizador);
    public Task<ApiResponse<bool>> Login(LoginModel login);

}
