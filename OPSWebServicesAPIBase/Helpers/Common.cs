using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using static OPSWebServicesAPIBase.Models.ErrorText;

namespace OPSWebServicesAPIBase.Helpers
{
    public class Common
    {
        public static bool TryCityIdRequest(HttpRequestMessage request, out string cityId)
        {
            string[] cities = ConfigurationManager.AppSettings["cities"].Split(',');
            //string[] cities = { "10", "5", "6", "3", "73", "79", "81", "61" };
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

        public static int GetSeverityError(int codeError)
        {
            SeverityError severityError = SeverityError.Critical;
            List<int> codesWarning = new List<int> { -2, -3, -4, -5, -6, -7, -8, -20, -21, -22, -23, -25, -27, -28, -30, -31, -32, -33, -250, -300, -301, -301, -302, -303, -304, -305 };
            List<int> codesException = new List<int> { -9, -12, -24, -26 };
            List<int> codesCritical = new List<int> { -1, -10, -11, -13, -14, -29, -290 };
            List<int> codesLow = new List<int> { -230, -231, -232, -233, -234, -235, -236, -237 };
            for (int i = -100; i >= -131; i--) codesCritical.Add(i);

            if (codesWarning.Contains(codeError)) { severityError = SeverityError.Warning; }
            if (codesException.Contains(codeError)) { severityError = SeverityError.Exception; }
            if (codesCritical.Contains(codeError)) { severityError = SeverityError.Critical; }
            if (codesLow.Contains(codeError)) { severityError = SeverityError.Low; }

            return (int)severityError;
        }
    }
}