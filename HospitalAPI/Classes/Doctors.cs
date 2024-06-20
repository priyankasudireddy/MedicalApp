namespace HospitalAPI.Controllers
{
    public class Doctors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string Hospital { get; set; }
        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string state { get; set; }
        public string ZipCode { get; set; }
    }
}
