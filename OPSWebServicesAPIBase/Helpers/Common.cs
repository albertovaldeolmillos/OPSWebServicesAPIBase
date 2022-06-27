using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace OPSWebServicesAPIBase.Helpers
{
    public class Common
    {
        public static bool TryCityIdRequest(HttpRequestMessage request, out string cityId)
        {
            string[] cities = { "10", "5", "6", "3", "73", "79", "81", "61" };
            cityId = "";
            IEnumerable<string> headers;
            if (!request.Headers.TryGetValues("CityId", out headers) || headers.Count() > 1)
            {
                return false;
            }
            cityId = headers.ElementAt(0);
            if (!cities.Contains(cityId))
                return false;
            return true;
        }

        public static bool TryTokenRequest(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }
    }
}