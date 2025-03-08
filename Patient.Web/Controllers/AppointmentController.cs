using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patient.Infrastructure;

namespace Patient.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentService _appointment;

        public AppointmentController(IAppointmentService appoinment)
        {
            _appointment = appoinment;
        }

        [HttpGet("Dates")]
        public async Task<List<DateModel>> Dates()
        {
            return await _appointment.GetDates();
        }

        [HttpGet("Availability")]
        public async Task<List<SlotModel>> Availability(int staffId, DateTime date)
        {
            return await _appointment.GetAvailability(staffId, date);
        }

        [HttpGet("Booking")]
        public async Task<BookingModel> Booking(int id)
        {
            return await _appointment.GetBooking(id);
        }

        [HttpGet("Bookings")]
        public async Task<List<BookingModel>> Bookings(int userId)
        {
            return await _appointment.GetBookings(userId);
        }

        [HttpPost("Book")]
        public async Task<BookingModel> Book(int userId, int appointmentId)
        {
            return await _appointment.Book(userId, appointmentId);
        }
    }
}
