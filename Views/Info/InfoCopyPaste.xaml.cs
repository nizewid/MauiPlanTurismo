using MauiPlanTurismo.ViewModels;

namespace MauiPlanTurismo.Views.Info;

public partial class InfoCopyPaste : ContentPage
{
    ClipboardViewModel copyPasteViewModel = new ClipboardViewModel();
    public InfoCopyPaste()
	{
		InitializeComponent();
        BindingContext = copyPasteViewModel;
    }
    protected override void OnAppearing()
    {
        // base.OnAppearing();
        copyPasteViewModel.StartObservation();
    }

    protected override void OnDisappearing()
    {
        //base.OnDisappearing();
        copyPasteViewModel.StopObservation();
    }
}