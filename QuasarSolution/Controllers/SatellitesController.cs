using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Domain.Aggregation;
using Quasar.Domain.DTOs;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuasarSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SatellitesController : Controller
    {
        private readonly ISaltellitesService _SatelliteService;
        private readonly OperationResult<ResponseSatellites> operationResul;
        private readonly OperationResult<ResponseSatellitesMessage> operationResulMessage;

        private readonly OperationResult<List<ResponseTopSecret>> operationTopSecret;
        public SatellitesController(ISaltellitesService satelliteService)
        {
            this._SatelliteService = satelliteService;
            this.operationResul = new OperationResult<ResponseSatellites>();
            this.operationResulMessage = new OperationResult<ResponseSatellitesMessage>();
            this.operationTopSecret = new OperationResult<List<ResponseTopSecret>>();
        }


        [HttpGet("GetLocation")]
        public async Task<ActionResult> GetLocation([FromQuery] RequestSatelliteByDistance request)
        {
            var response = new OperationResult<ResponseSatellites>();
            try
            {
                response = await operationResul.AsyncRun(async () => await this._SatelliteService.GetLocation(request));
            }
            catch (Exception ex)
            {
              //  this._telemetry.TrackException(ex);
            }
            return Ok(response);
        }
        [HttpGet("GetMessage")]
        public async Task<ActionResult> GetMessage([FromQuery] RequestSatelliteByMessage request)
        {
             var response = new OperationResult<ResponseSatellitesMessage>();
            try
            {
                  response = await operationResulMessage.AsyncRun(async () => await this._SatelliteService.GetMessage(request));
            }
            catch (Exception ex)
            {
                //  this._telemetry.TrackException(ex);
            }
            return Ok(response);
        }

        [HttpPost("TopSecret_Split")]
        public async Task<ActionResult> TopSecret_Split( RequestTopSecret request)
        {
            var response = new OperationResult<List<ResponseTopSecret>>();
            try
            {
                response = await operationTopSecret.AsyncRun(async () => await this._SatelliteService.TopSecret(request));
            }
            catch (Exception ex)
            {
                //  this._telemetry.TrackException(ex);
            }
            return Ok(response);
        }
        [HttpPost("TopSecret_SplitByDistance")]
        public async Task<ActionResult> TopSecret_SplitByDistance(RequestTopSecretByDistance request)
        {
            var response = new OperationResult<List<ResponseTopSecret>>();
            try
            {
                response = await operationTopSecret.AsyncRun(async () => await this._SatelliteService.TopSecretByDistance(request));
            }
            catch (Exception ex)
            {
                //  this._telemetry.TrackException(ex);
            }
            return Ok(response);
        }
    }
}
