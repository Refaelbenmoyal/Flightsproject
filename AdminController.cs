using FlightsProject;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightsProjectWeb.Controllers
{
    [FlightsProject.Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class AdminController : FlightControllerBase<Administrator>
    {

        private IAdminFacade m_facade;
        private readonly IMapper m_mapper;

        public AdminController(IAdminFacade adminFacade, IMapper mapper)
        {
          
            m_facade = adminFacade;
            m_mapper = mapper;
        }

        [FlightsProject.HttpPost("createairline")]
        public IActionResult CreateAirline(AirlineCompanyCreationDTO airlineCompanyCreationDTO)
        {
            AirlineCompany company = new AirlineCompany()
            {
                Id = 1,
                CountryId = 12,
                Name = "El-Al"
            };
            LoginToken<Administrator> token = GetLoginToken();

            m_facade.CreateAirline(token, company);

            return new CreatedResult("/api/admin/getcompanybyid/" + company.Id, company);
        }

        private LoginToken<Administrator> GetLoginToken()
        {
            throw new NotImplementedException();
        }

        [FlightsProject.HttpGet("getairline")]
        public ActionResult<AirlineCompanyDTO> GetFlight()
        {

            AirlineCompany company = new AirlineCompany()
            {
                CountryId = 1,
                Id = 2,
                Name = "El-al",
                Password = "LikeHome12345678"
            };


            AirlineCompanyDTO airlineCompanyDTO = m_mapper.Map<AirlineCompanyDTO>(company);

            return Ok(JsonConvert.SerializeObject(airlineCompanyDTO));

        }

        private Task<ActionResult<AirlineCompanyDTO>> Ok(string v)
        {
            throw new NotImplementedException();
        }
    }
}

