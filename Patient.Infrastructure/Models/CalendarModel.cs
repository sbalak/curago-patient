namespace Patient.Infrastructure
{
    public class DateModel
    {
        public DateTime FormattedDate {get;set; }
        public string Date { get; set; }
        public string Day { get; set; }
    }

    public class SlotModel
    {
        public SlotModel() 
        {
            Appointments = new List<AppointmentModel>();
        }

        public string Slot { get; set; }
        public List<AppointmentModel> Appointments { get; set; }


    }

    public class AppointmentModel
    {
        public int Id { get; set; }
        public string Slot { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public bool IsAvailable { get; set; }
    }
}