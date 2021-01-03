using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SpaceXStarlink.Entities
{    
    public record Satellite
    {
        public Guid Id { get;  init; }
        public string Name { get; set; }
        public double Latitude  { get; set;}
        public double Longitude  { get; set;}
        public int Altitude  { get; set;}        
    }

}