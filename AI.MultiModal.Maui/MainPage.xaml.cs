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
            var uri = new Uri("http://localhost:11435/");
            var ollama = new OllamaApiClient(uri);
            // select a model which should be used for further operations
            ollama.SelectedModel = "gemma3:270m";


            await foreach (var status in ollama.PullModelAsync("gemma3:270m"))
                data.Text = ($"{status.Percent}% {status.Status}");
            data.Text = "Model downloaded successfully!";
            await Task.Delay(1500);
            data.Text = "";
            await foreach (var stream in ollama.GenerateAsync("How are you today?"))
                data.Text +=(stream.Response);
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
