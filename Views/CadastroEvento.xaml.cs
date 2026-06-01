using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class CadastroEvento : ContentPage
{
    public CadastroEvento()
    {
        InitializeComponent();

        dtpInicio.MinimumDate = DateTime.Now;
        dtpTermino.MinimumDate = DateTime.Now.AddDays(1);
    }

    private async void CadastrarEvento_Clicked(object sender, EventArgs e)
    {
        try
        {
            Evento evento = new Evento
            {
                NomeEvento = txtNomeEvento.Text,

                DataInicio = dtpInicio.Date.Value,

                DataTermino = dtpTermino.Date.Value,

                NumeroParticipantes =
                    Convert.ToInt32(stpParticipantes.Value),

                            LocalEvento = txtLocal.Text,

                            CustoPorParticipante =
                    Convert.ToDouble(txtCusto.Text)
            };

            await Navigation.PushAsync(
                new ResumoEvento()
                {
                    BindingContext = evento
                });
        }
        catch (Exception ex)
        {
            await DisplayAlert(
                "Erro",
                ex.Message,
                "OK");
        }
    }
}