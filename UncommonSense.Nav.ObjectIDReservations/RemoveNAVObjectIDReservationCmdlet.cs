using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.Nav.ObjectIDReservations
{
    [Cmdlet(VerbsCommon.Remove, "NavObjectIDReservation")]
    public class RemoveNAVObjectIDReservationCmdlet : NAVObjectIDReservationCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position = 1)]
        public ObjectType ObjectType { get; set; }

        [Parameter(Mandatory =true, ValueFromPipeline =true, ValueFromPipelineByPropertyName =true, Position = 2)]
        public int[] ObjectID { get; set; }

        protected List<Reservation> reservations = new List<Reservation>();

        protected override void BeginProcessing()
        {
            reservations = LoadReservations().ToList();
        }

        protected override void ProcessRecord()
        {
            foreach (var objectID in ObjectID)
            {
                var reservation = reservations
                    .Where(r => r.ObjectType == ObjectType)
                    .Where(r => r.ObjectID == objectID)
                    .SingleOrDefault();

                if (ReservationExists(reservation))
                    if (ReservationIsYours(reservation))
                        reservations.Remove(reservation);
            }
        }

        protected override void EndProcessing()
        {
            SaveReservations(reservations);
        }
    }
}
