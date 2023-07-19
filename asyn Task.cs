using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightsProject
{
    [HttpGet("getflight/{flight_id}")]
    public async Task<ActionResult<Flight>> GetFlightById(int flightid)
    {
       
        AuthenticateAndGetTokenAndGetFacade(out LoginToken<Customer>
               token_customer, out CustomerFacade facade);

        Flight result = null;
        try
        {
            result = await Task.Run(() => facade.GetFlightById(flight_id));
        }
        catch (IllegalFlightParameter ex)
        {
            return StatusCodeResult(400, $"{{ error: \"{ex.Message}\" }}");
           
        }
        if (result == null)
        {
            return StatusCodeResult(204, "{ }");
        }
        return Ok(result);
       
    }

    private ActionResult<Flight> StatusCodeResult(int v1, string v2)
    {
        throw new NotImplementedException();
    }

    private ActionResult<Flight> Ok(Flight result)
    {
        throw new NotImplementedException();
    }

    private ActionResult<Flight> StatusCode(int v1, string v2)
    {
        throw new NotImplementedException();
    }
}
