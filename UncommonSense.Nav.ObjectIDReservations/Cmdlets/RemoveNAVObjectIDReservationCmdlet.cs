﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.Nav.ObjectIDReservations.Cmdlets
{
    [Cmdlet(VerbsCommon.Remove, "NavObjectIDReservation")]
    public class RemoveNAVObjectIDReservationCmdlet : NAVObjectIDReservationCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position = 1)]
        public ObjectType ObjectType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position = 2)]
        public int[] ObjectID { get; set; }

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
                        WriteError($"Reservation for {ObjectType} {objectID} does not exist.", "ReservationDoesNotExist", ErrorCategory.ResourceUnavailable);
                        continue;
                    case Situation.ReservationExistsAndIsYours:
                        break;
                    case Situation.ReservationExistsAndIsNotYours when Force:
                        break;
                    case Situation.ReservationExistsAndIsNotYours:
                        WriteError($"Reservation for {ObjectType} {objectID} exists but is not yours.", "ReservationNotYours", ErrorCategory.InvalidOperation);
                        continue;
                    default:
                        throw new ArgumentOutOfRangeException("Unanticipated situation.");
                }

                reservations.Remove(reservation);
            }
        }

        protected override void EndProcessing()
        {
            SaveReservations(reservations);
        }
    }
}