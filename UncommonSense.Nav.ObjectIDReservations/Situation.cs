using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 1591

namespace UncommonSense.Nav.ObjectIDReservations
{
    public enum Situation
    {
        ReservationDoesNotExist,
        ReservationExistsAndIsYours,
        ReservationExistsAndIsNotYours
    }
}

#pragma warning restore 1591