namespace FlightsProjectWeb.Controllers
{
    public interface IMapper
    {
        T Map<T>(AirlineCompany company);
    }
}