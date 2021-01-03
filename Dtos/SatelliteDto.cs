using System;

namespace SpaceXStarlink.Dtos
{    
    public record SatelliteDto
    {
        public Guid Id { get;  init; }
        public string Name { get; set; }
        public double Latitude  { get; set;}
        public double Longitude  { get; set;}
        public int Altitude  { get; set;}        
    }

}