using MauiPlanTurismo.ViewModels;

namespace MauiPlanTurismo.Views.Info;

public partial class SystemInfo : ContentPage
{
    private int Speed;

    public SystemInfo()
    {
        InitializeComponent();
        BindingContext = new SystemInfoViewModel();
        EnableButtons(true);
    }

    private void EnableButtons(bool enable)
    {
        btnIniciar.IsEnabled = enable;
        btnParar.IsEnabled = !enable;
    }

    private void btnShowSystemInfo_Clicked(object sender, EventArgs e)
    {
        AppInfo.Current.ShowSettingsUI();
    }

    #region Location Permission Request

    private async void btnRequestLocation_Clicked(object sender, EventArgs e)
    {
        PermissionStatus status = await CheckAndRequestLocationPermission();
        await DisplayAlert("Permiso Ubicación", status.ToString(), "OK");
    }

    private async Task<PermissionStatus> CheckAndRequestLocationPermission()
    {
        var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

        if (status == PermissionStatus.Granted)
            return status;

        if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        {
            await DisplayAlert("Permiso denegado", "Por favor habilita la ubicación desde configuración.", "OK");
            return status;
        }

        if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
        {
            await DisplayAlert("Permiso requerido", "La app necesita acceder a tu ubicación.", "OK");
        }

        status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        return status;
    }

    #endregion

    #region Orientation Sensor

    private void btnIniciar_Clicked(object sender, EventArgs e)
    {
        if (AsignarSpeed())
        {
            OrientationSensor.ReadingChanged += OnReadingChanged;
            OrientationSensor.Start((SensorSpeed)Speed);
            EnableButtons(false);
        }
    }

    private void btnParar_Clicked(object sender, EventArgs e)
    {
        OrientationSensor.ReadingChanged -= OnReadingChanged;
        OrientationSensor.Stop();
        EnableButtons(true);

        lbl_X.Text = "0";
        lbl_Y.Text = "0";
        lbl_Z.Text = "0";
        lbl_W.Text = "0";
        lbl_T.Text = "0";
        lbl_S.Text = "";
    }

    private bool AsignarSpeed()
    {
        if (pickerSpeed.SelectedIndex == -1)
        {
            DisplayAlert("Velocidad", "Selecciona una velocidad", "OK");
            return false;
        }

        string selectedSpeed = (string)pickerSpeed.ItemsSource[pickerSpeed.SelectedIndex];
        string[] arrSpeeds = Enum.GetNames(typeof(SensorSpeed));

        for (int i = 0; i < arrSpeeds.Length; i++)
        {
            if (arrSpeeds[i] == selectedSpeed)
            {
                Speed = i;
                break;
            }
        }

        return true;
    }

    private void OnReadingChanged(object sender, OrientationSensorChangedEventArgs e)
    {
        var data = e.Reading;

        Action updateUI = () =>
        {
            lbl_X.Text = data.Orientation.X.ToString("F2");
            lbl_Y.Text = data.Orientation.Y.ToString("F2");
            lbl_Z.Text = data.Orientation.Z.ToString("F2");
            lbl_W.Text = data.Orientation.W.ToString("F2");
            lbl_T.Text = GetMilliseconds();
            lbl_S.Text = MainThread.IsMainThread ? "MainThread" : "WorkerThread";
        };

        if ((SensorSpeed)Speed == SensorSpeed.Game || (SensorSpeed)Speed == SensorSpeed.Fastest)
            MainThread.BeginInvokeOnMainThread(updateUI);
        else
            updateUI();
    }

    private string GetMilliseconds()
    {
        DateTime start = DateTime.Now;
        for (int i = 0; i < 500000; i++) { }
        DateTime end = DateTime.Now;
        return (end - start).TotalMilliseconds.ToString("F0");
    }

    #endregion
}
