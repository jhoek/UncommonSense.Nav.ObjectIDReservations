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
                return File
                    .ReadAllLines(DataFilePath, Encoding.UTF8)
                    .Where(l => !l.StartsWith("//"))
                    .Select(l => Reservation.FromString(l));
            }
            else
            {
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

        public bool ReservationExists(Reservation reservation)
        {
            if (reservation == null)
            {
                WriteError(
                    new ErrorRecord(
                        new ItemNotFoundException("FIXME"),
                        "FIXME:ErrorID",
                        ErrorCategory.InvalidOperation, 
                        null
                    )
                );
                return false;
            }
            else
            {
                return true;
            }            
        }

        public bool ReservationIsYours(Reservation reservation)
        {
            if (reservation.UserName.Equals(Environment.UserName, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                WriteError(
                    new ErrorRecord(
                        new ItemNotFoundException("FIXME"),
                        "FIXME:ErrorID",
                        ErrorCategory.InvalidOperation,
                        null
                    )
                );

                return false;
            }
        }
    }
}
