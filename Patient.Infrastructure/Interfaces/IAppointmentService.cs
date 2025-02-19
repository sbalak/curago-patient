namespace Patient.Infrastructure
{
    public interface IAppointmentService
    {
        Task<List<DateModel>> GetDates();
        Task<List<SlotModel>> GetAvailability(int staffId, DateTime date);
        Task<BookingModel> GetBooking(int id);
        Task<List<BookingModel>> GetBookings(int userId);
        Task<BookingModel> Book(int userId, int appointmentId);
    }
}