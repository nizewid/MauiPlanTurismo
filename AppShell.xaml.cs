using MauiPlanTurismo.Views.Destinations;
using MauiPlanTurismo.Views.Gestures;
using MauiPlanTurismo.Views.Info;
using MauiPlanTurismo.Views.Options;
using MauiPlanTurismo.Views.User;
using MauiPlanTurismo.Views.Travel;
using MauiPlanTurismo.ViewModels;

namespace MauiPlanTurismo
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        void RegisterRoutes()
        {
            Routes.Add("inicio", typeof(MainPageFlyoutDetail));

            Routes.Add("lista_top_10", typeof(MultipleDestinationsViewModel));
            Routes.Add("lista_tipos_destino", typeof(DestinationViewModel));
            Routes.Add("carousel_tipos_destino", typeof(CarouselDestinations));
            Routes.Add("lista_sin_fin", typeof(DestinyListWithoutEnd));
            Routes.Add("lista_collection", typeof(MultipleDestinationsViewModel));

            Routes.Add("granada_destino", typeof(TabDestinyDestiny));
            Routes.Add("granada_detalle", typeof(TabDestinyDetail));
            Routes.Add("granada_precio", typeof(TabDestinyPrices));
            Routes.Add("granada_solicitar", typeof(TravelRequest));

            Routes.Add("viaje_seleccionar", typeof(CopyPasteDestination));
            Routes.Add("viaje_solicitar", typeof(TravelRequest));
            Routes.Add("viaje_datos", typeof(DestinyCategory));

            Routes.Add("booking", typeof(ExternalSite));
            Routes.Add("usuario", typeof(Register));
            Routes.Add("info", typeof(InfoApp));

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
