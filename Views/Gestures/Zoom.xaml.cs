using MauiPlanTurismo.Extensions;

namespace MauiPlanTurismo.Views.Gestures;

public partial class Zoom : ContentPage
{
    double currentScale = 1;
    double startScale = 1;
    double xOffset = 0;
    double yOffset = 0;
    string strDebug = "";

    public Zoom()
	{
		InitializeComponent();
	}
    private void ImgFondo_PinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
        if (e.Status == GestureStatus.Started)
        {
            startScale = imgFondo.Scale;
            imgFondo.AnchorX = 0;
            imgFondo.AnchorY = 0;
        }
        if (e.Status == GestureStatus.Running)
        {
            currentScale += (e.Scale - 1) * startScale;
            currentScale = Math.Max(1, currentScale);

            double renderedX = imgFondo.X + xOffset;
            double deltaX = renderedX / Width;
            double deltaWidth = Width / (imgFondo.Width * startScale);
            double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

            double renderedY = imgFondo.Y + yOffset;
            double deltaY = renderedY / Height;
            double deltaHeight = Height / (imgFondo.Height * startScale);
            double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

            double targetX = xOffset - (originX * imgFondo.Width) * (currentScale - startScale);
            double targetY = yOffset - (originY * imgFondo.Height) * (currentScale - startScale);

            imgFondo.TranslationX = targetX.Clamp(-imgFondo.Width * (currentScale - 1), 0);
            imgFondo.TranslationY = targetY.Clamp(-imgFondo.Height * (currentScale - 1), 0);


            imgFondo.Scale = currentScale;

            strDebug += String.Format("x:{0}  y:{1}   W:{2}-H:{3}   Scale:{4}", imgFondo.TranslationX, imgFondo.TranslationY, imgFondo.WidthRequest, imgFondo.HeightRequest, imgFondo.Scale) + Environment.NewLine;
        }
        if (e.Status == GestureStatus.Completed)
        {
            xOffset = imgFondo.TranslationX;
            yOffset = imgFondo.TranslationY;
        }

    }
}