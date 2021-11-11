using Quasar.Domain.Aggregation;
using Quasar.Domain.DTOs;
using Quasar.Domain.Entities;
using Quasar.Domain.Model;
using Quasar.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopSecret.Infrastructure.DataPersistent.Repository
{
    public class SatelliteRepository : Repository<ApplicationDbContext>, ISetallitesRepository
    {
        public SatelliteRepository(ApplicationDbContext context) : base(context)
        {
           
        }
        
        public async Task<Satellite> GetLocation(float Distance)
        {
            Satellite satellite = new Satellite();
            satellite = (await this.Filter<Satellite>(s =>  s.Distance == Distance.ToString())).FirstOrDefault();
            return satellite;
        }

        public async Task<Satellite> GetMessage(RequestSatelliteByMessage request)
        {
            Satellite satellite = new Satellite();
            satellite = (await this.Filter<Satellite>
             (s => s.word1 == request.Palabra1 && s.word2 == request.Palabra2 &&
             s.word3 == request.Palabra3 && s.word4 == request.Palabra4)).FirstOrDefault();
             
            return satellite;
        }

        public async Task<List<Satellite>> TopSecret(RequestTopSecret request)
        {
            var satelliteList = new List<Satellite>();
            foreach (var item in request.satellites)
            {
                Satellite satellite = new Satellite()
                { 
                 name= item.name,
                  Distance= item.distance2.ToString(),
                    word1= item.message.word1,
                    word2 = item.message.word2,
                    word3 = item.message.word3,
                    word4 = item.message.word4,
                     postionX= item.PositionX.ToString(),
                      postionY= item.PositionX.ToString()
                };
                await this.Create<Satellite>(satellite);
                    satelliteList.Add(satellite);

            }
            return satelliteList;

        }

        public async Task<List<Satellite>> TopSecretByDistance(RequestTopSecretByDistance request)
        {
          var w1=  request.message.word1 == "" ? null : request.message.word1;
          var w2 = request.message.word2 == "" ? null : request.message.word2;
          var w3 = request.message.word3 == "" ? null : request.message.word3;
          var w4 = request.message.word4 == "" ? null : request.message.word4;

            var satelliteList = new List<Satellite>();
            Satellite satellite = new Satellite();
             satellite = (await this.Filter<Satellite>
             (s => s.word1 == w1 && s.word2 == w2 &&
             s.word3 == w3 && s.word4 == w4)).FirstOrDefault();
            satelliteList.Add(satellite);
            return satelliteList;
        }
    }
}
