using Microsoft.Extensions.Logging;
using PicsApp.Services;

namespace PicsApp
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


            builder.Services.AddSingleton<SweetAlertService>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();

            
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
            };
            builder.Services.AddSingleton(new HttpClient(handler)
            {
                BaseAddress = new Uri("https://192.168.148.82:7137") // Use your actual backend address here
            });
#else
           
            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://192.168.148.82:7137") //and here
            });

#endif

            return builder.Build();

        }
    }
}
