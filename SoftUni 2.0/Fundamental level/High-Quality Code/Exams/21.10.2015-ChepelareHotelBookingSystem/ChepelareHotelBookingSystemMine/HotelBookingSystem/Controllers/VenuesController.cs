namespace HotelBookingSystem.Controllers
{
    using Contracts;
    using Enums;
    using Infrastructure;
    using Models;

    public class VenuesController : Controller
    {
        public VenuesController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        public IView All()
        {
            var venues = this.Data.Venues.GetAll();
            var allVenuesView = this.View(venues);
            return allVenuesView;
        }

        public IView Details(int id)
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);
            var venue = this.Data.Venues.Get(id);

            if (venue == null)
            {
                return this.NotFound($"The venue with ID {id} does not exist.");
            }

            var venueView = this.View(venue);
            return venueView;
        }

        public IView Rooms(int id)
        {
            var venue = this.Data.Venues.Get(id);
            if (venue == null)
            {
                return this.NotFound($"The venue with ID {id} does not exist.");
            }

            return this.View(venue);
        }

        public IView Add(string name, string address, string description)
        {
            var newVenue = new Venue(name, address, description, CurrentUser);
            this.Data.Venues.Add(newVenue);
            return this.View(newVenue);
        }
    }
}