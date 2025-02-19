using Microsoft.EntityFrameworkCore;
using Patient.Data;

namespace Patient.Infrastructure
{
    public class AppointmentService : IAppointmentService
    {
        private readonly PatientContext _context;

        public AppointmentService(PatientContext context)
        {
            _context = context;
        }

        public async Task<List<DateModel>> GetDates()
        {
            try
            {
                List<DateModel> dates = new List<DateModel>();

                for (int i = 0; i < 7; i++)
                {
                    DateTime currentDate = DateTime.Now.Date.AddDays(i);

                    DateModel date = new DateModel()
                    {
                        FormattedDate = currentDate,
                        Date = currentDate.ToString("dd"),
                        Day = currentDate.ToString("ddd")
                    };

                    dates.Add(date);
                }

                return dates;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<SlotModel>> GetAvailability(int staffId, DateTime date)
        {
            try
            {
                List<SlotModel> slots = new List<SlotModel>();

                var availableAppointments = await _context.Appointments
                                                 .Where(m => 
                                                            m.StaffId == staffId && 
                                                            m.Start.Date == date.Date)
                                                 .OrderBy(m => m.Start)
                                                 .ToListAsync();

                if (availableAppointments.Count > 0)
                {
                    var availableSlots = availableAppointments.Select(m => m.Slot).Distinct().OrderBy(m => m);

                    foreach (var availableSlot in availableSlots)
                    {
                        SlotModel slot = new SlotModel();
                        List<AppointmentModel> appointments = new List<AppointmentModel>();

                        var availableAppointmentsBySlot = availableAppointments.Where(m => m.Slot == availableSlot)
                                                                               .OrderBy(m => m.Start)
                                                                               .ToList();

                        foreach (var availableAppointment in availableAppointmentsBySlot)
                        {
                            AppointmentModel appointment = new AppointmentModel()
                            {
                                Id = availableAppointment.Id,
                                Slot = availableAppointment.Slot,
                                Start = availableAppointment.Start.ToString("hh:mm"),
                                End = availableAppointment.End.ToString("hh:mm"),
                                IsAvailable = availableAppointment.IsAvailable
                            };

                            appointments.Add(appointment);
                        }

                        slot.Slot = availableSlot;
                        slot.Appointments = appointments;

                        slots.Add(slot);
                    }
                }

                return slots;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public async Task<BookingModel> GetBooking(int id)
        {
            try
            {
                var booking = await _context.Bookings
                                            .Where(m => m.Id == id)
                                            .Select(m => new BookingModel
                                            {
                                                AppointmentId = m.AppointmentId,
                                                Staff = m.Appointment.Staff.FirstName + " " + m.Appointment.Staff.LastName,
                                                Credentials = m.Appointment.Staff.PrimarySpeciality.CorrespondingRole,
                                                Date = m.Appointment.Start.ToString("D"),
                                                Time = m.Appointment.Start.ToString("hh:mm")
                                            })
                                            .FirstOrDefaultAsync();

                return booking;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public async Task<List<BookingModel>> GetBookings(int userId)
        {
            try
            {
                var bookings = await _context.Bookings
                                            .Where(m => m.UserId == userId)
                                            .Select(m => new BookingModel
                                            {
                                                AppointmentId = m.AppointmentId,
                                                Staff = m.Appointment.Staff.FirstName + " " + m.Appointment.Staff.LastName,
                                                Credentials = m.Appointment.Staff.PrimarySpeciality.CorrespondingRole,
                                                Date = m.Appointment.Start.ToString("D"),
                                                Time = m.Appointment.Start.ToString("hh:mm")
                                            })
                                            .ToListAsync();

                return bookings;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<BookingModel> Book(int userId, int appointmentId)
        {
            try
            {
                Booking newBooking = new Booking()
                {
                    UserId = userId,
                    AppointmentId = appointmentId
                };

                _context.Bookings.Add(newBooking);
                await _context.SaveChangesAsync();

                var appointment = await _context.Appointments
                                                .Where(m => m.Id == appointmentId)
                                                .FirstOrDefaultAsync();
                if (appointment != null)
                {
                    appointment.IsAvailable = false;

                    _context.Appointments.Update(appointment);
                    await _context.SaveChangesAsync();
                }

                var booking = await _context.Bookings
                                            .Where(m => m.Id == newBooking.Id)
                                            .Select(m => new BookingModel
                                            {
                                                AppointmentId = m.AppointmentId,
                                                Staff = m.Appointment.Staff.FirstName + " " + m.Appointment.Staff.LastName,
                                                Credentials = m.Appointment.Staff.PrimarySpeciality.CorrespondingRole,
                                                Date = m.Appointment.Start.ToString("D"),
                                                Time = m.Appointment.Start.ToString("hh:mm")
                                            })
                                            .FirstOrDefaultAsync();

                return booking;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
