using SpaceXStarlink.Dtos;
using SpaceXStarlink.Entities;

namespace SpaceXStarlink
{
    public static class Extensions
    {
        public static SatelliteDto AsDto(this Satellite satellite)
        {
            return new SatelliteDto
             {
                Id          =   satellite.Id,
                Name        =   satellite.Name,
                Latitude    =   satellite.Latitude,
                Longitude   =   satellite.Longitude,
                Altitude    =   satellite.Altitude

            };
        }
    }
}