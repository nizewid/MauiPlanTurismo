using MauiPlanTurismo.ViewModels;

namespace MauiPlanTurismo.Views.Options;

public partial class DestinyListWithoutEnd : ContentPage
{
    public DestinyListWithoutEnd()
    {
        InitializeComponent();
        BindingContext = new MultipleDestinationsViewModel();
    }

    private async void OnFavoriteInvoked(object sender, EventArgs e)
    {
        await DisplayAlert("SwipeView", "Marcado como favorito.", "OK");
    }

    private async void OnMarkInvoked(object sender, EventArgs e)
    {
        await DisplayAlert("SwipeView", "has marcado el item.", "OK");
    }

    private async void OnDismissInvoked(object sender, EventArgs e)
    {
        await DisplayAlert("SwipeView", "has descartado el elemento.", "OK");
    }
}
