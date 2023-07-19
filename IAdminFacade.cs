using FlightsProject;

namespace FlightsProjectWeb.Controllers
{
    public interface IAdminFacade
    {
        void CreateAirline(LoginToken<Administrator> token, AirlineCompany company);
    }
}