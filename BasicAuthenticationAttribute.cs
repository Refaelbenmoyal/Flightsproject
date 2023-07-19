using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace FlightsProject
{
    internal class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {

        [ThreadStatic]
        public static Airline CurrentAirline = null;

        public override void OnAuthorization(HttpActionContext actionContext)
        {
          

            string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;

            string decodedAuthenticationToken = Encoding.UTF8.GetString(
                Convert.FromBase64String(authenticationToken));

            string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
            string username = usernamePasswordArray[0];
            string password = usernamePasswordArray[1];

            if (username == "refael" && password == "1234")
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(username), null);
            }
            else
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}
