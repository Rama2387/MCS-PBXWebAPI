using MCS_PBXWebAPI.Models;
using Newtonsoft.Json;
using System.Text;

namespace MCS_PBXWebAPI.Common
{
    public class APICalls
    {
        #region Zone 3-A
        //Calls to PROGRESS API URLs
        internal static PBXMessage PostAPICall(PBXMessage message,string URL)
        {
           var sendinfo=  PROGRESSMapper.MapData(message);

            //var sendinfo = new Dictionary<string, string>
            //{
            //  {"ttchSunSendLabel", "ClaimNumber"},
            //  {"ttchSunSendValue", "123"}
            //};



            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string strPayload = JsonConvert.SerializeObject(sendinfo);
                HttpContent c= new StringContent(strPayload, Encoding.UTF8, "application/json");
                var response = client.PostAsync(URL, c).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //   message.ttPBXMessReturnData = JsonConvert.DeserializeObject<List<ttPBXMessReturnDataCls>>(responseString);
                  message= PROGRESSMapper.DeMapData(message,responseString);

                }
            }

            return message;
        }

        #endregion
    }
}
