using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceXStarlink.Entities;

namespace SpaceXStarlink.Repositories
{
    public interface ISatelliteRepository
    {
        Task<Satellite> GetSatelliteAsync(Guid id);
       
        Task<IEnumerable<Satellite>> GetSatellitesAsync();
        Task CreateSatelliteAsync(Satellite satellite);
        Task UpdateSatelliteAsync(Satellite satellite);
        Task DeleteSatelliteAsync(Guid id);
    }

}