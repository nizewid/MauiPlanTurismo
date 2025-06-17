namespace MauiPlanTurismo.Views.Animations;

public partial class AnimationCar : ContentPage
{
	public AnimationCar()
	{
		InitializeComponent();
	}

	private async void btnBegin_Clicked(object sender, EventArgs e)
	{
        double y = 0;

        for (int i = 0; i < 5; i++)
        {
            await imgCoche.TranslateTo(400, y, 2000);

            y += 100;
            imgCoche.TranslationY = y;
            imgCoche.TranslationX = 0;
        }
    }
}