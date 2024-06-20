using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatiController : ControllerBase
    {
        // GET: api/Patients getting patients
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetPatients()
        {
            return InMemoryDataStore.Patients;
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public ActionResult<Patient> GetPatient(int id)
        {
            var patient = InMemoryDataStore.Patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // PUT: api/Patients/5
        [HttpPut("{id}")]
        public IActionResult PutPatient(int id, Patient patient)
        {
            var existingPatient = InMemoryDataStore.Patients.FirstOrDefault(p => p.Id == id);
            if (existingPatient == null)
            {
                return NotFound();
            }

            existingPatient.Name = patient.Name;
            existingPatient.MedicalCondition = patient.MedicalCondition;
            existingPatient.Age = patient.Age;
            existingPatient.Gender = patient.Gender;

            return NoContent();
        }

        // POST: api/Patients
        [HttpPost]
        public ActionResult<Patient> PostPatient(Patient patient)
        {
            int newId = InMemoryDataStore.Patients.Any() ? InMemoryDataStore.Patients.Max(p => p.Id) + 1 : 1;
            patient.Id = newId;
            InMemoryDataStore.Patients.Add(patient);

            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = InMemoryDataStore.Patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            InMemoryDataStore.Patients.Remove(patient);

            return NoContent();
        }
    }
}

  