using MauiPlanTurismo.Models;

namespace MauiPlanTurismo.Data
{
    public static class TouristDestinationData
    {
        public static List<TouristDestination> GetTouristDestinations()
        {
            return new List<TouristDestination>
            {
                new TouristDestination
                {
                    HotelName = "Hotel Eurostars",
                    City = "Ávila",
                    Province = "Avila",
                    Image = "avila.jpeg",
                    HasBeach = false,
                    HasPool = true,
                    IncludesBreakfast = true,
                    Price = "90.00",
                    IsHotel = true,
                    Stars = 3
                },
                new TouristDestination
                {
                    HotelName = "Hotel Business",
                    City = "Burgos",
                    Province = "Burgos",
                    Image = "burgos_catedral.jpg",
                    HasBeach = false,
                    HasPool = false,
                    IncludesBreakfast = true,
                    Price = "80.00",
                    IsHotel = true,
                    Stars = 2
                },
                new TouristDestination
                {
                    HotelName = "Hotel Fresneda",
                    City = "Cádiz",
                    Province = "Cádiz",
                    Image = "cadiz_catedral.jpg",
                    HasBeach = true,
                    HasPool = true,
                    IncludesBreakfast = true,
                    Price = "90.00",
                    IsHotel = true,
                    Stars = 3
                },
                new TouristDestination
                {
                    HotelName = "Hostal Campomar",
                    City = "Coruña",
                    Province = "Coruña",
                    Image = "corunia.jpg",
                    HasBeach = true,
                    HasPool = false,
                    IncludesBreakfast = false,
                    Price = "45.00",
                    IsHotel = false,
                    Stars = 2
                },
                new TouristDestination
                {
                    HotelName = "Hotel Melia",
                    City = "Granada",
                    Province = "Granada",
                    Image = "granada_pan_lejos.jpg",
                    HasBeach = false,
                    HasPool = false,
                    IncludesBreakfast = true,
                    Price = "116.00",
                    IsHotel = true,
                    Stars = 4
                },
                new TouristDestination
                {
                    HotelName = "Hotel Soho Boutique",
                    City = "Jerez",
                    Province = "Cádiz",
                    Image = "jerez_plaza.jpg",
                    HasBeach = false,
                    HasPool = true,
                    IncludesBreakfast = true,
                    Price = "65.00",
                    IsHotel = true,
                    Stars = 2
                },
                new TouristDestination
                {
                    HotelName = "Hotel Ritz",
                    City = "Madrid",
                    Province = "Madrid",
                    Image = "madrid_palacio.jpg",
                    HasBeach = false,
                    HasPool = true,
                    IncludesBreakfast = true,
                    Price = "190.00",
                    IsHotel = true,
                    Stars = 5
                },
                new TouristDestination
                {
                    HotelName = "Hotel Regio",
                    City = "Salamanca",
                    Province = "Salamanca",
                    Image = "salamanca_plaza_noche.jpg",
                    HasBeach = false,
                    HasPool = true,
                    IncludesBreakfast = true,
                    Price = "110.00",
                    IsHotel = true,
                    Stars = 4
                },
                new TouristDestination
                {
                    HotelName = "Hotel Camino Santiago",
                    City = "Santiago",
                    Province = "Santiago",
                    Image = "santiago.jpg",
                    HasBeach = false,
                    HasPool = false,
                    IncludesBreakfast = true,
                    Price = "85.00",
                    IsHotel = true,
                    Stars = 4
                },
                new TouristDestination
                {
                    HotelName = "Hotel Alcazar",
                    City = "Segovia",
                    Province = "Segovia",
                    Image = "segovia_alcazar.jpg",
                    HasBeach = false,
                    HasPool = false,
                    IncludesBreakfast = false,
                    Price = "45.00",
                    IsHotel = true,
                    Stars = 2
                },
                new TouristDestination
                {
                    HotelName = "Hotel Macarena",
                    City = "Sevilla",
                    Province = "Sevilla",
                    Image = "sevilla_plaza.jpeg",
                    HasBeach = false,
                    HasPool = true,
                    IncludesBreakfast = true,
                    Price = "120.00",
                    IsHotel = true,
                    Stars = 4
                }
            };
        }
    }
}
