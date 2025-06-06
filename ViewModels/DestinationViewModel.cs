using MauiPlanTurismo.Models;
using MauiPlanTurismo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPlanTurismo.ViewModels
{
    public class DestinationViewModel
    {
        public ObservableCollection<TouristDestination> Destinations { get; set; }

        public DestinationViewModel()
        {
            var lista = DestinationsService.GetAll();
            Destinations = new ObservableCollection<TouristDestination>(lista);
        }
    }
}
