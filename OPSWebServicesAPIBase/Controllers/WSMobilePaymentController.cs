using OPSWebServicesAPIBase.Models;
using OPSWebServicesAPIBase.Helpers;
using System.Configuration;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using static OPSWebServicesAPIBase.Models.ErrorText;

namespace OPSWebServicesAPIBase.Controllers
{


    public class WSMobilePaymentController : ApiController
    {
        public WSMobilePaymentController()
        {

        }

        /// <summary>
        /// Return contracts information
        /// </summary>
        /// <returns>Object ContractsInfo or error</returns>
        [HttpGet]
        [Route("QueryContractsAPI")]
        public ResultContractsInfo QueryContractsAPI()
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryContractsAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.GetAsync(urlBase).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultContractsInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultContractsInfo response = new ResultContractsInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }


        /// <summary>
        /// Returns zone information
        /// </summary>
        /// <param name="zoneQuery">Object ZoneQuery with long-lat information or streetName-number information to request</param>
        /// <returns>zone information for query request</returns>
        [HttpPost]
        [Route("QueryZoneAPI")]
        public ResultZoneInfo QueryZoneAPI([FromBody] ZoneQuery zoneQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryZoneAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, zoneQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultZoneInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultZoneInfo response = new ResultZoneInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// return information from google api link https://maps.googleapis.com/maps/api/place/autocomplete/json
        /// </summary>
        /// <param name="placeQuery">Object PlaceQuery with street name to request</param>
        /// <returns>place information or error</returns>
        [HttpPost]
        [Route("QueryPlaceAPI")]
        public ResultPlaceInfo QueryPlaceAPI([FromBody] PlaceQuery placeQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryPlaceAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, placeQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultPlaceInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultPlaceInfo response = new ResultPlaceInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }


        /// <summary>
        /// return information for parking operation
        /// </summary>
        /// <param name="parkingStepsQuery">Object ParkingStepsQuery with sector and plate to request</param>
        /// <returns>parking information with time steps or error
        ///1: Parking of extension is possible and tariff steps, tariff type, operation type, money accumulated, time accumulated, minimum and maximum money and mininimum and maximum time is returned
        ///-1: Invalid authentication hash
        ///-2: The plate has used the maximum amount of time/money in the sector, so the extension is not possible. In Bilbao this depends on the colour of the zone and the tariff type.
        ///-3: The plate has not waited enough to return to the current sector.
        ///-9: Generic Error (for example database or execution error.)
        ///-11: Missing input parameter
        ///-12: OPS System error
        /// </returns>
        [HttpPost]
        [Route("QueryParkingOperationWithTimeStepsAPI")]
        public ResultParkingStepsInfo QueryParkingOperationWithTimeStepsAPI([FromBody] ParkingStepsQuery parkingStepsQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryParkingOperationWithTimeStepsAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, parkingStepsQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultParkingStepsInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultParkingStepsInfo response = new ResultParkingStepsInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// return information for parking operation
        /// </summary>
        /// <param name="parkingStepsQuery">Object ParkingStepsQuery with sector and plate to request</param>
        /// <returns>parking information with money steps or error</returns>
        [HttpPost]
        [Route("QueryParkingOperationWithMoneyStepsAPI")]
        public ResultParkingStepsInfo QueryParkingOperationWithMoneyStepsAPI([FromBody] ParkingStepsQuery parkingStepsQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryParkingOperationWithMoneyStepsAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, parkingStepsQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultParkingStepsInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultParkingStepsInfo response = new ResultParkingStepsInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }



        /// <summary>
        /// return information for parking operation for time
        /// </summary>
        /// <param name="parkingTimeQuery">Object ParkingTimeQuery with time to request</param>
        /// <returns>parking information for time or error 
        ///1: Parking of extension is possible and operation type, money accumulated, time accumulated, amount needed to arrive to the input parameter t, initial and final parking date is returned
        ///-1: Invalid authentication hash
        ///-2: The plate has used the maximum amount of time/money in the sector, so the extension is not possible. In Bilbao this depends on the colour of the zone and the tariff type.
        ///-3: The plate has not waited enough to return to the current sector.
        ///-9: Generic Error (for example database or execution error.)
        ///-11: Missing input parameter
        ///-12: OPS System error
        /// </returns>
        [HttpPost]
        [Route("QueryParkingOperationForTimeAPI")]
        public ResultParkingTimeInfo QueryParkingOperationForTimeAPI([FromBody] ParkingTimeQuery parkingTimeQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryParkingOperationForTimeAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, parkingTimeQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultParkingTimeInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultParkingTimeInfo response = new ResultParkingTimeInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// return information for parking operation for money
        /// </summary>
        /// <param name="parkingMoneyQuery">Object ParkingMoneyQuery with time to request</param>
        /// <returns>parking information for money or error 
        ///1: Parking of extension is possible and operation type, money accumulated, time accumulated, time in minutes given by the amount of money q, initial and final parking date is returned
        ///-1: Invalid authentication hash
        ///-2: The plate has used the maximum amount of time/money in the sector, so the extension is not possible. In Bilbao this depends on the colour of the zone and the tariff type.
        ///-3: The plate has not waited enough to return to the current sector.
        ///-9: Generic Error (for example database or execution error.)
        ///-11: Missing input parameter
        ///-12: OPS System error
        /// </returns>
        [HttpPost]
        [Route("QueryParkingOperationForMoneyAPI")]
        public ResultParkingMoneyInfo QueryParkingOperationForMoneyAPI([FromBody] ParkingMoneyQuery parkingMoneyQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryParkingOperationForMoneyAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, parkingMoneyQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultParkingMoneyInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultParkingMoneyInfo response = new ResultParkingMoneyInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// return information for parking confirmation
        /// </summary>
        /// <param name="parkingConfirmQuery">Object ParkingConfirmQuery with sector and plate to request</param>
        /// <returns>parking confirm or error 
        ///1: Parking of extension is possible 
        ///-1: Invalid authentication hash
        ///-2: The plate has used the maximum amount of time/money in the sector, so the extension is not possible. In Bilbao this depends on the colour of the zone and the tariff type.
        ///-3: The plate has not waited enough to return to the current sector.
        ///-9: Generic Error (for example database or execution error.)
        ///-10: Invalid input parameter
        ///-11: Missing input parameter
        ///-12: OPS System error
        ///-13: Operation already inserted
        ///-20: Mobile user not found
        ///-23: Invalid Login
        ///-24: User has no rights. Operation begun by another user
        ///-25: User does not have enough credit
        /// </returns>
        [HttpPost]
        [Route("ConfirmParkingOperationAPI")]
        public ResultParkingConfirmInfo ConfirmParkingOperationAPI([FromBody] ParkingConfirmQuery parkingConfirmQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/ConfirmParkingOperationAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string token;
                    Common.TryTokenRequest(Request, out token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var responseI = client.PostAsJsonAsync(urlBase, parkingConfirmQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultParkingConfirmInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultParkingConfirmInfo response = new ResultParkingConfirmInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// return information for unparking operation
        /// </summary>
        /// <param name="unParkingQuery">Object UnParkingQuery with plate to request</param>
        /// <returns>unparking information or error 
        ///1: UnParking is possible and quantity refunded, tariff applied, tariff in minutes, inital date and end date is returned
        ///-1: Invalid authentication hash
        ///-4: Plate has no rights for doing an unparking operation
        ///-9: Generic Error (for example database or execution error.)
        ///-10: Invalid input parameter
        ///-11: Missing input parameter
        ///-12: OPS System error
        /// </returns>
        [HttpPost]
        [Route("QueryUnParkingOperationAPI")]
        public ResultUnParkingQueryInfo QueryUnParkingOperationAPI([FromBody] UnParkingQuery unParkingQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryUnParkingOperationAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, unParkingQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultUnParkingQueryInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultUnParkingQueryInfo response = new ResultUnParkingQueryInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// return information for unparking confirmation
        /// </summary>
        /// <param name="unParkingConfirmQuery">Object UnParkingConfirmQuery with quantity and plate to request</param>
        /// <returns>parking confirm or error 
        ///1: Operation saved without errors 
        ///-1: Invalid authentication hash
        ///-4: Plate has no rights for doing an unparking operation
        ///-9: Generic Error (for example database or execution error.)
        ///-10: Invalid input parameter
        ///-11: Missing input parameter
        ///-12: OPS System error
        ///-13: Operation already inserted
        ///-14: Quantity received different as the quantity calculated previously
        ///-20: Mobile user not found
        ///-23: Invalid Login
        ///-24: User has no rights. Operation begun by another user
        /// </returns>
        [HttpPost]
        [Route("ConfirmUnParkingOperationAPI")]
        public ResultUnParkingConfirmInfo ConfirmUnParkingOperationAPI([FromBody] UnParkingConfirmQuery unParkingConfirmQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/ConfirmUnParkingOperationAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string token;
                    Common.TryTokenRequest(Request, out token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var responseI = client.PostAsJsonAsync(urlBase, unParkingConfirmQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultUnParkingConfirmInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultUnParkingConfirmInfo response = new ResultUnParkingConfirmInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// return information for parking status
        /// </summary>
        /// <param name="parkingStatusQuery">Object ParkingStatusQuery with plate to request</param>
        /// <returns>parking status or error 
        ///1: Operation saved without errors 
        ///-1: Invalid authentication hash
        ///-9: Generic Error (for example database or execution error.)
        ///-10: Invalid input parameter
        ///-11: Missing input parameter
        ///-12: OPS System error
        ///-23: Invalid Login
        ///-24: User has no rights. Operation begun by another user
        /// </returns>
        [HttpPost]
        [Route("QueryParkingStatusAPI")]
        public ResultParkingStatusInfo QueryParkingStatusAPI([FromBody] ParkingStatusQuery parkingStatusQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryParkingStatusAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string token;
                    Common.TryTokenRequest(Request, out token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var responseI = client.PostAsJsonAsync(urlBase, parkingStatusQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultParkingStatusInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultParkingStatusInfo response = new ResultParkingStatusInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// return information for fine payment confirmation
        /// </summary>
        /// <param name="finePaymentConfirmQuery">Object FinePaymentConfirmQuery with quantity and plate to request</param>
        /// <returns>parking confirm or error 
        ///1: Fine payment saved without errors 
        ///-1: Invalid authentication hash
        ///-5: Fine number not found
        ///-6: Fine number found but fine type is not payable.
        ///-7: Fine number not found but payment period has expired.
        ///-8: Fine number already paid.
        ///-9: Generic Error (for example database or execution error.)
        ///-10: Invalid input parameter
        ///-11: Missing input parameter
        ///-12: OPS System error
        ///-14: Quantity received different as the quantity calculated previously
        ///-20: Mobile user not found
        ///-23: Invalid Login
        ///-25: User does not have enough credit
        /// </returns>
        [HttpPost]
        [Route("ConfirmFinePaymentAPI")]
        public ResultFinePaymentConfirmInfo ConfirmFinePaymentAPI([FromBody] FinePaymentConfirmQuery finePaymentConfirmQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/ConfirmFinePaymentAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string token;
                    Common.TryTokenRequest(Request, out token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var responseI = client.PostAsJsonAsync(urlBase, finePaymentConfirmQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultFinePaymentConfirmInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultFinePaymentConfirmInfo response = new ResultFinePaymentConfirmInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// return village sectors information
        /// </summary>
        /// <param name="sectorsQuery">Object SectorsQuery with ContractId to request</param>
        /// <returns>village streets</returns>
        [HttpPost]
        [Route("QuerySectorsAPI")]
        public ResultSectorsInfo QuerySectorsAPI([FromBody] SectorsQuery sectorsQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QuerySectorsAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, sectorsQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultSectorsInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultSectorsInfo response = new ResultSectorsInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// return village streets information
        /// </summary>
        /// <param name="streetsQuery">Object StreetsQuery with ContractId to request</param>
        /// <returns>village streets</returns>
        [HttpPost]
        [Route("QueryStreetsAPI")]
        public ResultStreetsFullInfo QueryStreetsFullAPI([FromBody] StreetsQuery streetsQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryStreetsAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, streetsQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultStreetsFullInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultStreetsFullInfo response = new ResultStreetsFullInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

    }
}
