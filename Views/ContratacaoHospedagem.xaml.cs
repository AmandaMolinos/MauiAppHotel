using Microsoft.Extensions.Options;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	public ContratacaoHospedagem()
	{
		InitializeComponent();

		var listaQuarto = new List<Models.Quarto>();

		listaQuarto.Add(new Models.Quarto { Nome = "Casal Simples", Valor = 50 });
		listaQuarto.Add(new Models.Quarto { Nome = "Casal Chique", Valor = 100 });
		listaQuarto.Add(new Models.Quarto { Nome = "Suíte Simples", Valor = 150 });
		listaQuarto.Add(new Models.Quarto { Nome = "Suíte Chique", Valor = 200 });

		pckQuarto.ItemsSource = listaQuarto;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		int dias;
		dias = dtpFinal.Date.Value.Subtract(dtpInicio.Date.Value).Days;

		double valor;
		valor = dias * ((Models.Quarto)pckQuarto.SelectedItem).Valor;
		valor *= (stpAdultos.Value + stpCriancas.Value/2);
		DisplayAlertAsync("Valor da diária", "Deu R$ " + valor, "OK");
    }

    private async void Sobre_Clicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new Sobre());
    }

}