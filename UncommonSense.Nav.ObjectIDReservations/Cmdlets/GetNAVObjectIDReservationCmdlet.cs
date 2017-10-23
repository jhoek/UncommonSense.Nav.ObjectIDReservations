using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.Nav.ObjectIDReservations.Cmdlets
{
    /// <summary>
    /// <para type="description">Retrieves all NAV object ID reservations</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "NAVObjectIDReservation")]
    [OutputType(typeof(Reservation))]
    [Alias("reservations")]
    public class GetNAVObjectIDReservationCmdlet : NAVObjectIDReservationCmdlet
    {
        /// <Exclude/>
        protected override void EndProcessing()
        {
            var reservations = LoadReservations();

            switch (reservations.Any())
            {
                case true:
                    WriteObject(reservations, true);
                    break;

                case false:
                    WriteWarning("The reservations list is empty.");
                    break;
            }
        }
    }
}
