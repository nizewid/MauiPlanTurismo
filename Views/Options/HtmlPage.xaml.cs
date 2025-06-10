namespace MauiPlanTurismo.Views.Options;

public partial class HtmlPage : ContentPage
{
	public HtmlPage()
	{
		InitializeComponent();
		ShowHtml();
	}
	private void ShowHtml()
	{
        var codigoHtml = new HtmlWebViewSource();
        codigoHtml.Html = @"
            <html>
                <h1>Navegador Web</h1>
                <h3>Es hora del HTML :) <h3>
            </html>";

        webNavigator.Source = codigoHtml;
    }
}