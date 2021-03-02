using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    class Administrator : IPoco, IUser
    {
        public Administrator(string first_Name, string last_Name, int level, long user_Id)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            Level = level;
            User_Id = user_Id;
        }
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Level { get; set; }
        public long User_Id { get; set; }

        public static bool operator ==(Administrator a1, Administrator a2)
        {
            if ((a1 == null) && (a2 == null))
                return true;
            if ((a1 == null) || (a2 == null))
                return false;

            return (a1.Id == a2.Id);
        }
        public static bool operator !=(Administrator a1, Administrator a2)
        {
            return !(a1 == a2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Administrator a = obj as Administrator;
            if (a == null)
                return false;

            return this.Id == a.Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        public override string ToString()
        {
            return $"First_Name:first_Name, Last_Name: last_Name, Level:level, User_Id:user_Id";
        }
    }
}
