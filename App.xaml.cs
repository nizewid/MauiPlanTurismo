using MauiPlanTurismo.Views.Destinations;
using MauiPlanTurismo.Views.Info;
using MauiPlanTurismo.Views.Travel;
using MauiPlanTurismo.Views.User;
using System.Diagnostics;

namespace MauiPlanTurismo
{
    public partial class App : Application
    {
        public static Color PrimaryColor { get; private set; }
        public static Color SecondaryColor { get; private set; }
        public static Color TertiaryColor { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        #region Ciclo de Vida de la App
        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);

            window.Created += (s, e) =>
            {
                Debug.WriteLine("-----> Inicio de la ventana  <----------------------");
            };

            window.Activated += (s, e) =>
            {
                Debug.WriteLine("-----> Ventana activa <----------------------");
            };

            window.Deactivated += (s, e) =>
            {
                Debug.WriteLine("-----> Ventana Desactivada <----------------------");
            };

            window.Stopped += (s, e) =>
            {
                Debug.WriteLine("-----> Ventana Parada <----------------------");
            };

            window.Resumed += (s, e) =>
            {
                Debug.WriteLine("-----> Ventana Reanudada <----------------------");
            };
            return window;
        }
        #endregion

        #region Acciones de aplicación
        public static void HandleAppActions(AppAction appAction)
        {
            App.Current.Dispatcher.Dispatch(async () =>
            {
                var page = appAction.Id switch
                {
                    "nuevo_viaje" => new TravelRequest(),
                    "info_planes_turismo" => new InfoApp(),
                    "destino_granada" => new TabDestinyDestiny(),
                    "datos_usuario" => new Register(),
                    _ => default(Page)
                };

                if (page != null)
                {
                    await Application.Current.MainPage.Navigation.PopToRootAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(page);
                }
            });
        }
        #endregion
    }
}
