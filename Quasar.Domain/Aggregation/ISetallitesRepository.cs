using Quasar.Domain.DTOs;
using Quasar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quasar.Domain.Aggregation
{
   public interface ISetallitesRepository
    {
        Task<Satellite> GetLocation(float Distance);

        Task<Satellite> GetMessage(RequestSatelliteByMessage request);

        Task<List<Satellite>> TopSecret(RequestTopSecret request);


        Task<List<Satellite>> TopSecretByDistance(RequestTopSecretByDistance request);
        


    }
}
