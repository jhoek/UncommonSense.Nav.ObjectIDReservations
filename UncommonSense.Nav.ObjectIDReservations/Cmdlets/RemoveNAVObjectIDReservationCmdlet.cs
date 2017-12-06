using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.Nav.ObjectIDReservations.Cmdlets
{
    /// <summary>
    /// <para type="description">Removes an existing NAV object ID reservation</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "NavObjectIDReservation")]
    [Alias("unreserve")]
    public class RemoveNAVObjectIDReservationCmdlet : NAVObjectIDReservationCmdlet
    {
        /// <summary>
        /// <para type="description">The type of the reserved object</para>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position = 1)]
        public ObjectType ObjectType { get; set; }

        /// <summary>
        /// <para type="description">The ID of the reserved object</para>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position = 2)]
        public int[] ObjectID { get; set; }

        /// <summary>
        /// <para type="description">If present, allows removal of other users' reservations</para>
        /// </summary>
        [Parameter()]
        public SwitchParameter Force { get; set; }

        /// <Exclude/>
        protected List<Reservation> reservations = new List<Reservation>();

        /// <Exclude/>
        protected override void BeginProcessing()
        {
            reservations = LoadReservations().ToList();
        }

        /// <Exclude/>
        protected override void ProcessRecord()
        {
            foreach (var objectID in ObjectID)
            {
                switch (GetSituation(reservations, ObjectType, objectID, out Reservation reservation))
                {
                    case Situation.ReservationDoesNotExist:
                        WriteError($"Reservation for {ObjectType} {objectID} does not exist.", "ReservationDoesNotExist", ErrorCategory.ResourceUnavailable);
                        continue;
                    case Situation.ReservationExistsAndIsYours:
                        break;
                    case Situation.ReservationExistsAndIsNotYours when Force:
                        break;
                    case Situation.ReservationExistsAndIsNotYours:
                        WriteError($"Reservation for {ObjectType} {objectID} exists but is not yours. Use -Force to remove this reservation.", "ReservationNotYours", ErrorCategory.InvalidOperation);
                        continue;
                    default:
                        throw new ArgumentOutOfRangeException("Unanticipated situation.");
                }

                WriteVerbose($"Removing reservation for {ObjectType} {objectID}");
                reservations.Remove(reservation);
            }
        }

        /// <Exclude/>
        protected override void EndProcessing()
        {
            SaveReservations(reservations);
        }
    }
}
