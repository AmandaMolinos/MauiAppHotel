using Microsoft.Extensions.DependencyInjection;

namespace MauiAppHotel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var paginaInicial = new NavigationPage(
                new Views.ContratacaoHospedagem()
            );

            var janela = new Window(paginaInicial)
            {
                Height = 960,
                Width = 540
            };

            return janela;
        }
    }
}