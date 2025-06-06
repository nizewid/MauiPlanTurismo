using MauiPlanTurismo.Views.Destinations;
using MauiPlanTurismo.Views.User;

namespace MauiPlanTurismo.Views.Info;

public partial class InfoApp : ContentPage
{
	public InfoApp()
	{
		InitializeComponent();
	}
    private void btnUsosHorarios_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new UsosHorarios());
    }
    private async void RegisterBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Register());
    }
    private async void TouristDestinationsBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TouristDestination());
    }
}