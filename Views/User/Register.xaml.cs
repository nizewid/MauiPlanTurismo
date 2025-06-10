namespace MauiPlanTurismo.Views.User;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}
    private async void OnShowDataClicked(object sender, EventArgs e)
    {
        string userName = UsernameEntry.Text;
        string role = RoleEntry.Text;
        bool isScrumMaster = IsScrumMasterSwitch.IsToggled;

        await DisplayAlert("Datos Usuario",
            $"Nombre: {userName}\nRol: {role}\nScrum Master: {(isScrumMaster ? "Sí" : "No")}",
            "OK");
    }
}