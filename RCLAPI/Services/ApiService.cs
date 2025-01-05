using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;
using System.Text.Json;

using RCLAPI.DTO;

using Microsoft.AspNetCore.Http;


namespace RCLAPI.Services;
public class ApiService : IApiServices
{
    private readonly ILogger<ApiService> _logger;
    private readonly HttpClient _httpClient = new();

    private readonly IHttpContextAccessor _httpContextAccessor;

    JsonSerializerOptions _serializerOptions;

    private List<Produtos> produtos;

    private List<Categorias> categorias;

    private List<SubCategorias> subCategorias;

    private List<Encomendas> encomendas;

    private List<ItensEncomendados> itensEncomendados;

    private List<Favoritos> favoritos;

    private Produtos _detalhesProduto;
    
    public ApiService(ILogger<ApiService> logger, IHttpContextAccessor httpContextAccessor){
        _httpContextAccessor = httpContextAccessor;

        _logger = logger;
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        _detalhesProduto = new Produtos();
        categorias = new List<Categorias>();
        subCategorias = new List<SubCategorias>();
        produtos = new List<Produtos>();
        encomendas = new List<Encomendas>();
        itensEncomendados = new List<ItensEncomendados>();
        favoritos = new List<Favoritos>();
    }
    //private void AddAuthorizationHeader()
    //{
    //    if (!string.IsNullOrEmpty(token))
    //    {
    //        _httpClient.DefaultRequestHeaders.Authorization =
    //        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    //    }
    //}

    // ********************* Categorias  **********
    public async Task<List<Categorias>> GetCategorias(){
        string endpoint = $"api/Categorias";

        try
        {
            HttpResponseMessage httpResponseMessage = 
                await _httpClient.GetAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode){
                string content = "";

                content = await httpResponseMessage.Content.ReadAsStringAsync();
                categorias = JsonSerializer.Deserialize<List<Categorias>>(content, _serializerOptions)!;
            }
            else
                _logger.LogError($"Erro ao buscar categorias: {httpResponseMessage.ReasonPhrase}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }

        return categorias;
    }

    // ********************* SubCategorias  **********
    public async Task<List<SubCategorias>> GetSubCategorias(){
        string endpoint = "api/SubCategorias";

        try{
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode){
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                subCategorias = JsonSerializer.Deserialize<List<SubCategorias>>(content, _serializerOptions)!;
            }
            else
                _logger.LogError($"Erro ao buscar subcategorias: {httpResponseMessage.ReasonPhrase}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao buscar subcategorias: {ex.Message}");
            return null;
        }

        return subCategorias;
    }

    public async Task<List<SubCategorias>> GetSubCategoriasPorCategoria(int categoriaId){
        string endpoint = $"api/SubCategorias/categoria/{categoriaId}";

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                subCategorias = JsonSerializer.Deserialize<List<SubCategorias>>(content, _serializerOptions)!;
            }
            else
            {
                _logger.LogError($"Erro ao buscar subcategorias por categoria: {httpResponseMessage.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao buscar subcategorias por categoria: {ex.Message}");
            return null;
        }

