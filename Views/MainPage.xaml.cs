using MauiPlanTurismo.Views.Info;

namespace MauiPlanTurismo.Views
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void VerInformacionClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoApp());
        }
    }
}
