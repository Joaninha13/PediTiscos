using PediTiscosWEBB.Components;

using RCLProdutos.Services;
using RCLProdutos.Services.Interfaces;
using RCLAPI.Services;
using RCLComum.State;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();

// Register IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

//Descomentar depois
builder.Services.AddScoped<ISliderUtilsServices, SliderUtilsServices>();
builder.Services.AddScoped<ICardsUtilsServices, CardsUtilsServices>();
builder.Services.AddScoped<IApiServices, ApiService>();
builder.Services.AddSingleton<CartState>();
builder.Services.AddSingleton<UserSessionState>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7213") }); //NECESSARIO????

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
