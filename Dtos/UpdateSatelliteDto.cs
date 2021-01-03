using System.ComponentModel.DataAnnotations;

namespace SpaceXStarlink.Dtos
{    
    public record UpdateSatelliteDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(-90,90)]
        public double Latitude  { get; set;}
        [Required]
        [Range(-180,180)]
        public double Longitude  { get; set;}
        [Required]
        [Range(0,1000000)]
        public int Altitude  { get; set;}        
    }

}