using Quasar.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Quasar.Domain.Aggregation
{
	public interface ISaltellitesService
	{
		Task<ResponseSatellites> GetLocation(RequestSatelliteByDistance request);

		Task<ResponseSatellitesMessage> GetMessage(RequestSatelliteByMessage request);


		Task<List<ResponseTopSecret>> TopSecret(RequestTopSecret request);

		Task<List<ResponseTopSecret>> TopSecretByDistance(RequestTopSecretByDistance request);

		

	}
}
