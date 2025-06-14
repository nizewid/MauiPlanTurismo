using Microsoft.Maui.Controls;

namespace MauiPlanTurismo.Views.Gestures;

public partial class CopyPasteDestination : ContentPage
{
    public CopyPasteDestination()
    {
        InitializeComponent();
    }

    private void StartDragAvila(object sender, DragStartingEventArgs e)
    {
        e.Data.Properties.Add("Image", "avila.jpeg");
        e.Data.Properties.Add("HotelName", lblHotelAvila.Text);
        e.Data.Properties.Add("City", lblCityAvila.Text);
        e.Data.Properties.Add("Type", lblTypeAvila.Text);
        e.Data.Properties.Add("Category", lblCategoryAvila.Text);
        e.Data.Properties.Add("Breakfast", lblBreakfastAvila.Text);
        e.Data.Properties.Add("Price", lblPriceAvila.Text);
    }

    private void StartDragJerez(object sender, DragStartingEventArgs e)
    {
        e.Data.Properties.Add("Image", "jerez_plaza.jpg");
        e.Data.Properties.Add("HotelName", lblHotelJerez.Text);
        e.Data.Properties.Add("City", lblCityJerez.Text);
        e.Data.Properties.Add("Type", lblTypeJerez.Text);
        e.Data.Properties.Add("Category", lblCategoryJerez.Text);
        e.Data.Properties.Add("Breakfast", lblBreakfastJerez.Text);
        e.Data.Properties.Add("Price", lblPriceJerez.Text);
    }

    private void CompleteSelection(object sender, DropEventArgs e)
    {
        imgPaste.Source = ImageSource.FromFile((string)e.Data.Properties["Image"]);
        lblHotelPaste.Text = (string)e.Data.Properties["HotelName"];
        lblCityPaste.Text = (string)e.Data.Properties["City"];
        lblTypePaste.Text = (string)e.Data.Properties["Type"];
        lblCategoryPaste.Text = (string)e.Data.Properties["Category"];
        lblBreakfastPaste.Text = (string)e.Data.Properties["Breakfast"];
        lblPricePaste.Text = (string)e.Data.Properties["Price"];
    }
}
