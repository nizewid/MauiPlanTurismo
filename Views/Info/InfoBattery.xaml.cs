using MauiPlanTurismo.ViewModels;

namespace MauiPlanTurismo.Views.Info;

public partial class InfoBattery : ContentPage
{
    BatteryViewModel batteryViewModel = new BatteryViewModel();
    public InfoBattery()
	{
		InitializeComponent();
        BindingContext = batteryViewModel;
    }

}