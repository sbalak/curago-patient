namespace Patient.Data
{
    public class SpecialityToSymptom
    {
        public int Id { get; set; }
        public int SpecialityId { get; set; }
        public int SymptomId { get; set; }

        public Speciality Speciality { get; set; }
        public Symptom Symptom { get; set; }
    }
}
