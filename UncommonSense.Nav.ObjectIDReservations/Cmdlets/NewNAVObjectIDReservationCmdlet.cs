using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.Nav.ObjectIDReservations.Cmdlets
{
    /// <summary>
    /// <para type="description">Creates a new NAV object ID reservation</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "NavObjectIDReservation")]
    [OutputType(typeof(Reservation))]
    [Alias("reserve")]
    public class NewNAVObjectIDReservationCmdlet : NAVObjectIDReservationCmdlet
    {
        /// <summary>
        /// <para type="description">The type of object to reserve</para>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position = 1)]
        public ObjectType ObjectType { get; set; }

        /// <summary>
        /// <para type="description">One or more object IDs to reserve</para>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position = 2)]
        [ValidateRange(1, int.MaxValue)]
        public int[] ObjectID { get; set; }

        /// <summary>
        /// <para type="description">Optional comment for the reservation</para>
        /// </summary>
        [Parameter(Position = 3)]
        public string Comment { get; set; }

        /// <summary>
        /// <para type="desc">If present, allows overwriting of other users' reservations</para>
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
                        break;
                    case Situation.ReservationExistsAndIsYours:
                        WriteWarning($"{ObjectType} {objectID} is already reserved for you.");
                        continue;
                    case Situation.ReservationExistsAndIsNotYours when Force:
                        reservations.Remove(reservation);
                        break;
                    case Situation.ReservationExistsAndIsNotYours:
                        WriteError($"{ObjectType} {objectID} is already reserved by {reservation.UserName}.", "AlreadyReserved", ErrorCategory.ResourceUnavailable);
                        continue;
                    default:
                        throw new ArgumentOutOfRangeException("Unanticipated situation.");
                }

                var newReservation = new Reservation(
                    ObjectType,
                    objectID,
                    DateTime.Now,
                    Environment.UserName,
                    Comment
                );

                WriteObject(newReservation);
                reservations.Add(newReservation);
            }
        }

        /// <Exclude/>
        protected override void EndProcessing()
        {
            SaveReservations(reservations);
        }
    }
}
