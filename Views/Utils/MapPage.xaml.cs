using MauiPlanTurismo.ViewModels;
using System.Diagnostics;

namespace MauiPlanTurismo.Views.Utils;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
		InitializeComponent();
        BindingContext = new MapViewModel();
    }
}