using System.Linq;
using System.Management.Automation;

namespace UncommonSense.Nav.ObjectIDReservations.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Retrieves all NAV object ID reservations</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "NAVObjectIDReservation")]
    [OutputType(typeof(Reservation))]
    [Alias("reservations")]
    public class GetNAVObjectIDReservationCmdlet : NAVObjectIDReservationCmdlet
    {
        /// <summary>
        /// <para type="description">Filters reservations by specified comment text.</para>
        /// </summary>
        [Parameter()]
        [ValidateNotNull()]
        [SupportsWildcards()]
        public string Comment { get; set; } = "*";

        /// <summary>
        /// <para type="description">Filters reservations by specified user name.</para>
        /// </summary>
        [Parameter()]
        [ValidateNotNull()]
        [SupportsWildcards()]
        public string UserName { get; set; } = "*";

        /// <summary>
        /// <para type="description">Filters reservations by specified object type.</para>
        /// </summary>
        [Parameter()]
        [ValidateCount(1, int.MaxValue)]
        public ObjectType[] ObjectType { get; set; } = System.Enum.GetValues(typeof(ObjectType)).Cast<ObjectType>().ToArray();

        /// <Exclude/>
        protected override void EndProcessing()
        {
            var reservations = LoadReservations();

            if (!reservations.Any())
            {
                WriteWarning("The reservations list is empty.");
                return;
            }

            reservations =
                reservations
                    .Where(r => new WildcardPattern(UserName, WildcardOptions.CultureInvariant | WildcardOptions.IgnoreCase).IsMatch(r.UserName))
                    .Where(r => new WildcardPattern(Comment, WildcardOptions.CultureInvariant | WildcardOptions.IgnoreCase).IsMatch(r.Comment))
                    .Where(r => ObjectType.Contains(r.ObjectType));

            switch (reservations.Any())
            {
                case true:
                    WriteObject(reservations, true);
                    break;

                case false:
                    WriteWarning("No reservations match your filter criteria.");
                    break;
            }
        }
    }
}