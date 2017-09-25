using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace UncommonSense.Nav.ObjectIDReservations
{
    // FIXME: Functions in profile die eerste tf get doen (niet eens default params nodig, dus)

    public abstract class NAVObjectIDReservationCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string DataFilePath { get; set; }

        public IEnumerable<Reservation> LoadReservations()
        {
            if (File.Exists(DataFilePath))
            {
                WriteVerbose($"Using data file '{DataFilePath}'.");

                return File
                    .ReadAllLines(DataFilePath, Encoding.UTF8)
                    .Where(l => !l.StartsWith("//"))
                    .Select(l => Reservation.FromString(l));
            }
            else
            {
                WriteWarning($"Specified data file '{DataFilePath}' does not exist.");

                return Enumerable.Empty<Reservation>();
            }
        }

        public void SaveReservations(IEnumerable<Reservation> reservations)
        {
            File
                .WriteAllLines(
                    DataFilePath,
                    reservations.Select(r => r.ToString()),
                    Encoding.UTF8);
        }

        public Situation GetSituation(IEnumerable<Reservation> reservations, ObjectType objectType, int objectID, out Reservation reservation)
        {
            reservation = reservations
                .Where(r => r.ObjectType == objectType)
                .Where(r => r.ObjectID == objectID)
                .SingleOrDefault();

            switch (reservation)
            {
                case null:
                    return Situation.ReservationDoesNotExist;
                case Reservation r when r.IsYours():
                    return Situation.ReservationExistsAndIsYours;
                default:
                    return Situation.ReservationExistsAndIsNotYours;
            }
        }

        protected void WriteError(string message, string errorId, ErrorCategory errorCategory)
        {
            WriteError(
                new ErrorRecord(
                    new ArgumentException(message),
                    errorId,
                    errorCategory,
                    null
                )
            );
        }
    }
}    