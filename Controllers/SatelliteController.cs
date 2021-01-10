using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceXStarlink.Dtos;
using SpaceXStarlink.Entities;
using SpaceXStarlink.Repositories;

namespace SpaceXStarlink.Controllers
{
    [ApiController]
    [Route("satellites") ]
    public class SatelliteConroller : ControllerBase
    {
        private readonly ISatelliteRepository satelliteRepository;
        public SatelliteConroller(ISatelliteRepository satelliteRepository )
        {
            this.satelliteRepository = satelliteRepository;
        }


        // Get / Satellites
        [HttpGet]
        public async Task<IEnumerable<SatelliteDto>> GetSatellitesAsync()
        {
            var satelliteDtos =  (await satelliteRepository.GetSatellitesAsync())
                                            .Select(satellite => satellite.AsDto());
            return satelliteDtos ;  
        }
        // Get / Satellites/ {id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SatelliteDto>> GetSatelliteAsync(Guid id)
        {
            var satellite = await satelliteRepository.GetSatelliteAsync(id);

            if (satellite is null)
            {
                return NotFound();
            }
            return satellite.AsDto() ;
        }
       // Post / Satellite
       [HttpPost]
        public async Task<ActionResult> CreateSatelliteAsync(CreateSatelliteDto satelliteDto)
        {
           Satellite satellite = new ()
           {
               Id = Guid.NewGuid(),
               Name     =  satelliteDto.Name,
               Latitude = satelliteDto.Latitude,
               Longitude =satelliteDto.Longitude,
               Altitude = satelliteDto.Altitude
           };
           await satelliteRepository.CreateSatelliteAsync(satellite);
           return NoContent();
          // return CreatedAtAction(nameof(GetSatelliteAsync),new {id = satellite.Id},satellite.AsDto());
        }
        // Put / Satellite / {id}
        [HttpPut("{id}")]
        public  async Task<ActionResult> UpdateSatelliteAsync(Guid id, UpdateSatelliteDto satelliteDto)
        {
           var existingSatellite = await satelliteRepository.GetSatelliteAsync(id);

           if(existingSatellite is null)
           {
                return NotFound();
           }

           Satellite updatedSatellite = existingSatellite with
           {               
               Name     =  satelliteDto.Name,
               Latitude = satelliteDto.Latitude,
               Longitude =satelliteDto.Longitude,
               Altitude = satelliteDto.Altitude
           };
           await satelliteRepository.UpdateSatelliteAsync(updatedSatellite);
           return NoContent();
        }
         // Delete / Satellites/ {id}
        [HttpDelete("{id}")]
        public  async Task<ActionResult> DeleteSatelliteAsync(Guid id)
        {
           var existingSatellite =await satelliteRepository.GetSatelliteAsync(id);

           if(existingSatellite is null)
           {
                return NotFound();
           }
           await satelliteRepository.DeleteSatelliteAsync(id);
           return NoContent();
        }
    }
}