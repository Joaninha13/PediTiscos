
using Microsoft.AspNetCore.Components;
using RCLAPI.DTO;
using RCLAPI.Services;

namespace RCLComum.State;

public class CartState{
    public List<ItensEncomendados> Items { get; private set; } = new();

    [Inject]
    public IApiServices? _apiServices { get; set; }
    [Inject]
    public UserSessionState? _userSessionState { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }


    public event Action? OnChange;

    public CartState(){

        if (_userSessionState.UserId == null){
            NavigationManager.NavigateTo("/modalogin");
            return;
        }

        var idEncomenda = _apiServices.AdicionarEncomenda(_userSessionState.UserId);

        Items = _apiServices.GetCarrinhoComprasAsync(idEncomenda.Result.Id).Result;

    }

    // Adiciona um item ao carrinho
    public void AddItem(ItensEncomendados item){



        NotifyStateChanged();
    }

    // Remove um item do carrinho
    public void RemoveItem(int produtoId){



        NotifyStateChanged();
    }

    // Limpa o carrinho
    public void ClearCart(){



        NotifyStateChanged();
    }

    // Notifica a mudança de estado
    private void NotifyStateChanged() => OnChange?.Invoke();
}
