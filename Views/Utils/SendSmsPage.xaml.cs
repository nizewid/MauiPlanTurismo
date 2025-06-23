using System.Diagnostics;

namespace MauiPlanTurismo.Views.Utils;

public partial class SendSmsPage : ContentPage
{
	public SendSmsPage()
	{
		InitializeComponent();
	}

	private async void btnSendSms_Clicked(object sender, EventArgs e)
    {
#if ANDROID
        if (!Sms.Default.IsComposeSupported)
        {
            await DisplayAlert("No disponible", "La funcionalidad de SMS no está disponible en este dispositivo.", "OK");
            return;
        }

        try
        {
            var numbers = new List<string>();

            if (!string.IsNullOrWhiteSpace(txtTlf1.Text))
                numbers.Add(txtTlf1.Text);
            if (!string.IsNullOrWhiteSpace(txtTlf2.Text))
                numbers.Add(txtTlf2.Text);
            if (!string.IsNullOrWhiteSpace(txtTlf3.Text))
                numbers.Add(txtTlf3.Text);

            if (!numbers.Any())
            {
                await DisplayAlert("Error", "Debe ingresar al menos un número de teléfono.", "OK");
                return;
            }

            var text = txtSms.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                await DisplayAlert("Error", "Debe escribir un mensaje para enviar.", "OK");
                return;
            }

            var message = new SmsMessage(text, numbers);
            await Sms.Default.ComposeAsync(message);
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert("Error", "La funcionalidad de SMS no está disponible.", "OK");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[SMS ERROR] {ex.Message}");
            await DisplayAlert("Error", $"Error inesperado: {ex.Message}", "OK");
        }
#else
        await DisplayAlert("No disponible", "La funcionalidad de SMS solo está disponible en Android.", "OK");
#endif
    }
}