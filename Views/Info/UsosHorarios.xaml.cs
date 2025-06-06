namespace MauiPlanTurismo.Views.Info;

public partial class UsosHorarios : ContentPage
{
	public UsosHorarios()
	{
		InitializeComponent();
	}
    private void Button_Clicked(object sender, EventArgs e)
    {
        Microsoft.Maui.Controls.Button btn = (Microsoft.Maui.Controls.Button)sender;
        int ajusteHoras = 0;

        switch (btn.Text)
        {
            case "Península":
                imgBandera.Source = ImageSource.FromFile("Flags//flag_espania.png");
                break;
            case "Canarias":
                imgBandera.Source = ImageSource.FromFile("Flags//flag_espania.png");
                ajusteHoras = -1;
                break;
            case "Berlín":
                imgBandera.Source = ImageSource.FromFile("Flags//flag_alemania.png");
                break;
            case "Nueva York":
                imgBandera.Source = ImageSource.FromFile("Flags//flag_usa.png");
                ajusteHoras = -6;
                break;
            case "Los Ángeles":
                imgBandera.Source = ImageSource.FromFile("Flags//flag_usa.png");
                ajusteHoras = -9;
                break;
            case "Tokio":
                imgBandera.Source = ImageSource.FromFile("Flags//flag_japon.png");
                ajusteHoras = 9;
                break;
        }

        lblHora.Text = btn.Text + ": " + DateTime.Now.AddHours(ajusteHoras).ToString("hh:mm:ss");
    }
}