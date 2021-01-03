using System;
using System.Collections.Generic;
using System.Linq;
using SpaceXStarlink.Entities;
using MongoDB.Driver;

namespace SpaceXStarlink.Repositories
{    
    public class SatelliteRepositoryInMemory 
    {
      private readonly List<Satellite> satellites = new()
        {
            new Satellite { Id =Guid.NewGuid(), Name = "1HOPSAT", Latitude = 123.29 , Longitude =12.6 ,Altitude = 256 } ,
            new Satellite { Id =Guid.NewGuid(), Name = "Aeolus", Latitude = 45.29 , Longitude = 134.6 ,Altitude = 450 } ,
            new Satellite { Id =Guid.NewGuid(), Name = "Ziyuan 1-2D", Latitude = 35.45 , Longitude = 35.6 ,Altitude = 245 }
        };

        public IEnumerable<Satellite> GetSatellites()
        {
            return satellites;
        }

        public Satellite GetSatellite(Guid id)
        {
            return satellites.Where(satellite => satellite.Id == id).SingleOrDefault();
        }

        public void CreateSatellite(Satellite satellite)
        {
            satellites.Add(satellite);
        }

        public void UpdateSatellite(Satellite satellite)
        {
            var index = satellites.FindIndex(existingSatellite => existingSatellite.Id == satellite.Id);
            satellites[index] = satellite;
        }

        public void DeleteSatellite(Guid id)
        {
             var index = satellites.FindIndex(existingSatellite => existingSatellite.Id == id);
             satellites.RemoveAt(index);
        }

    }
}