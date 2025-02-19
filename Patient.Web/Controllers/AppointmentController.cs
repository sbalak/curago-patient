using Microsoft.AspNetCore.Mvc;
using Patient.Infrastructure;

namespace Patient.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost("Book")]
        public Task Book(int staffId, DateTime date, TimeOnly start)
        {
            return _appointment.Book(staffId, date, start);
        }
    }
}
