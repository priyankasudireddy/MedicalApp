namespace HospitalAPI.Controllers
{
    public class InMemoryDataStore
    {
        public static List<Patient> Patients { get; } = new List<Patient>
        {
            new Patient { Id = 1, Name = "John Doe", MedicalCondition = "Flu", Age = 30, Gender = "Male" },
            new Patient { Id = 2, Name = "Jane Smith", MedicalCondition = "Cold", Age = 25, Gender = "Female" }
        };
    }
}
