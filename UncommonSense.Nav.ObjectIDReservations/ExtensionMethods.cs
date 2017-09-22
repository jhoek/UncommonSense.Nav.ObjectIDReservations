using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.Nav.ObjectIDReservations
{
    public static class ExtensionMethods
    {
        public static T ToEnum<T>(this string value) where T : struct => (T)Enum.Parse(typeof(T), value, true);
        public static int ToInt(this string value) => int.Parse(value);
        public static DateTime ToDateTime(this string value) => DateTime.ParseExact(value, "s", CultureInfo.InvariantCulture);
        public static bool IsYours(this Reservation reservation) => reservation?.UserName.Equals(Environment.UserName, StringComparison.InvariantCultureIgnoreCase) ?? false;
    }
}
