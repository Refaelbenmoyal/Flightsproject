using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    class Ticket : IPoco
    {
        public Ticket(long flight_Id, long customer_Id)
        {
            Flight_Id = flight_Id;
            Customer_Id = customer_Id;
        }
        public long Id { get; set; }
        public long Flight_Id { get; set; }
        public long Customer_Id { get; set; }
        public static bool operator ==(Ticket t1, Ticket t2)
        {
            if ((t1 == null) && (t2 == null))
                return true;
            if ((t1 == null) || (t2 == null))
                return false;

            return (t1.Id == t2.Id);
        }
        public static bool operator !=(Ticket t1, Ticket t2)
        {
            return !(t1 == t2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Ticket t = obj as Ticket;
            if (t == null)
                return false;

            return this.Id == t.Id;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public override string ToString()
        {
            return $"Flight_Id :flight_Id,Customer_Id :customer_Id ";
        }
    }
}
