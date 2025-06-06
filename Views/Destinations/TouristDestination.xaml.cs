using MauiPlanTurismo.ViewModels;

namespace MauiPlanTurismo.Views.Destinations;

public partial class TouristDestination : ContentPage
{
	public TouristDestination()
	{
		InitializeComponent();
		BindingContext = new DestinationViewModel();
	}
}