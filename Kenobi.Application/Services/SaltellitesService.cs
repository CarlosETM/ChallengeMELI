using Quasar.Domain.Aggregation;
using Quasar.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TopSecret.Application.Services
{
    public class SaltellitesService : ISaltellitesService
    {
        private readonly ISetallitesRepository satellitesRepository;
        public MappSatellites.Mapper mapper;

        public SaltellitesService(ISetallitesRepository satellitesRepository)
        {
            this.satellitesRepository = satellitesRepository;
            this.mapper = new MappSatellites.Mapper();
        }

        public async Task<ResponseSatellites> GetLocation(RequestSatelliteByDistance request)
        {
            try
            {
                var satellite = await this.satellitesRepository.GetLocation(request.Distance);
                if (satellite == null) { throw new Exception("posicion de Satelite No encontrado"); }
                return mapper.mappLocation(satellite);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

        public async Task<ResponseSatellitesMessage> GetMessage(RequestSatelliteByMessage request)
        {
            try
            {
                var satelliteMessage = await this.satellitesRepository.GetMessage(request);
                if (satelliteMessage == null) { throw new Exception("posicion de Satelite No encontrado"); }
                return mapper.mappMessage(satelliteMessage);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ResponseTopSecret>> TopSecret(RequestTopSecret request)
        {
            try
            {
                var satelliteTS = await this.satellitesRepository.TopSecret(request);
                if (satelliteTS == null) { throw new Exception("posicion de Satelite No encontrado"); }
                return mapper.mappTopSecret(satelliteTS);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ResponseTopSecret>> TopSecretByDistance(RequestTopSecretByDistance request)
        {
            try
            {
                var satelliteTS = await this.satellitesRepository.TopSecretByDistance(request);
                if (satelliteTS == null) { throw new Exception("posicion de Satelite No encontrado"); }
                return mapper.mappTopSecretBydistance(satelliteTS);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
