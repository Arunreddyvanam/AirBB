namespace Airbnb.Models
{
    public class AirBnbSession
    {
        private const string ReservationKey = "reservationskey";
        private const string CountKey = "countKey";
        private const string ActiveLocationKey = "locationKey";
        private const string CheckInDateKey = "checkInDateKey";
        private const string CheckOutDateKey = "checkOutDateKey";
        private const string NoOfGuestsKey = "noOfGuestsKey";

        private readonly ISession _session;
        public AirBnbSession(ISession session) => _session = session;

        public void SetMyReservations(List<Reservation> reservations)
        {
            _session.SetObject(ReservationKey, reservations);
            _session.SetInt32(CountKey, reservations.Count);
        }

        public List<Reservation> GetMyReservations() =>
            _session.GetObject<List<Reservation>>(ReservationKey) ?? new List<Reservation>();

        public int GetMyReservationCount() => _session.GetInt32(CountKey) ?? 0;

        private void SetValue(string key, string value) => _session.SetString(key, value);
        private string GetValue(string key) => _session.GetString(key) ?? string.Empty;

        public void SetActiveLocation(string value) => SetValue(ActiveLocationKey, value);
        public string GetActiveLocation() => GetValue(ActiveLocationKey);

        public void SetActiveCheckInDate(string value) => SetValue(CheckInDateKey, value);
        public string GetActiveCheckInDate() => GetValue(CheckInDateKey);

        public void SetActiveCheckOutDate(string value) => SetValue(CheckOutDateKey, value);
        public string GetActiveCheckOutDate() => GetValue(CheckOutDateKey);

        public void SetActiveNoOfGuests(string value) => SetValue(NoOfGuestsKey, value);
        public string GetActiveNoOfGuests() => GetValue(NoOfGuestsKey);

        public void SaveFilterCriteria(string location, string checkIn, string checkOut, string guests)
        {
            SetActiveLocation(location);
            SetActiveCheckInDate(checkIn);
            SetActiveCheckOutDate(checkOut);
            SetActiveNoOfGuests(guests);
        }
    }
}
