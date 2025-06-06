using MauiPlanTurismo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPlanTurismo.Services
{
    public static class DestinationsService
    {
        public static List<TouristDestination> GetAll()
        {
            return new List<TouristDestination>
            {
                new TouristDestination
                {
                    HotelName = "Hotel Murallas de Ávila",
                    City = "Ávila",
                    Province = "Ávila",
                    HasBeach = false,
                    HasPool = true,
                    IncludesBreakfast = true,
                    Image = "Cities/avila.jpeg"
                },
                new TouristDestination
                {
                    HotelName = "Castillo de Burgos Inn",
                    City = "Burgos",
                    Province = "Burgos",
                    HasBeach = false,
                    HasPool = false,
                    IncludesBreakfast = true,
                    Image = "Cities/burgos_catedral.JPG"
                },
                new TouristDestination
                {
                    HotelName = "Costa de la Luz Resort",
                    City = "Chiclana de la Frontera",
                    Province = "Cádiz",
                    HasBeach = true,
                    HasPool = true,
                    IncludesBreakfast = true,
                    Image = "Cities/cadiz_catedral.jpg"
                },
                new TouristDestination
                {
                    HotelName = "Atlántico Hotel Boutique",
                    City = "A Coruña",
                    Province = "A Coruña",
                    HasBeach = true,
                    HasPool = false,
                    IncludesBreakfast = true,
                    Image = "Cities/corunia.JPG"
                },
                new TouristDestination
                {
                    HotelName = "Alhambra Palace Hotel",
                    City = "Granada",
                    Province = "Granada",
                    HasBeach = false,
                    HasPool = true,
                    IncludesBreakfast = false,
                    Image = "Cities/granada_pan_lejos.JPG"
                },
                new TouristDestination
                {
                    HotelName = "Vino y Flamenco",
                    City = "Jerez de la Frontera",
                    Province = "Cádiz",
                    HasBeach = false,
                    HasPool = true,
                    IncludesBreakfast = true,
                    Image = "Cities/jerez_plaza.jpg"
                },
                new TouristDestination
                {
                    HotelName = "Madrid Central Hotel",
                    City = "Madrid",
                    Province = "Madrid",
                    HasBeach = false,
                    HasPool = false,
                    IncludesBreakfast = true,
                    Image = "Cities/madrid_palacio.JPG"
                },
                new TouristDestination
                {
                    HotelName = "Universitas Suites",
                    City = "Salamanca",
                    Province = "Salamanca",
                    HasBeach = false,
                    HasPool = false,
                    IncludesBreakfast = false,
                    Image = "Cities/salamanca_plaza_noche.jpg"
                },
                new TouristDestination
                {
                    HotelName = "Camino Real Hotel",
                    City = "Santiago de Compostela",
                    Province = "A Coruña",
                    HasBeach = false,
                    HasPool = true,
                    IncludesBreakfast = true,
                    Image = "Cities/santiago.JPG"
                },
                new TouristDestination
                {
                    HotelName = "Real Acueducto Hotel",
                    City = "Segovia",
                    Province = "Segovia",
                    HasBeach = false,
                    HasPool = true,
                    IncludesBreakfast = false,
                    Image = "Cities/segovia_alcazar.jpg"
                },
                new TouristDestination
                {
                    HotelName = "Triana Riverside",
                    City = "Sevilla",
                    Province = "Sevilla",
                    HasBeach = false,
                    HasPool = true,
                    IncludesBreakfast = true,
                    Image = "Cities/sevilla_plaza.jpeg"
                }
            };
        }
    }
}
