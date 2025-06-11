using MauiPlanTurismo.Views.Destinations;
using MauiPlanTurismo.Views.User;
using System.Numerics;

namespace MauiPlanTurismo.Views.Info;

public partial class InfoApp : ContentPage
{
    private bool InitialStep = true;
    private Quaternion InitialOrientation;
	public InfoApp()
	{
		InitializeComponent();
        WatchOrientation();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        WatchOrientation();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        CancelWatchOrientation();
    }

    private void WatchOrientation()
    {
        if (OrientationSensor.Default.IsSupported)
        {
            if (!OrientationSensor.Default.IsMonitoring)
            {
                OrientationSensor.Default.ReadingChanged += InspectChangeOrientation;
                OrientationSensor.Default.Start(SensorSpeed.UI);
            }
        }
    }

    private void CancelWatchOrientation()
    {
        if (OrientationSensor.Default.IsSupported)
        {
            OrientationSensor.Default.Stop();
            OrientationSensor.Default.ReadingChanged -= InspectChangeOrientation;
        }
    }

    private void InspectChangeOrientation(object sender, OrientationSensorChangedEventArgs e)
    {
        if (InitialStep)
        {
            InitialOrientation = e.Reading.Orientation;
            InitialStep = false;
        }
        else
        {
            if (InitialOrientation.W - e.Reading.Orientation.W > 0.19)
            {
                mainContainer.BackgroundColor = Colors.LightGreen;
            }
            else
            {
                mainContainer.BackgroundColor = Colors.Thistle;
            }
        }
    }
    private void btnVerCarousel_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CarouselDestinations());
    }
    private void btnResizeImg_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ImageResize());
    }

}