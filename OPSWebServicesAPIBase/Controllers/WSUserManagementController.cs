using System.Web.Http;
using OPSWebServicesAPIBase.Models;
using OPSWebServicesAPIBase.Helpers;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;
using static OPSWebServicesAPIBase.Models.ErrorText;

namespace OPSWebServicesAPIBase.Controllers
{
    public class WSUserManagementController : ApiController
    {


        /// <summary>
        /// Returns authorization token to login user or error
        /// </summary>
        /// <param name="userLogin">Objet UserLogin</param>
        /// <returns>Return authorization code or error code</returns>
        [HttpPost]
        [Route("LoginUserAPI")]
        public ResultLoginInfo LoginUserAPI([FromBody] UserLogin userLogin)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/LoginUserAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, userLogin).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultLoginInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultLoginInfo response = new ResultLoginInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

 
        /// <summary>
        /// Update user data and returns user id or error
        /// </summary>
        /// <param name="user">Objet User</param>
        /// <returns>Return user id or error</returns>
        [HttpPost]
        [Route("UpdateUserAPI")]
        public ResultUpdateUserInfo UpdateUserAPI([FromBody] User user)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/UpdateUserAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string token;
                    Common.TryTokenRequest(Request, out token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var responseI = client.PostAsJsonAsync(urlBase, user).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultUpdateUserInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultUpdateUserInfo response = new ResultUpdateUserInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }


