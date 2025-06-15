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
    }
}
