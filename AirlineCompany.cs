using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    class AirlineCompany : IPoco, IUser
    {
        public AirlineCompany(string name, int country_Id, long user_Id)
        {
            Name = name;
            Country_Id = country_Id;
            User_Id = user_Id;
        }

        public AirlineCompany()
        {
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int Country_Id { get; set; }
        public long User_Id { get; set; }
        public string Password { get; internal set; }
        public int CountryId { get; internal set; }

        public static bool operator ==(AirlineCompany a1, AirlineCompany a2)
        {
            if ((a1 == null) && (a2 == null))
                return true;
            if ((a1 == null) || (a2 == null))
                return false;

            return (a1.Id == a2.Id);
        }
        public static bool operator !=(AirlineCompany a1, AirlineCompany a2)
        {
            return !(a1 == a2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            AirlineCompany a = obj as AirlineCompany;
            if (a == null)
                return false;

            return this.Id == a.Id;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public override string ToString()
        {
            return $" Name :name; Country_Id :country_Id; User_Id :user_Id";
        }
    }
}
