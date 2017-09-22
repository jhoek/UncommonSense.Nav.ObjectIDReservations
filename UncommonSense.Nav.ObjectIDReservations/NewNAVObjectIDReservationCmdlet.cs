using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.Nav.ObjectIDReservations
{
    [Cmdlet(VerbsCommon.New, "NavObjectIDReservation")]
    public class NewNAVObjectIDReservationCmdlet : NAVObjectIDReservationCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position = 1)]
        public ObjectType ObjectType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position = 2)]
        [ValidateRange(1, int.MaxValue)]
        public int[] ObjectID { get; set; }

        [Parameter()]
        public string Comment { get; set; }

        [Parameter()]
        public SwitchParameter Force { get; set; }

        protected List<Reservation> reservations = new List<Reservation>();

        protected override void BeginProcessing()
        {
            reservations = LoadReservations().ToList();
        }

        protected override void ProcessRecord()
        {
            foreach (var objectID in ObjectID)
            {
                switch (GetSituation(reservations, ObjectType, objectID, out Reservation reservation))
                {
                    case Situation.ReservationDoesNotExist:
                        break;
                    case Situation.ReservationExistsAndIsYours:
                        WriteWarning("FIXME");
                        continue;
                    case Situation.ReservationExistsAndIsNotYours when Force:
                        reservations.Remove(reservation);
                        break;
                    case Situation.ReservationExistsAndIsNotYours:
                        // FIXME: WriteError("");
                        continue;
                    default:
                        throw new ArgumentOutOfRangeException("Unanticipated situation.");
                }

                reservations.Add(
                    new Reservation(
                        ObjectType,
                        objectID,
                        DateTime.Now,
                        Environment.UserName,
                        Comment
                    )
                );
            }
        }

        protected override void EndProcessing()
        {
            SaveReservations(reservations);
        }
    }
}
