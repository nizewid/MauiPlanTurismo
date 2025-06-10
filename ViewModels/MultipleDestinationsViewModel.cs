using MauiPlanTurismo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiPlanTurismo.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiPlanTurismo.ViewModels
{
    public class MultipleDestinationsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool isRefreshing;
        private readonly Random random = new();

        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                if (isRefreshing != value)
                {
                    isRefreshing = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<TouristDestination> TouristDestinations { get; private set; }

        public ICommand RefreshCommand => new Command(async () => await RefreshListAsync());

        private readonly string[] hotelNames = [
            "Hotel Eurostars", "Hotel Business", "Hotel Fresneda", "Hotel Campomar", "Hotel Melia",
            "Hotel Soho Boutique", "Hotel Ritz", "Hotel Regio", "Hotel Camino Santiago", "Hotel Alcazar"
        ];

        private readonly string[] cities = [
            "Ávila", "Burgos", "Cádiz", "Coruña", "Granada",
            "Jerez", "Madrid", "Salamanca", "Santiago", "Segovia"
        ];

        private readonly string[] images = [
            "avila.jpeg", "burgos_catedral.jpg", "cadiz_catedral.jpg", "corunia.jpg", "granada_pan_lejos.jpg",
            "jerez_plaza.jpg", "madrid_palacio.jpg", "salamanca_plaza_noche.jpg", "santiago.jpg", "segovia_alcazar.jpg"
        ];

        public MultipleDestinationsViewModel()
        {
            TouristDestinations = new ObservableCollection<TouristDestination>();
            LoadTouristDestinations();
        }

        private void LoadTouristDestinations()
        {
            try
            {
                TouristDestinations.Clear();
                for (int i = 0; i < 10; i++)
                {
                    TouristDestinations.Add(new TouristDestination
                    {
                        HotelName = hotelNames[i],
                        City = cities[i],
                        Image = images[i]
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading destinations: {ex.Message}");
            }
        }

        private async Task RefreshListAsync()
        {
            IsRefreshing = true;
            await Task.Delay(2000); 
            LoadTouristDestinations();
            IsRefreshing = false;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
