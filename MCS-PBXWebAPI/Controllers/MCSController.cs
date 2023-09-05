using MCS_PBXWebAPI.Common;
using MCS_PBXWebAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCS_PBXWebAPI.Controllers
{
    public class MCSController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        IConfiguration configuration;

        public MCSController(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;

            this.configuration = configuration;
        }

        #region ZONE 1-A
      //  Hit from the Web Application--the entire PBX Message
        [AllowAnonymous]
        [HttpPost("getallmetrics")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public PBXMessage GetAllMetrics([FromBody] PBXMessage message)
        {            
            PBXMessage pBXMessage = ProcessData.Execute(message,this.configuration);
            return pBXMessage;
        }

        #endregion
    }
}
