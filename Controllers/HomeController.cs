using Airbnb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Controllers
{
    public class HomeController : Controller
    {
        private AirBnbContext _context;
        public HomeController(AirBnbContext context)
        {
            _context = context;
        }

        public ViewResult Index(AirBnbViewModels model)
        {
            var filterList = new Filter($"{model.ActiveLocation}-{DateTime.TryParse(model.ActiveCheckInDate, out DateTime checkInDate)}-{DateTime.TryParse(model.ActiveCheckOutDate, out DateTime checkOutDate)}-{model.ActiveNoOfGuests}");
            var filters = new Filter(filterList.FilterString);

            var session = new AirBnbSession(HttpContext.Session);
            var cookies = new AirBnbCookies(Request.Cookies, Response.Cookies);

            // Save filter criteria to session
            session.SaveFilterCriteria(model.ActiveLocation, model.ActiveCheckInDate, model.ActiveCheckOutDate, model.ActiveNoOfGuests);

            // Retrieve reservations if session empty
            if (session.GetMyReservationCount() == 0)
            { 
                var ids = cookies.GetMyReservationIds();
                if (ids.Length > 0)
                {
                    var reservations = _context.Reservation
                        .Include(r => r.Residence)
                        .ThenInclude(r => r.Location)
                        .Where(r => ids.Contains(r.ReservationId.ToString()))
                        .ToList();

                    session.SetMyReservations(reservations);
                }
            }

            // Base query
            IQueryable<Residence> query = _context.Residence
                .Include(r => r.Location)
                .OrderBy(r => r.Name);

            // Apply filters
            if (filters.HasLocation)
                query = query.Where(r => r.Location.LocationId.ToString() == model.ActiveLocation);

            if (filters.HasNoOfGuests)
                query = query.Where(r => r.GuestNumber.ToString() == model.ActiveNoOfGuests);

            if (filters.HasCheckInDate && filters.HasCheckOutDate)
            {
                var reservedIds = _context.Reservation
                    .Where(res => res.ReservationStartDate <= checkOutDate && res.ReservationEndDate >= checkInDate)
                    .Select(res => res.ResidenceId)
                    .Distinct()
                    .ToList();

                query = query.Where(r => !reservedIds.Contains(r.ResidenceId));
            }

            model.Location = _context.Location.OrderBy(l => l.Name).ToList();
            model.Residence = query.ToList();

            return View(model);
        }

        // ------------------ RESERVE ------------------
        [HttpGet]
        public IActionResult Reserve(int residenceId)
        {
            var session = new AirBnbSession(HttpContext.Session);
            var cookies = new AirBnbCookies(Request.Cookies, Response.Cookies);

            var checkInDate = ParseDate(session.GetActiveCheckInDate(), DateTime.Today);
            var checkOutDate = ParseDate(session.GetActiveCheckOutDate(), checkInDate.AddDays(1));

            var reservation = new Reservation
            {
                ResidenceId = residenceId,
                ReservationStartDate = checkInDate,
                ReservationEndDate = checkOutDate
            };

            _context.Reservation.Add(reservation);
            _context.SaveChanges();

            var reservations = session.GetMyReservations();
            reservations.Add(reservation);
            session.SetMyReservations(reservations);
            cookies.SetMyReservationIds(reservations);

            TempData["Message"] = "Reservation successful!";

            return RedirectToAction("Index", new
            {
                ActiveLocation = session.GetActiveLocation(),
                ActiveCheckInDate = session.GetActiveCheckInDate(),
                ActiveCheckOutDate = session.GetActiveCheckOutDate(),
                ActiveNoOfGuests = session.GetActiveNoOfGuests()
            });
        }

        // ------------------ CANCEL RESERVATION ------------------
        [HttpPost]
        public IActionResult CancelReservation(int reservationId)
        {
            var session = new AirBnbSession(HttpContext.Session);
            var cookies = new AirBnbCookies(Request.Cookies, Response.Cookies);

            var reservation = _context.Reservation.Find(reservationId);
            if (reservation != null)
            {
                _context.Reservation.Remove(reservation);
                _context.SaveChanges();
            }

            var reservations = session.GetMyReservations();
            reservations.RemoveAll(r => r.ReservationId == reservationId);
            session.SetMyReservations(reservations);
            cookies.RemoveReservationId(reservationId);

            TempData["Message"] = "Reservation cancelled successfully!";
            return RedirectToAction(nameof(Reservations));
        }

        // ------------------ MY RESERVATIONS ------------------
        public IActionResult Reservations()
        {
            var session = new AirBnbSession(HttpContext.Session);
            var cookies = new AirBnbCookies(Request.Cookies, Response.Cookies);

            var ids = cookies.GetMyReservationIds();
            var reservations = _context.Reservation
                .Include(r => r.Residence)
                .ThenInclude(r => r.Location)
                .Where(r => ids.Contains(r.ReservationId.ToString()))
                .ToList();

            var model = new AirBnbViewModels
            {
                Reservation = reservations,
                ActiveLocation = session.GetActiveLocation(),
                ActiveCheckInDate = session.GetActiveCheckInDate(),
                ActiveCheckOutDate = session.GetActiveCheckOutDate(),
                ActiveNoOfGuests = session.GetActiveNoOfGuests()
            };

            return View(model);
        }

        // ------------------ DETAILS ------------------
        public IActionResult Details(int residenceId)
        {
            var residence = _context.Residence
                .Include(r => r.Location)
                .FirstOrDefault(r => r.ResidenceId == residenceId) ?? new Residence();

            var session = new AirBnbSession(HttpContext.Session);

            var model = new AirBnbViewModels
            {
                Residences = residence,
                ActiveLocation = session.GetActiveLocation(),
                ActiveCheckInDate = session.GetActiveCheckInDate(),
                ActiveCheckOutDate = session.GetActiveCheckOutDate(),
                ActiveNoOfGuests = session.GetActiveNoOfGuests()
            };

            return View(model);
        }

        // ------------------ HELPER ------------------
        private static DateTime ParseDate(string dateStr, DateTime fallback)
        {
            return DateTime.TryParseExact(dateStr, "MM/dd/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime parsedDate)
                ? parsedDate
                : fallback;
        }
        public IActionResult Support()
        {
            return Content("Area: [none], Controller: Home, Action: Support");
        }
        public IActionResult CancellationPolicy()
        {
            return Content("Area: [none], Controller: Home, Action: CancellationPolicy");
        }
        public IActionResult TermsAndCondition()
        {
            return Content("Area: [none], Controller: Home, Action: TermsAndCondition");
        }
        public IActionResult CookiePolicies()
        {
            return Content("Area: [none], Controller: Home, Action: CookiePolicies");
        }
    }
}
