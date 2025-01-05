using Microsoft.Extensions.Logging;
using RCLAPI.Services;
using RCLComum.State;
using RCLProdutos.Services.Interfaces;
using RCLProdutos.Services;

namespace PeditiscosMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            //// Add services to the container.
            //builder.Services.AddRazorComponents()
            //    .AddInteractiveServerComponents();

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddHttpClient();

            // Register IHttpContextAccessor
            builder.Services.AddHttpContextAccessor();

            //Descomentar depois
            builder.Services.AddScoped<ISliderUtilsServices, SliderUtilsServices>();
            builder.Services.AddScoped<ICardsUtilsServices, CardsUtilsServices>();
            builder.Services.AddScoped<IApiServices, ApiService>();
            builder.Services.AddSingleton<UserSessionState>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7213") }); //NECESSARIO????

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
