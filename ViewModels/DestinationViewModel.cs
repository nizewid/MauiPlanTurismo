using MauiPlanTurismo.Models;
using MauiPlanTurismo.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiPlanTurismo.ViewModels
{
    public class DestinationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public List<TouristDestination> DestinationsList { get; set; }

        public DestinationViewModel()
        {
            DestinationsList = new List<TouristDestination>();
            LoadDestinationsList();
        }

        private void LoadDestinationsList()
        {
            DestinationsList = TouristDestinationData.GetTouristDestinations();
        }
        #region Destinations for MultiBinding example

        private TouristDestination beachDestination = new TouristDestination
        {
            HotelName = "Beach Paradise Hotel",
            City = "Málaga",
            Province = "Andalucía",
            HasBeach = true,
            HasPool = true,
            IncludesBreakfast = true
        };

        public TouristDestination BeachDestination
        {
            get => beachDestination;
            set
            {
                beachDestination = value;
                OnPropertyChanged();
            }
        }

        private TouristDestination ruralDestination = new TouristDestination
        {
            HotelName = "Casa Rural Montaña",
            City = "Cangas de Onís",
            Province = "Asturias",
            HasBeach = false,
            HasPool = false,
            IncludesBreakfast = false
        };

        public TouristDestination RuralDestination
        {
            get => ruralDestination;
            set
            {
                ruralDestination = value;
                OnPropertyChanged();
            }
        }

        private TouristDestination mountainDestination = new TouristDestination
        {
            HotelName = "Albergue Pirineos",
            City = "Jaca",
            Province = "Huesca",
            HasBeach = false,
            HasPool = true,
            IncludesBreakfast = true
        };

        public TouristDestination MountainDestination
        {
            get => mountainDestination;
            set
            {
                mountainDestination = value;
                OnPropertyChanged();
            }
        }
        #endregion

        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
