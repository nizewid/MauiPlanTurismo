namespace MauiPlanTurismo.Views.Info;

public partial class EntryControl : ContentPage
{
    public EntryControl()
    {
        InitializeComponent();
        EntryPersonalPlanTourist();
    }

    void EntryPersonalPlanTourist()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("EntryPlanTuris", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.SetSelectAllOnFocus(true);

#elif IOS || MACCATALYST
            handler.PlatformView.EditingDidBegin += (s, e) =>
            {
                handler.PlatformView.PerformSelector(new ObjCRuntime.Selector("selectAll"), null, 0.0f);
            };
#elif WINDOWS
            handler.PlatformView.GotFocus += (s, e) =>
            {
                handler.PlatformView.SelectAll();
            };
#endif
        });

        Microsoft.Maui.Handlers.ButtonHandler.Mapper.AppendToMapping("ButtonPlanTuri", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.Background = null;
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Aquamarine);

#elif WINDOWS
            handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
            handler.PlatformView.Background = null;
            handler.PlatformView.FocusVisualMargin = new Microsoft.UI.Xaml.Thickness(0);
#elif IOS || MACCATALYST
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Blue;
            handler.PlatformView.Layer.BorderWidth = 0;
#endif
        });
    }
}
