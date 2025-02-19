namespace Patient.Infrastructure
{
    public interface IAppointmentService
    {
        Task<List<DateModel>> GetDates();
        Task<List<SlotModel>> GetAvailability(int staffId, DateTime date);
        Task Book(int staffId, DateTime date, TimeOnly start); 
    }
}
