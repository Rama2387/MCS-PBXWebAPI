using Newtonsoft.Json;

namespace MCS_PBXWebAPI.Models
{
    public static class PROGRESSMapper
    {
        public static PR_ClaimHeader_Send MapData(PBXMessage message)
        {
            return new PR_ClaimHeader_Send
            {
                ClaimNumberLabel = message.ttPBXMessSendData[0].ttchSunSendLabel,
                ClaimNumberValue = message.ttPBXMessSendData[0].ttchSunSendValue
            };
        }

        internal static PBXMessage DeMapData(PBXMessage message,string responseString)
        {
            var jsonString = JsonConvert.DeserializeObject<ResponseMessage>(responseString.ToString());
            
            //List<SunClaimDetailMap> lstSunClaimDetailMap = new List<SunClaimDetailMap>();

            ////SunWebClaimHdr
            //var resttWebClaimHdr = jsonString.ttWebClaimHdr;
            //SunWebClaimHdr objttWebClaimHdr = new SunWebClaimHdr
            //{
            //    ttchMCS = Convert.ToString(resttWebClaimHdr.ttchMCS),
            //    ttdecadjustmentamount = Convert.ToDecimal(resttWebClaimHdr.ttdecadjustmentamount),                

            //};

            ////sunClaimHdrCodesData
            
            //var ressunClaimHdrCodesData = jsonString.ttwebClaimHdrCodes;

            //sunClaimHdrCodesData objsunClaimHdrCodesData = new sunClaimHdrCodesData
            //    {
            //        ttchCdCode = Convert.ToString(ressunClaimHdrCodesData.ttchCdCode),
            //        ttchCdDesc = Convert.ToString(ressunClaimHdrCodesData.ttchCdDesc),
            //    };              
            

            //var resSunClaimDetailMap = jsonString.ttClaimDtlMap;
            //foreach (var item in resSunClaimDetailMap)
            //{
            //    SunClaimDetailMap objSunClaimDetailMap = new SunClaimDetailMap
            //    {
            //        ttmcsMCHDiagCode = Convert.ToString(item.ttmcsMCHDiagCode),
            //        ttmcsMCHLineNum = Convert.ToString(item.ttmcsMCHLineNum),
            //    };
            //    lstSunClaimDetailMap.Add(objSunClaimDetailMap);
            //}

            //Mapping back to Return data of PBXMessage

            ttPBXMessReturnDataCls objreturndata = new ttPBXMessReturnDataCls
            {
                ttWebClaimHdr = jsonString.ttWebClaimHdr,
                ttwebClaimHdrCodes= jsonString.ttwebClaimHdrCodes,
                ttClaimDtlMap= jsonString.ttClaimDtlMap
            };


            message.ttPBXMessReturnData = objreturndata;
            
            return message;
        }

        //public static ttWebClaimHdr MapData(string  response)
        //{
        //    return new ttWebClaimHdr
        //    {
        //        ttchMCS = response[0],
        //        ClaimNumberValue = message.ttPBXMessSendData[0].ttchSunSendValue
        //    };
        //}


    }


}
public class PR_ClaimHeader_Send
{
    public string ClaimNumberLabel { get; set; }
    public string ClaimNumberValue { get; set; }

}

public class PR_ClaimHeader_Receive
{
    public string ClaimNumberLabel { get; set; }
    public string ClaimNumberValue { get; set; }

}

