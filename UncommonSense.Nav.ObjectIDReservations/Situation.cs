﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.Nav.ObjectIDReservations
{
    public enum Situation
    {
        ReservationDoesNotExist,
        ReservationExistsAndIsYours,
        ReservationExistsAndIsNotYours
    }
}
