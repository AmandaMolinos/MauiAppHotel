using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    public ContratacaoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pckQuarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpInicio.MinimumDate = DateTime.Now;

        dtpFinal.MinimumDate = dtpInicio.Date.Value.AddDays(1);
        dtpFinal.MaximumDate = dtpInicio.Date.Value.AddMonths(6);
    }

    public App? PropriedadesApp { get; private set; }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pckQuarto.SelectedItem,
                QtdAdultos = Convert.ToInt32(stpAdultos.Value),
                QtdCriancas = Convert.ToInt32(stpCriancas.Value),
                DataCheckIn = dtpInicio.Date.Value,
                DataCheckOut = dtpFinal.Date.Value,
            };

            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    private async void Sobre_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }

    private void dtpInicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime dataSelecionada = elemento.Date.Value;

        dtpFinal.MinimumDate = dataSelecionada.AddDays(1);
        dtpFinal.MaximumDate = dataSelecionada.AddMonths(6);

        if (dtpFinal.Date < dtpFinal.MinimumDate)
        {
            dtpFinal.Date = dtpFinal.MinimumDate;
        }
    }

    private async void Evento_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroEvento());
    }

}