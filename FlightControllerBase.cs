using FlightsProject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FlightsProjectWeb.Controllers
{
    public abstract class FlightControllerBase<T> : ControllerBase where T : IUser, new()
{
protected LoginToken<T> GetLoginToken()
{
            string userName = User.Claims.First(_ => _.Type == "username").Value;
            long id = Convert.ToInt64(User.Claims.First(_ => _.Type == "userid").Value);

            LoginToken<T> login_token = new LoginToken<T>()
            {
                user = new T()
                {
                    Id = id,
                    Name = userName,
                    Password = "no password. created from JWT"
                }
            };
            return login_token;
        }
    }
}
