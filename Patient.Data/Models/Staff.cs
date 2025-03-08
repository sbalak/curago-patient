namespace Patient.Data
{
    public class Staff
    {
        public int Id { get; set; }
        public int PrimarySpecialityId { get; set; }
        public int? SecondarySpecialityId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Locality { get; set; }
        public string? City { get; set; }
        public string? Postcode { get; set; }
        public decimal? Fee { get; set; }
        public int Experience { get; set; }
        public string? RegisterInterest { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
        public string? Otp { get; set; }
        public DateTime? OtpExpiry { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateVerified { get; set; }
        public DateTime? DateInitiated { get; set; }

        public Speciality PrimarySpeciality { get; set; }
        public Speciality? SecondarySpeciality { get; set; }
    }

    public class StaffEducation
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Degree { get; set; }
        public string Major { get; set; }
        public int Graduation { get; set; }
        public string Institution { get; set; }
        public string Path { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateVerified { get; set; }
        public Staff Staff { get; set; }
    }

    public class StaffIdentifier
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Type { get; set; } // Passport, Aadhaar
        public string Number { get; set; }
        public DateTime Issue { get; set; }
        public DateTime Expiry { get; set; }
        public string Path { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateVerified { get; set; }
        public Staff Staff { get; set; }
    }
}
