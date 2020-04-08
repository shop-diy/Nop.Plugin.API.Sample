using System;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;
using NopCommerce.Api.Connector.Managers;
using NopCommerce.Api.Connector.Models;
using NopCommerce.Api.Connector.Parameters;
using NopCommerce.Api.Connector;

namespace NopCommerce.Api.Connector
{
    public class AuthorizationController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View("~/Views/Index.cshtml");
        }

        [HttpPost]
        //TODO: it is recommended to have an [Authorize] attribute set
        public ActionResult Submit(UserAccessModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var clientId = "8c105a5c-6597-4991-b1c9-f249087659eb";
                    var clientSecret = "0677922b-ec11-49f0-b280-06af667f7994";
                    var serverUrl = "https://fslportal.azurewebsites.net";
                    var redirect = "http://localhost:49676/token";

                    
                    Session["clientId"] = clientId;
                    Session["clientSecret"] = clientSecret;
                    Session["serverUrl"] = serverUrl;
                    Session["redirectUrl"] = redirect;

                    var nopAuthorizationManager = new AuthorizationManager(clientId, clientSecret, serverUrl);

                    var redirectUrl = Url.RouteUrl("GetAccessToken", null, Request.Url.Scheme);

                    //if (redirectUrl != model.RedirectUrl)
                    //{
                    //    return BadRequest();
                    //}


                    // This should not be saved anywhere.
                    var state = Guid.NewGuid();
                    Session["state"] = state;

                    string authUrl = nopAuthorizationManager.BuildAuthUrl(redirectUrl, new string[] { }, state.ToString());

                    return Redirect(authUrl);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetAccessToken(string code, string state)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(state))
            {
                if (state != Session["state"].ToString())
                {
                    return BadRequest();
                }

                AccessModel model;
                try
                {

                    model = GetAuth(code);

                    // TODO: Here you can save your access and refresh tokens in the database. For illustration purposes we will save them in the Session and show them in the view.
                    Session["accessToken"] = model.AuthorizationModel.AccessToken;
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return View("~/Views/AccessToken.cshtml", model);
            }

            return BadRequest();
        }

        public AccessModel GetAuth(string code)
        {
            var model = new AccessModel();

            string clientId = "8c105a5c-6597-4991-b1c9-f249087659eb";
            string clientSecret = "0677922b-ec11-49f0-b280-06af667f7994";
            string serverUrl = "https://fslportal.azurewebsites.net";
            string redirectUrl = "http://localhost:49676/token";

            var authParameters = new AuthParameters()
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                ServerUrl = serverUrl,
                RedirectUrl = redirectUrl,
                GrantType = "authorization_code",
                Code = code
            };

            var nopAuthorizationManager = new AuthorizationManager(authParameters.ClientId, authParameters.ClientSecret, authParameters.ServerUrl);

            string responseJson = nopAuthorizationManager.GetAuthorizationData(authParameters);

            AuthorizationModel authorizationModel = JsonConvert.DeserializeObject<AuthorizationModel>(responseJson);

            model.AuthorizationModel = authorizationModel;
            model.UserAccessModel = new UserAccessModel()
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                ServerUrl = serverUrl,
                RedirectUrl = redirectUrl
            };

            return model;
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult RefreshAccessToken(string refreshToken, string clientId, string clientSecret, string serverUrl)
        {
            string json = string.Empty;

            if (ModelState.IsValid &&
                !string.IsNullOrEmpty(refreshToken) &&
                !string.IsNullOrEmpty(clientId) &&
                 !string.IsNullOrEmpty(clientSecret) &&
                !string.IsNullOrEmpty(serverUrl))
            {
                var model = new AccessModel();

                try
                {
                    var authParameters = new AuthParameters()
                    {
                        ClientId = clientId,
                        ClientSecret = clientSecret,
                        ServerUrl = serverUrl,
                        RefreshToken = refreshToken,
                        GrantType = "refresh_token"
                    };

                    var nopAuthorizationManager = new AuthorizationManager(authParameters.ClientId,
                        authParameters.ClientSecret, authParameters.ServerUrl);

                    string responseJson = nopAuthorizationManager.RefreshAuthorizationData(authParameters);

                    AuthorizationModel authorizationModel =
                        JsonConvert.DeserializeObject<AuthorizationModel>(responseJson);

                    model.AuthorizationModel = authorizationModel;
                    model.UserAccessModel = new UserAccessModel()
                    {
                        ClientId = clientId,
                        ServerUrl = serverUrl
                    };

                    // Here we use the temp data because this method is called via ajax and here we can't hold a session.
                    // This is needed for the GetCustomers method in the CustomersController.
                    TempData["accessToken"] = authorizationModel.AccessToken;
                    TempData["serverUrl"] = serverUrl;
                }
                catch (Exception ex)
                {
                    json = string.Format("error: '{0}'", ex.Message);

                    return Json(json, JsonRequestBehavior.AllowGet);
                }

                json = JsonConvert.SerializeObject(model.AuthorizationModel);
            }
            else
            {
                json = "error: 'something went wrong'";
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        private ActionResult BadRequest(string message = "Bad Request")
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
        }
    }
}