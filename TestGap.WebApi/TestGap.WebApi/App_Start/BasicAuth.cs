using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Web;
using System.Web.Script.Serialization;

namespace TestGap.WebApi.App_Start
{
    public class BasicAuth : IHttpModule
    {
        private const string Realm = "My Realm";
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }
        // TODO: Here is where you would validate the username and password.
        private static bool CheckPassword(string username, string password)
        {
            return username == "my_user" && password == "my_password";
        }

        private static void AuthenticateUser(string credentials)
        {
            try
            {
                var encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                credentials = encoding.GetString(Convert.FromBase64String(credentials));

                int separator = credentials.IndexOf(':');
                string name = credentials.Substring(0, separator);
                string password = credentials.Substring(separator + 1);

                if (CheckPassword(name, password))
                {
                    var identity = new System.Security.Principal.GenericIdentity(name);
                    SetPrincipal(new GenericPrincipal(identity, null));
                }
                else
                {
                    // Invalid username or password.
                    dynamic Response = new System.Dynamic.ExpandoObject();
                    Response.success = false;
                    Response.error_code = HttpStatusCode.Unauthorized;
                    Response.error_msg = "Not authorized";                 
                    var json = new JavaScriptSerializer().Serialize(Response);
                    HttpContext.Current.Response.Output.Write(json);
                    HttpContext.Current.Response.StatusCode = 401;
                }
            }
            catch (FormatException)
            {
                // Credentials were not formatted correctly.
                dynamic Response = new System.Dynamic.ExpandoObject();
                Response.success = false;
                Response.error_code = HttpStatusCode.Unauthorized;
                Response.error_msg = "Not authorized";
                // Invalid username or password.
                var json = new JavaScriptSerializer().Serialize(Response);
                HttpContext.Current.Response.Output.Write(json);
                HttpContext.Current.Response.StatusCode = 401;
            }
        }

        private static void SetPrincipal(GenericPrincipal genericPrincipal)
        {
          
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);
                if (authHeaderVal.Scheme.Equals("basic",
                        StringComparison.OrdinalIgnoreCase) &&
                    authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        // If the request was unauthorized, add the WWW-Authenticate header 
        // to the response.
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate",
                    string.Format("Basic realm=\"{0}\"", Realm));
            }
        }
    }
}