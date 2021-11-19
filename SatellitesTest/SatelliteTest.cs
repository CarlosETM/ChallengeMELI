using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Quasar.Domain.Aggregation;
using Quasar.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopSecret.Application.Services;

namespace SatellitesTest
{
    [TestClass]
    public  class SatelliteTest
    {



        [TestMethod]
        public void GetSatelliteLocation() 
        {
            var mock = new Mock<ISetallitesRepository>();

            SaltellitesService servicio = new SaltellitesService(mock.Object);
            var request = new RequestSatelliteByDistance() { Distance = 100 };
            var response = new ResponseSatellites() { Name = "Kenobi" };
            var satellite = servicio.GetLocation(request);

            Assert.AreEqual(satellite.Result.Name, response.Name);
        }
       

    }
}
