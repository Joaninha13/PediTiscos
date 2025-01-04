using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


    public event Action? OnChange;

    //public CartState(Task<List<Encomendas>> idEncomenda) {
    //    Encomendas Encomenda = _apiServices.AdicionarEncomenda(_userSessionState.UserId);

    //    foreach (var item in idEncomenda)
    //    {
    //        if(item.Estado.equals)
    //        Items = _apiServices.GetCarrinhoComprasAsync(item.Id);
    //    }

    //    Items = _apiServices.GetCarrinhoComprasAsync(idEncomenda.);
    //}

    // Adiciona um item ao carrinho
    public void AddItem(ItensEncomendados item){
        Items.Add(item);
        NotifyStateChanged();
    }

    // Remove um item do carrinho
    public void RemoveItem(int produtoId){
        Items.RemoveAll(i => i.ProdutoId == produtoId);
        NotifyStateChanged();
    }

    // Limpa o carrinho
    public void ClearCart(){
        Items.Clear();
        NotifyStateChanged();
    }

    // Notifica a mudança de estado
    private void NotifyStateChanged() => OnChange?.Invoke();
}
