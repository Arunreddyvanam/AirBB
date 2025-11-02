namespace Airbnb.Models
{
    public class AirBnbCookies
    {
        private const string ReservationKey = "reservationskey";
        private const string Delimiter = "-";
        private const int CookieExpiryDays = 7;

        private readonly IRequestCookieCollection _requestCookies;
        private readonly IResponseCookies _responseCookies;

        public AirBnbCookies(IRequestCookieCollection request, IResponseCookies response)
        {
            _requestCookies = request;
            _responseCookies = response;
        }

        public void RemoveReservationId(int id)
        {
            var reservationIds = GetMyReservationIds()
                .Where(rid => rid != id.ToString());
            SetMyReservationIds(reservationIds);
        }

        public void SetMyReservationIds(IEnumerable<Reservation> reservations) =>
            SetMyReservationIds(reservations.Select(r => r.ReservationId.ToString()));

        public void SetMyReservationIds(IEnumerable<string> ids)
        {
            var idsString = string.Join(Delimiter, ids);
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(CookieExpiryDays),
                IsEssential = true
            };

            _responseCookies.Delete(ReservationKey);
            _responseCookies.Append(ReservationKey, idsString, options);
        }

        public string[] GetMyReservationIds() =>
            (_requestCookies[ReservationKey]?.Split(Delimiter)) ?? Array.Empty<string>();

    }
}
