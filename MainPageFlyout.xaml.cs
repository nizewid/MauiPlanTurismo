namespace MauiPlanTurismo;

public partial class MainPageFlyout : FlyoutPage
{
	public MainPageFlyout()
	{
		InitializeComponent();
		flyoutPage.collectionView.SelectionChanged += OnSelectionChanged;
	}

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as Models.MenuItem;
        if (item != null)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            IsPresented = false;
        }
    }
}