using Authentication.Service;
using EmbedIO;
using EmbedIO.Actions;
using EmbedIO.WebApi;
using OllamaSharp;
using Swan.Logging;

namespace AI.MultiModal.Maui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object? sender, EventArgs e)
        {
            try
            {
#if ANDROID
                var service = new AuthenticationService();
                await service.RegisterAsync("kevin bushiri", "test", "test@test.com");
                Android.Widget.Toast.MakeText(Android.App.Application.Context, "Registered successfully", Android.Widget.ToastLength.Long).Show();
#endif
            }
            catch (Exception ex)
            {

            }
        }

        //private static WebServer CreateWebServer(string url)
        //{
        //    var server = new WebServer(o => o
        //            .WithUrlPrefix(url)
        //            .WithMode(HttpListenerMode.EmbedIO))
        //        // First, we will configure our web server by adding Modules.
        //        .WithLocalSessionManager()
        //        .AddHuggingFaceTextEmbeddingGeneration();

        //    // Listen for state changes.
        //    server.StateChanged += (s, e) => $"WebServer New State - {e.NewState}".Info();

        //    return server;
        //}

        //private async Task  OnStartServerClicked(object? sender, EventArgs e)
        //{
        //    var server = CreateWebServer("http://localhost:11435/");
        //    await server.RunAsync();
        //    data.Text = "Server started at http://localhost:11435/";
        //}

    }
}
