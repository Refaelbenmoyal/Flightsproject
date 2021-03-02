using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    class Flight : IPoco
    {
        public Flight(int airline_Company_Id, int origin_Country_Id, int destination_Country_Id, DateTime departure_Time, DateTime landing_Time, int remaining_Tickets)
        {
            Airline_Company_Id = airline_Company_Id;
            Origin_Country_Id = origin_Country_Id;
            Destination_Country_Id = destination_Country_Id;
            Departure_Time = departure_Time;
            Landing_Time = landing_Time;
            Remaining_Tickets = remaining_Tickets;
        }
        public long Id_Flight { get; set; }
        public int Airline_Company_Id { get; set; }
        public int Origin_Country_Id { get; set; }
        public int Destination_Country_Id { get; set; }
        public DateTime Departure_Time { get; set; }
        public DateTime Landing_Time { get; set; }
        public int Remaining_Tickets { get; set; }
        public static bool operator ==(Flight f1, Flight f2)
        {
            if ((f1 == null) && (f2 == null))
                return true;
            if ((f1 == null) || (f2 == null))
                return false;

            return (f1.Id == f2.Id);
        }
        public static bool operator !=(Flight f1, Flight f2)
        {
            return !(f1 == f2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Flight f = obj as Flight;
            if (f == null)
                return false;

            return Id_Flight == Id_Flight;
        }

        public override int GetHashCode()
        {
            return (int)Id_Flight;
        }

        public override string ToString()
        {
            return $"Airline_Company_Id :airline_Company_Id,Origin_Country_Id: origin_Country_Id,Destination_Country_Id: destination_Country_IdDeparture_Time: departure_Time, Landing_Time: landing_Time,Remaining_Tickets: remaining_Tickets ";
        }
    }
}
    
