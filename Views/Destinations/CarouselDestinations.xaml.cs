using MauiPlanTurismo.ViewModels;

namespace MauiPlanTurismo.Views.Destinations;

public partial class CarouselDestinations : ContentPage
{
	public CarouselDestinations()
	{
		InitializeComponent();
		BindingContext = new DestinationViewModel();
	}
}