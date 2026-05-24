using Microsoft.Extensions.Options;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{

	App PropriedadesApp;
	public ContratacaoHospedagem()
	{
		InitializeComponent();

		PropriedadesApp = (App)Application.Current;

		pckQuarto.ItemsSource = PropriedadesApp.lista_quartos;

		dtpInicio.MinimumDate = DateTime.Now;
		dtpFinal.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpFinal.MinimumDate = ((DateTime)dtpInicio.Date).AddDays(1);
        dtpFinal.MaximumDate = ((DateTime)dtpInicio.Date).AddMonths(6);

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		try
		{

			Navigation.PushAsync(new HospedagemContratada());

		}
		catch (Exception ex)
		{
			DisplayAlertAsync("Ops", ex.Message, "OK");

		}
		         
		
    }

    private async void Sobre_Clicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new Sobre());
    }

    private void dtpInicio_DateSelected(object sender, DateChangedEventArgs e)
    {
		DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_inicio = elemento.Date.Value;

        dtpFinal.MinimumDate = data_selecionada_inicio.AddDays(1);
        dtpFinal.MaximumDate = data_selecionada_inicio.AddMonths(6);
    }
}