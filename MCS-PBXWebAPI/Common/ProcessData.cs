using MCS_PBXWebAPI.Models;
using MCSBusinessLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Configuration;

namespace MCS_PBXWebAPI.Common
{
    public class ProcessData
    {
        #region Zone 2-A
        //Basing on mode, request will be mapped to respective URL here
        public static PBXMessage Execute(PBXMessage message, IConfiguration configuration)
        {  
           
            switch (message.ttPBXMessTop[0].ttchSunMode)
            {
                case "ClaimSearch":
                    message = APICalls.PostAPICall(message, Convert.ToString(configuration["ProgressEndpoints:ClaimsUrl"]));
                    break;

                default:
                    break;
            }

            return message;

        }

        #endregion
    }
}