        return subCategorias;
    }

    // ********************* Produtos  **********
    public async Task<List<Produtos>> GetAllProdutos(){
        string endpoint = "api/Produtos";

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                produtos = JsonSerializer.Deserialize<List<Produtos>>(content, _serializerOptions)!;
            }
            else
            {
                _logger.LogError($"Erro ao buscar todos os produtos: {httpResponseMessage.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao buscar todos os produtos: {ex.Message}");
            return null;
        }

        return produtos;
    }

    // Obtém produtos por categoria
    public async Task<List<Produtos>> GetProdutosPorCategoria(int categoriaId)
    {
        string endpoint = $"api/Produtos/categoria/{categoriaId}";

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                produtos = JsonSerializer.Deserialize<List<Produtos>>(content, _serializerOptions)!;
            }
            else
            {
                _logger.LogError($"Erro ao buscar produtos por categoria: {httpResponseMessage.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao buscar produtos por categoria: {ex.Message}");
            return null;
        }

        return produtos;
    }

    // Obtém produtos por subcategoria
    public async Task<List<Produtos>> GetProdutosPorSubCategoria(int subCategoriaId)
    {
        string endpoint = $"api/Produtos/subcategoria/{subCategoriaId}";

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                produtos = JsonSerializer.Deserialize<List<Produtos>>(content, _serializerOptions)!;
            }
            else
            {
                _logger.LogError($"Erro ao buscar produtos por subcategoria: {httpResponseMessage.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao buscar produtos por subcategoria: {ex.Message}");
            return null;
        }

        return produtos;
    }

    // Obtém produtos em promoção
    public async Task<List<Produtos>> GetProdutosEmPromocao()
    {
        string endpoint = "api/Produtos/empromocao";

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                produtos = JsonSerializer.Deserialize<List<Produtos>>(content, _serializerOptions)!;
            }
            else
            {
                _logger.LogError($"Erro ao buscar produtos em promoção: {httpResponseMessage.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao buscar produtos em promoção: {ex.Message}");
            return null;
        }

        return produtos;
    }

    // Obtém os produtos com mais vendas
    public async Task<List<Produtos>> GetProdutosPorComMaisVendas()
    {
        string endpoint = "api/Produtos/maisvendidos";

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                produtos = JsonSerializer.Deserialize<List<Produtos>>(content, _serializerOptions)!;
            }
            else
            {
                _logger.LogError($"Erro ao buscar produtos mais vendidos: {httpResponseMessage.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao buscar produtos mais vendidos: {ex.Message}");
            return null;
        }

        return produtos;
    }

    // Obtém os detalhes de um produto específico
    public async Task<Produtos> GetProdutoDetails(int id)
    {
        string endpoint = $"api/Produtos/{id}";

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                _detalhesProduto = JsonSerializer.Deserialize<Produtos>(content, _serializerOptions)!;
            }
            else
            {
                _logger.LogError($"Erro ao buscar detalhes do produto: {httpResponseMessage.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao buscar detalhes do produto: {ex.Message}");
            return null!;
        }

        return _detalhesProduto;
    }


    // ***************** Compras ******************
    public async Task<List<ItensEncomendados>> GetCarrinhoComprasAsync(int encomendaId){
        string endpoint = $"api/ItensEncomendados/{encomendaId}";

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                itensEncomendados = JsonSerializer.Deserialize<List<ItensEncomendados>>(content, _serializerOptions)!;
            }
            else
            {
                _logger.LogError($"Erro ao buscar itens do carrinho: {httpResponseMessage.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao buscar itens do carrinho: {ex.Message}");
            return null;
        }

        return itensEncomendados;
    }

    public async Task<(bool Data, string? ErrorMessage)> AdicionarProdutoCarrinho(int encomendaId, int produtoId, int quantidade)
    {
        string endpoint = $"api/ItensEncomendados?encomendaId={encomendaId}&produtoId={produtoId}&quantidade={quantidade}";

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync($"{AppConfig.BaseUrl}{endpoint}", null);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return (true, null);
            }
            else
            {
                string errorMessage = $"Erro ao adicionar produto ao carrinho: {httpResponseMessage.ReasonPhrase}";
                _logger.LogError(errorMessage);
                return (false, errorMessage);
            }
        }
        catch (Exception ex)
        {
            string errorMessage = $"Erro inesperado ao adicionar produto ao carrinho: {ex.Message}";
            _logger.LogError(errorMessage);
            return (false, errorMessage);
        }
    }

    public async Task<(bool Data, string? ErrorMessage)> RemoverProdutoCarrinho(int id){
        string endpoint = $"api/ItensEncomendados/{id}";

        try{
            HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return (true, null);
            }
            else
            {
                string errorMessage = $"Erro ao remover produto do carrinho: {httpResponseMessage.ReasonPhrase}";
                _logger.LogError(errorMessage);
                return (false, errorMessage);
            }
        }
        catch (Exception ex)
        {
            string errorMessage = $"Erro inesperado ao remover produto do carrinho: {ex.Message}";
            _logger.LogError(errorMessage);
            return (false, errorMessage);
        }
    }

    public async Task<(bool Data, string? ErrorMessage)> AtualizarQuantidadeProdutoCarrinho(int encomendaId, int produtoId, int quantidade)
    {
        string endpoint = $"api/ItensEncomendados?encomendaId={encomendaId}&produtoId={produtoId}&quantidade={quantidade}";

        try
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsync($"{AppConfig.BaseUrl}{endpoint}", content);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return (true, null);
            }
            else
            {
                string errorMessage = $"Erro ao atualizar quantidade do produto no carrinho: {httpResponseMessage.ReasonPhrase}";
                _logger.LogError(errorMessage);
                return (false, errorMessage);
            }
        }
        catch (Exception ex)
        {
            string errorMessage = $"Erro inesperado ao atualizar quantidade do produto no carrinho: {ex.Message}";
            _logger.LogError(errorMessage);
            return (false, errorMessage);
        }
    }

    // ****************** Encomendas ********************
    public async Task<List<Encomendas>> GetEncomendas(string utilizadorId)
    {
        string endpoint = $"api/Encomendas/{utilizadorId}"; // Endpoint ajustado conforme a necessidade de buscar encomendas do utilizador

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                encomendas = JsonSerializer.Deserialize<List<Encomendas>>(content, _serializerOptions)!;
            }
            else
            {
                _logger.LogError($"Erro ao buscar encomendas: {httpResponseMessage.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao buscar encomendas: {ex.Message}");
            return null;
        }

        return encomendas;
    }

    public async Task<Encomendas> AdicionarEncomenda(string utilizadorId)
    {
        string endpoint = $"api/Encomendas/{utilizadorId}";

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync($"{AppConfig.BaseUrl}{endpoint}", null);

            if (httpResponseMessage.IsSuccessStatusCode){
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Encomendas>(content, _serializerOptions)!;
            }
            else
            {
                _logger.LogError($"Erro ao adicionar encomenda: {httpResponseMessage.ReasonPhrase}");
                return null!;
            }
        }
        catch (Exception ex)
        {
            string errorMessage = $"Erro inesperado ao adicionar encomenda: {ex.Message}";
            _logger.LogError(errorMessage);
            return null;
        }
    }

    public async Task<(bool Data, string? ErrorMessage)> EncomendarEncomenda(string utilizadorId)
    {
        string endpoint = $"api/Encomendas/{utilizadorId}";

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsync($"{AppConfig.BaseUrl}{endpoint}", null);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return (true, null);
            }
            else
            {
                string errorMessage = $"Erro ao confirmar encomenda: {httpResponseMessage.ReasonPhrase}";
                _logger.LogError(errorMessage);
                return (false, errorMessage);
            }
        }
        catch (Exception ex)
        {
            string errorMessage = $"Erro inesperado ao confirmar encomenda: {ex.Message}";
            _logger.LogError(errorMessage);
            return (false, errorMessage);
        }
    }


    // ****************** Utilizadores ********************
    public async Task<ApiResponse<bool>> RegistarUtilizador(Utilizador novoUtilizador){
        try
        {
            string endpoint = "api/Utilizadores/RegistarUser";

            var json = JsonSerializer.Serialize(novoUtilizador, _serializerOptions);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await PostRequest($"{AppConfig.BaseUrl}{endpoint}", content);

            if (!response.IsSuccessStatusCode){
                _logger.LogError($"Erro ao enviar requisitos Http: {response.StatusCode}");
                return new ApiResponse<bool>
                {
                    ErrorMessage = $"Erro ao enviar requisição HTTP: {response.StatusCode}"
                };
            }

            return new ApiResponse<bool> { Data = true };
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao registar o utiizador: {ex.Message}");
            return new ApiResponse<bool> { ErrorMessage = ex.Message };
        }
    }
    public async Task<Token> Login(LoginModel login){
        try
        {
            string endpoint = "api/Utilizadores/LoginUser";

            var json = JsonSerializer.Serialize(login, _serializerOptions);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await PostRequest($"{AppConfig.BaseUrl}{endpoint}", content);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Erro ao enviar requisição Http: {response.StatusCode}");

            }
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Token>(jsonResult, _serializerOptions);

            return result;
        }
        catch (Exception ex)
        {
            string errorMessage = $"Erro inesperado: {ex.Message}";
            _logger.LogError(ex.Message);
            return (default);
        }

    }
    private async Task<HttpResponseMessage> PostRequest(string enderecoURL, HttpContent content){
        try
        {
            var result = await _httpClient.PostAsync(enderecoURL, content);
            return result;
        }
        catch (Exception ex)
        {
            // Log o erro ou trata conforme necessario
            _logger.LogError($"Erro ao enviar requisição POST para enderecoURL: {ex.Message}");
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }

    // *************** Gerir Favoritos ******************

    public async Task<List<Favoritos>> GetFavoritos(string utilizadorId){
        string endpoint = $"api/Favoritos/{utilizadorId}";

       // AddAuthorizationHeader();
        HttpResponseMessage response = await _httpClient.GetAsync($"{AppConfig.BaseUrl}{endpoint}");

        var responseString = await response.Content.ReadAsStringAsync();
        favoritos = JsonSerializer.Deserialize<List<Favoritos>>(responseString, _serializerOptions);

        return favoritos;

    }

    public async Task<(bool Data, string? ErrorMessage)> AddFavorito(string utilizadorId, int produtoId)
    {
        string endpoint = $"api/Favoritos/{utilizadorId}/{produtoId}"; // Endpoint ajustado conforme a lógica de favoritar

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync($"{AppConfig.BaseUrl}{endpoint}", null);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return (true, null);
            }
            else
            {
                string errorMessage = $"Erro ao adicionar favorito: {httpResponseMessage.ReasonPhrase}";
                _logger.LogError(errorMessage);
                return (false, errorMessage);
            }
        }
        catch (Exception ex)
        {
            string errorMessage = $"Erro inesperado ao adicionar favorito: {ex.Message}";
            _logger.LogError(errorMessage);
            return (false, errorMessage);
        }
    }


    public async Task<(bool Data, string? ErrorMessage)> DeleteFavorito(int id)
    {
        string endpoint = $"api/Favoritos/{id}";  // Endpoint ajustado conforme a lógica de remoção

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return (true, null);
            }
            else
            {
                string errorMessage = $"Erro ao remover favorito: {httpResponseMessage.ReasonPhrase}";
                _logger.LogError(errorMessage);
                return (false, errorMessage);
            }
        }
        catch (Exception ex)
        {
            string errorMessage = $"Erro inesperado ao remover favorito: {ex.Message}";
            _logger.LogError(errorMessage);
            return (false, errorMessage);
        }
    }

    //Pagamento
    public async Task<(bool Data, string? ErrorMessage)> AdicionarPagamento(int encomendaId){

        string endpoint = $"api/Pagamentos/{encomendaId}";

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync($"{AppConfig.BaseUrl}{endpoint}", null);

            if (httpResponseMessage.IsSuccessStatusCode){
                return (true, null);
            }
            else
            {
                string errorMessage = $"Erro ao adicionar pagamento: {httpResponseMessage.ReasonPhrase}";
                _logger.LogError(errorMessage);
                return (false, errorMessage);
            }
        }
        catch (Exception ex)
        {
            string errorMessage = $"Erro inesperado ao adicionar pagamento: {ex.Message}";
            _logger.LogError(errorMessage);
            return (false, errorMessage);
        }
    }

    public async Task<Pagamentos> GetPagamentos(int encomendaId){

        string endpoint = $"api/Pagamentos/{encomendaId}";

        try
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"{AppConfig.BaseUrl}{endpoint}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Pagamentos>(content, _serializerOptions)!;
            }
            else
            {
                _logger.LogError($"Erro ao buscar pagamentos: {httpResponseMessage.ReasonPhrase}");
                return null!;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao buscar pagamentos: {ex.Message}");
            return null!;
        }


    }
}
