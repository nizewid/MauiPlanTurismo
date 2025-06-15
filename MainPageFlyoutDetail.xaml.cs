namespace MauiPlanTurismo;

public partial class MainPageFlyoutDetail : ContentPage
{
    private double lastWidth = 0;
    private double lastHeight = 0;
    public MainPageFlyoutDetail()
	{
		InitializeComponent();
	}
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (lastWidth != this.Width || lastHeight != this.Height)
        {

            if (width > height)
            {
                lblOrientation.Text = "Horizontal";
                MainPage.BackgroundImageSource = "planturismoinicio_h.png";
            }
            else
            {
                lblOrientation.Text = "Vertical";
                MainPage.BackgroundImageSource = "planturismoinicio.png";
            }

            lastWidth = width;
            lastHeight = height;
        }
    }
}