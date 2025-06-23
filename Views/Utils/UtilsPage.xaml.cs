namespace MauiPlanTurismo.Views.Utils;

public partial class UtilsPage : ContentPage
{
	public UtilsPage()
	{
		InitializeComponent();
	}
	private void btnMaps_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MapPage());
    }
	private void btnContacts_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ContactsPage());
    }
    private void btnSendSms_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SendSmsPage());
    }
}