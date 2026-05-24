using MauiAppHotel.Models;

using Microsoft.Extensions.DependencyInjection;

namespace MauiAppHotel
{
    public partial class App : Application
    {
        public List<Quarto> lista_quartos = new List<Quarto>
        {
            new Quarto()
            {
                Descricao = "Casal Simples",
                ValorDiariaAdulto = 50.0,
                ValorDiariaCrianca = 25.0
            },
             new Quarto()
            {
                Descricao = "Casal Chique",
                ValorDiariaAdulto = 100.0,
                ValorDiariaCrianca = 50.0
            },
             new Quarto()
            {
                Descricao = "Suíte Simples",
                ValorDiariaAdulto = 150.0,
                ValorDiariaCrianca = 75.0
            },
             new Quarto()
            {
                Descricao = "Suíte Chique",
                ValorDiariaAdulto = 200.0,
                ValorDiariaCrianca = 100.0
            }
        };
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