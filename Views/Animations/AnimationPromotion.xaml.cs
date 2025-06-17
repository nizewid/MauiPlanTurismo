namespace MauiPlanTurismo.Views.Animations;

public partial class AnimationPromotion : ContentPage
{
	public AnimationPromotion()
	{
		InitializeComponent();
        BeginAnimationPicture();
        ResizeLogo();
    }

    private void BeginAnimationPicture()
    {

        var topAnimacion = new Animation();

        var aumentaAnimacion = new Animation(v => imgFoto.Scale = v, 1, 3, Easing.SpringIn);
        var rotaAnimacion = new Animation(v => imgFoto.Rotation = v, 0, 360);
        var reduceAnimacion = new Animation(v => imgFoto.Scale = v, 3, 1, Easing.SpringOut);

        topAnimacion.Add(0, 0.5, aumentaAnimacion);
        topAnimacion.Add(0, 1, rotaAnimacion);
        topAnimacion.Add(0.5, 1, reduceAnimacion);

        topAnimacion.Commit(this, "AnimacionesAnidadas", 16, 8000, null, null, () => false);
    }

    private void ResizeLogo()
    {
        labelContainer.ScaleTo(3, 8000);
        labelContainer.ScaleTo(3, 8000);
    }
}