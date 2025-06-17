namespace MauiPlanTurismo.Views.Animations;

public partial class AnimationZoom : ContentPage
{
    private double currentScale = 1;
    public AnimationZoom()
    {
        InitializeComponent(); // Ensure this method is generated in the corresponding XAML file.  
        lblActualSize.Text = imgFoto.Scale.ToString();
    }

    private async void btnZoomIn_Clicked(object sender, EventArgs e)
    {
        currentScale += 0.5;
        if (currentScale > 4)
        {
            currentScale = 4;
        }
        lblActualSize.Text = currentScale.ToString();
        await imgFoto.ScaleTo(currentScale, 2000);
    }

    private async void btnZoomOut_Clicked(object sender, EventArgs e)
    {
        currentScale -= 0.5;
        if (currentScale < 0.5)
        {
            currentScale = 0.5;
        }
        lblActualSize.Text = currentScale.ToString();
        await imgFoto.ScaleTo(currentScale, 2000);
    }
}
