using System;
using System.Collections.Generic;
using System.Linq;
using SpaceXStarlink.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SpaceXStarlink.Repositories
{    
    public class SatelliteRepository : ISatelliteRepository
    {
        private const string databaseName = "spacexstarlink";

        private const string collectionName = "Satellites";

        private readonly IMongoCollection<Satellite> satelliteCollection;

        private readonly FilterDefinitionBuilder<Satellite> filterBuilder = Builders<Satellite>.Filter;

        public SatelliteRepository(IMongoClient mongoClient)
        {
           // var mongoCS = config["mongo-cs"];
           // var mongoClient = new MongoClient(mongoCS);
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            satelliteCollection =database.GetCollection<Satellite>(collectionName);
        }
        public async Task CreateSatelliteAsync(Satellite satellite)
        {
           await satelliteCollection.InsertOneAsync(satellite);
        }

        public async Task DeleteSatelliteAsync(Guid id)
        {
            var filter =filterBuilder.Eq(satellite => satellite.Id, id);
            await satelliteCollection.DeleteOneAsync(filter);
        }

        public async Task<Satellite> GetSatelliteAsync(Guid id)
        {
            var filter =filterBuilder.Eq(satellite => satellite.Id, id);
            var cursor =  await satelliteCollection.FindAsync(filter);  
            return await cursor.SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Satellite>> GetSatellitesAsync()
        {
           return await satelliteCollection.AsQueryable().ToListAsync().ContinueWith(t => t.Result.AsEnumerable());
        }

        public async Task UpdateSatelliteAsync(Satellite satellite)
        {
            var filter =filterBuilder.Eq(s => s.Id, satellite.Id);
            await satelliteCollection.ReplaceOneAsync(filter, satellite);
        }
    }
}