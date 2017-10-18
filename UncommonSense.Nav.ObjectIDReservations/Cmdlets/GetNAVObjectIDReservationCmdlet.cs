using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.Nav.ObjectIDReservations.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "NAVObjectIDReservation")]
    [OutputType(typeof(Reservation))]
    [Alias("reservations")]
    public class GetNAVObjectIDReservationCmdlet : NAVObjectIDReservationCmdlet
    {
        protected override void EndProcessing()
        {
            WriteObject(LoadReservations(), true);                        
        }
    }
}
