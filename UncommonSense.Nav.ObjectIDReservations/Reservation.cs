using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

#pragma warning disable 1591

namespace UncommonSense.Nav.ObjectIDReservations
{
    public class Reservation
    {
        internal Reservation(ObjectType objectType, int objectID, DateTime dateTime, string userName, string comment)
        {
            ObjectType = objectType;
            ObjectID = objectID;
            DateTime = dateTime;
            UserName = userName;
            Comment = comment;
        }

        public ObjectType ObjectType { get; }
        public int ObjectID { get; }
        public DateTime DateTime { get; }
        public string UserName { get; }
        public string Comment { get; }

        public override string ToString() => $"{ObjectType};{ObjectID};{DateTime.ToString("s")};{UserName};{Comment}";

        public static Reservation FromString(string s)
        {
            var parts = s.Split(";".ToCharArray(), 5);

            return new Reservation(
                parts[0].ToEnum<ObjectType>(),
                parts[1].ToInt(),
                parts[2].ToDateTime(),
                parts[3],
                parts[4]);
        }
    }
}

#pragma warning restore 1591