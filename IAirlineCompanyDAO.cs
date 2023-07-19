using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    public interface IAirlineCompanyDAO
    {
        AirlineCompany GetAirlineByName(string name);
    }
}
