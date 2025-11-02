namespace Airbnb.Models
{
    public class Filter
    {
        public Filter(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all-all";
            string[] filters = FilterString.Split('-');
            LocationId = filters[0];
            CheckInDateId = filters[1];
            CheckOutDateId = filters[2];
            NoOfGuestsId = filters[3];
        }
        public string FilterString { get; }
        public string LocationId { get; }
        public string CheckInDateId { get; }
        public string CheckOutDateId { get; }
        public string NoOfGuestsId { get; }

        public bool HasLocation => LocationId.ToLower() != "all";
        public bool HasCheckInDate => CheckInDateId.ToString().ToLower() != "all";
        public bool HasCheckOutDate => CheckOutDateId.ToString().ToLower() != "all";
        public bool HasNoOfGuests => NoOfGuestsId.ToString().ToLower() != "all";
    }
}