        /// <summary>
        /// Returns user operation list
        /// </summary>
        /// <param name="userOperation">Object UserOperation</param>
        /// <returns>Returns user ooeration list or error</returns>        
        [HttpPost]
        [Route("QueryUserOperationsAPI")]
        public ResultListOperationInfo QueryUserOperationsAPI([FromBody] UserOperation userOperation)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryUserOperationsAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string token;
                    Common.TryTokenRequest(Request, out token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var responseI = client.PostAsJsonAsync(urlBase, userOperation).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultListOperationInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultListOperationInfo response = new ResultListOperationInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

 
        /// <summary>
        /// Returns user information
        /// </summary>
        /// <returns>Returns user data or error</returns>
        [HttpGet]
        [Route("QueryUserAPI")]
        //public ResultUserInfo QueryUserAPI([FromBody] UserQuery userQuery)
        public ResultUserInfo QueryUserAPI()
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryUserAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string token;
                    Common.TryTokenRequest(Request, out token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var responseI = client.GetAsync(urlBase).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultUserInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultUserInfo response = new ResultUserInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }


        /// <summary>
        /// Send a mail with code to revover
        /// </summary>
        /// <param name="userRecover">User recover object</param>
        /// <returns>mail sended status</returns>
        [HttpPost]
        [Route("RecoverPasswordAPI")]
        public ResultRecoverPasswordInfo RecoverPasswordAPI([FromBody] UserRecover userRecover)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/RecoverPasswordAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, userRecover).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultRecoverPasswordInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultRecoverPasswordInfo response = new ResultRecoverPasswordInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }


        /// <summary>
        /// Verify code received from email
        /// </summary>
        /// <param name="userRecoverVerify">object UserRecoverVerify</param>
        /// <returns>code recover verification</returns>
        [HttpPost]
        [Route("VerifyRecoveryPasswordAPI")]
        public ResultVerifyRecoverPasswordInfo VerifyRecoveryPasswordAPI([FromBody] UserRecoverVerify userRecoverVerify)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/VerifyRecoveryPasswordAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, userRecoverVerify).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultVerifyRecoverPasswordInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultVerifyRecoverPasswordInfo response = new ResultVerifyRecoverPasswordInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// Change password to user
        /// </summary>
        /// <param name="userRecoverVerify">Object UserRecoverVerify</param>
        /// <returns>new token generated</returns>
        [HttpPost]
        [Route("ChangePasswordAPI")]
        public ResultChangePasswordInfo ChangePasswordAPI([FromBody] UserChangePassword userChangePassword)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/ChangePasswordAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, userChangePassword).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultChangePasswordInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultChangePasswordInfo response = new ResultChangePasswordInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="userRegister">Object UserRegister</param>
        /// <returns>User id</returns>
        [HttpPost]
        [Route("RegisterUserAPI")]
        public ResultRegisterUserInfo RegisterUserAPI([FromBody] UserRegister userRegister)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/RegisterUserAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseI = client.PostAsJsonAsync(urlBase, userRegister).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultRegisterUserInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultRegisterUserInfo response = new ResultRegisterUserInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// return user credit in euro cents
        /// </summary>
        /// <param name="userQuery">Object UserQuery with authorizationToken to request</param>
        /// <returns>
        ///>0: Credit total expressed in Euro cents 
        ///-1: Invalid authentication hash
        ///-9: Generic Error (for example database or execution error.)
        ///-10: Invalid input parameter
        ///-11: Missing input parameter
        ///-12: OPS System error
        ///-20: Mobile user not found
        /// </returns>
        [HttpGet]
        [Route("QueryUserCreditAPI")]
        public ResultCreditUserInfo QueryUserCreditAPI()
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryUserCreditAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string token;
                    Common.TryTokenRequest(Request, out token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var responseI = client.GetAsync(urlBase).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultCreditUserInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultCreditUserInfo response = new ResultCreditUserInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }


        /// <summary>
        /// return information for user recharge credit
        /// </summary>
        /// <param name="userRechargeQuery">Object UserRechargeQuery with amount and user information</param>
        /// <returns>
        ///1: User recharge credit information
        ///-1: Invalid authentication hash
        ///-9: Generic Error (for example database or execution error)
        ///-10: Invalid input parameter
        ///-11: Missing input parameter
        ///-12: OPS System error
        ///-20: User not found.
        /// </returns>
        [HttpPost]
        [Route("RechargeUserCreditAPI")]
        public ResultUserRechargeInfo RechargeUserCreditAPI([FromBody] UserRechargeQuery userRechargeQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/RechargeUserCreditAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string token;
                    Common.TryTokenRequest(Request, out token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var responseI = client.PostAsJsonAsync(urlBase, userRechargeQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultUserRechargeInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultUserRechargeInfo response = new ResultUserRechargeInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// return report with user operations information
        /// </summary>
        /// <param name="userReportQuery">Object UserReportQuery with dates and user information to request</param>
        /// <returns>
        ///1: saved without errors
        ///-1: Invalid authentication hash
        ///-9: Generic Error (for example database or execution error)
        ///-10: Invalid input parameter
        ///-11: Missing input parameter
        ///-12: OPS System error
        ///-20: User not found.
        /// </returns>
        [HttpPost]
        [Route("QueryUserReportAPI")]
        public ResultUserReportInfo QueryUserReportAPI([FromBody] UserReportQuery userReportQuery)
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/QueryUserReportAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string token;
                    Common.TryTokenRequest(Request, out token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var responseI = client.PostAsJsonAsync(urlBase, userReportQuery).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultUserReportInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultUserReportInfo response = new ResultUserReportInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }

        /// <summary>
        /// Cancel User Account
        /// </summary>
        /// <returns>Returns user id or error</returns>
        [HttpGet]
        [Route("CancelUserAccountAPI")]
        //public ResultUserInfo QueryUserAPI([FromBody] UserQuery userQuery)
        public ResultUpdateUserInfo CancelUserAccountAPI()
        {
            try
            {
                string cityId = "";
                if (!Common.TryCityIdRequest(Request, out cityId))
                    cityId = ConfigurationManager.AppSettings["cityDefault"];
                string urlBase = ConfigurationManager.AppSettings["urlBase" + cityId].ToString() + "/CancelUserAccountAPI";

                string responseString = "";
                using (var client = new System.Net.Http.HttpClient())
                {
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string token;
                    Common.TryTokenRequest(Request, out token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var responseI = client.GetAsync(urlBase).Result;
                    if (responseI.IsSuccessStatusCode)
                    {
                        responseString = responseI.Content.ReadAsStringAsync().Result;
                    }
                }
                if (responseString == "") throw new System.Exception();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ResultUpdateUserInfo>(responseString);
            }
            catch (System.Exception)
            {
                ResultUpdateUserInfo response = new ResultUpdateUserInfo();
                response.isSuccess = false;
                int error = (int)ResultType.Result_Error_Generic;
                response.error = new Error(error, Common.GetSeverityError(error));
                response.value = null;
                return response;
            }
        }


    }
}
