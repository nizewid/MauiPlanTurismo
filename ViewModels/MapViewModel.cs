using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiPlanTurismo.ViewModels
{
    public class MapViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string country, zipCode, city, address, latitude, longitude;

        public string Country
        {
            get => country;
            set { country = value; OnPropertyChanged(); }
        }

        public string ZipCode
        {
            get => zipCode;
            set { zipCode = value; OnPropertyChanged(); }
        }

        public string City
        {
            get => city;
            set { city = value; OnPropertyChanged(); }
        }

        public string Address
        {
            get => address;
            set { address = value; OnPropertyChanged(); }
        }

        public string Latitude
        {
            get => latitude;
            set { latitude = value; OnPropertyChanged(); }
        }

        public string Longitude
        {
            get => longitude;
            set { longitude = value; OnPropertyChanged(); }
        }

        public ICommand OpenByAddressCommand { get; }
        public ICommand OpenByCoordinatesCommand { get; }

        public MapViewModel()
        {
            OpenByAddressCommand = new Command(async () => await OpenByAddress());
            OpenByCoordinatesCommand = new Command(async () => await OpenByCoordinates());
        }

        private async Task OpenByAddress()
        {
            try
            {
                var placemark = new Placemark
                {
                    CountryName = Country,
                    AdminArea = ZipCode,
                    Locality = City,
                    Thoroughfare = Address
                };

                var options = new MapLaunchOptions { Name = "Ubicación solicitada" };
                var success = await Map.TryOpenAsync(placemark, options);

                if (!success)
                {
                    Debug.WriteLine("No se pudo abrir la dirección. Mostrando defecto");

                    // Coordenadas por defecto (Madrid)
                    var defaultLocation = new Location(40.4168, -3.7038);
                    await Map.OpenAsync(defaultLocation, new MapLaunchOptions
                    {
                        Name = "Ubicación por defecto: Madrid",
                        NavigationMode = NavigationMode.None
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[MAP ERROR] {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("MAPAS", "No se pudo abrir la aplicación de mapas.", "OK");
                //madrid
                var fallback = new Location(40.4168, -3.7038);
                await Map.OpenAsync(fallback, new MapLaunchOptions { Name = "Ubicación de respaldo" });
            }
        }

        private async Task OpenByCoordinates()
        {
            try
            {
                var location = new Location(40.4168, -3.7038);
                var options = new MapLaunchOptions { Name = "Madrid" };
                var success = await Map.TryOpenAsync(location, options);

                if (!success)
                {
                    Debug.WriteLine("[MAP] No se pudo abrir ");
                    await Application.Current.MainPage.DisplayAlert("MAPAS", "No se pudo abrir la aplicación de mapas.", "OK");
                }
                else
                {
                    Debug.WriteLine("[MAP] Opened OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[MAP ERROR] {ex.Message}");
            }
        }


        void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
