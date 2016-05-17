namespace HotelBookingSystem.Controllers
{
    using System;
    using System.Linq;
    using Contracts;
    using Enums;
    using Infrastructure;
    using Models;

    /// <summary>
    /// Provides functionality need to perform operations with rooms.
    /// </summary>
    public class RoomsController : Controller
    {
        /// <summary>
        /// Gets a new controller which will update given data performed by passed user.
        /// </summary>
        /// <param name="data">Data in which controller will make changes to.</param>
        /// <param name="user">Provides the user who gives the commands.</param>
        public RoomsController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        /// <summary>
        /// Adds a new room to a venue.
        /// </summary>
        /// <param name="venueId">ID of the venue which current room will be part of.</param>
        /// <param name="places">Count of the available places in room.</param>
        /// <param name="pricePerDay">Cost of the room per day.</param>
        /// <returns>Specific view of this operation.</returns>
        public IView Add(int venueId, int places, decimal pricePerDay)
        {
            this.Authorize(Roles.VenueAdmin);
            var venue = Data.Venues.Get(venueId);
            if (venue == null)
            {
                return NotFound($"The venue with ID {venueId} does not exist.");
            }

            var newRoom = new Room(places, pricePerDay);
            venue.Rooms.Add(newRoom);
            this.Data.Rooms.Add(newRoom);
            return this.View(newRoom);
        }

        /// <summary>
        /// Adds period which current room will be reserved.
        /// </summary>
        /// <param name="roomId">ID of the room which will be reserved.</param>
        /// <param name="startDate">From when room will be reserved.</param>
        /// <param name="endDate">Untill when room will be reserved.</param>
        /// <returns>Specific view of this operation.</returns>
        /// <see cref="HotelBookingSystem.Views"/>
        public IView AddPeriod(int roomId, DateTime startDate, DateTime endDate)
        {
            this.Authorize(Roles.VenueAdmin);
            var room = this.Data.Rooms.Get(roomId);
            if (room == null)
            {
                return this.NotFound($"The room with ID {roomId} does not exist.");
            }

            if (startDate.Date > endDate.Date)
            {
                throw new ArgumentException("The date range is invalid.");
            }
            room.AvailableDates.Add(new AvailableDate(startDate, endDate));
            return this.View(room);
        }

        /// <summary>
        /// Gets all bookings for a specific room.
        /// </summary>
        /// <param name="id">ID of the room which bookings will be showed.</param>
        /// <returns>Specific view of this operation.</returns>
        public IView ViewBookings(int id)
        {
            this.Authorize(Roles.VenueAdmin);
            var room = this.Data.Rooms.Get(id);
            if (room == null)
            {
                return NotFound($"The room with ID {id} does not exist.");
            }

            return this.View(room.Bookings);
        }

        /// <summary>
        /// Book a current room.
        /// </summary>
        /// <param name="roomId">ID of the room which will be booked.</param>
        /// <param name="startDate">From when room will be booked.</param>
        /// <param name="endDate">Untile when room will be booked.</param>
        /// <param name="comments">Specific comments left by the user for the current booking.</param>
        /// <returns>Specific view of this operation.</returns>
        public IView Book(int roomId, DateTime startDate, DateTime endDate, string comments)
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);
            var room = this.Data.Rooms.Get(roomId);
            if (room == null)
            {
                return NotFound($"The room with ID {roomId} does not exist.");
            }

            if (endDate < startDate) throw new ArgumentException("The date range is invalid.");
            var availablePeriod = room.AvailableDates.FirstOrDefault(d => d.StartDate <= startDate || d.EndDate >= endDate);
            if (availablePeriod == null)
            {
                throw new ArgumentException(
                    $"The room is not available to book in the period {startDate:dd.MM.yyyy} - {endDate:dd.MM.yyyy}.");
            }

            decimal totalPrice = (endDate - startDate).Days * room.PricePerDay;
            var booking = new Booking(CurrentUser, startDate, endDate, totalPrice, comments);
            room.Bookings.Add(booking);
            this.CurrentUser.Bookings.Add(booking);
            this.UpdateRoomAvailability(startDate, endDate, room, availablePeriod);

            return this.View(booking);
        }

        // This works, don't touch!
        private void UpdateRoomAvailability(DateTime startDate, DateTime endDate, Room room, AvailableDate availablePeriod)
        {
            room.AvailableDates.Remove(availablePeriod);
            var periodBeforeBooking = startDate - availablePeriod.StartDate;
            if (periodBeforeBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.StartDate, availablePeriod.StartDate.Add(periodBeforeBooking)));
            }

            var periodAfterBooking = availablePeriod.EndDate - endDate;
            if (periodAfterBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.EndDate.Subtract(periodAfterBooking), availablePeriod.EndDate));
            }
        }
    }
}
