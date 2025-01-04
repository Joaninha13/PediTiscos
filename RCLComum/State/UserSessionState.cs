using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLComum.State;

public class UserSessionState{

    public string? UserId { get; set; }
    public string? Token { get; set; }
    public string? UserName { get; set; }

    public event Action? OnChange;

    public bool IsAuthenticated => !string.IsNullOrEmpty(UserId);

    public void Logout(){
        UserId = null;
        Token = null;
        UserName = null;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
