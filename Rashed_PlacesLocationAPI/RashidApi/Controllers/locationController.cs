using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RashidApi.Models;

namespace RashidApi.Controllers
{
    public class locationController : ApiController
    {
        public async System.Threading.Tasks.Task<string> getLocations(string querytxt,string lat,string lng) //(string latitude,string longitude)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(string.Format("https://maps.googleapis.com/maps/api/place/textsearch/json?query="+querytxt+"&location={0},{1}&radius=500&key=AIzaSyDgrz4Rf3AX5bSfytgjbrwnXRs46qNRXdA", lat, lng));

              //  var result = JsonConvert.DeserializeObject<placesApiQueryResponse>(response).ToString();
                return response;
            }
        }

    }

}
