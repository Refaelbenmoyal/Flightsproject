using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    public class Customer
    {
    }
    public interface ILoginToken { };
    public class LoginToken<T> : ILoginToken
    {
        public T user;
    }
    public abstract class FacadeBase
    {

    }
    public class Ticket
    {
        public int FlightId { get; set; }
        public int Customer { get; set; }
        public string Country { get; set; }
    }
    public class Flight
    {
        public int Id { get; set; }
        public String OriginCountry { get; set; }
        public int Remaining { get; set; }
    }

    public class CustomerFacade : FacadeBase
    {
        private List<Flight> m_flights = new List<Flight>()
        {
            new Flight { Id = 1, OriginCountry = "Israel", Remaining = 12},
            new Flight { Id = 2, OriginCountry = "New York", Remaining = 0},
            new Flight { Id = 3, OriginCountry = "Italy", Remaining = 75}
        };
        public List<Ticket> GetAllTickets(LoginToken<Customer> token)
        {
            List<Ticket> results = new List<Ticket>();
            results.Add(new Ticket { FlightId = 30, Customer = 227, Country = "Israel" });
            results.Add(new Ticket { FlightId = 45, Customer = 963, Country = "Japan" });
            results.Add(new Ticket { FlightId = 200, Customer = 102, Country = "France" });
            return results;
        }

        public void PurchaseTicket(int flight_id)
        {

        }

        public Flight GetFlightById(int flight_id)
        {
            if (flight_id <= 0)
            {
                throw new IllegalFlightParameter($"cannot use the flight id {flight_id}");
            }
            return m_flights.FirstOrDefault<Flight>(_ => _.Id == flight_id);
        }
    }
    public class FlightCenterSystem
    {
        public static void Login(string username, string pwd, out FacadeBase facadeBase, out ILoginToken token)
        {
            // real login
            facadeBase = new CustomerFacade();
            token = new LoginToken<Customer>();
        }
    }

}
