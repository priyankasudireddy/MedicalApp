using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalController : ControllerBase
    {
        private static List<Doctors> doctors = new List<Doctors>
     {
         // Testing git second time
         // Initialize some sample data
 new Doctors { Id = 1, Name = "Dr. Smith", Speciality = "General", Hospital = "General Hospital", PhoneNumber = 2034785960, Email = "smith1@gmail.com", Address = "123 Main St", City = "Houston", state = "Tx", ZipCode = "77077"},
 // Add more doctors here if needed
 };
        // GET api/doctors/5
        [HttpGet]
        public ActionResult<List<Doctors>> Get()
        {
            if (doctors == null)
            {
                return NotFound();
            }
            return Ok(doctors.ToList());
        }

        // GET api/doctors/5
        [HttpGet("{id}")]
        public ActionResult<Doctors> Get(int id)
        {
            var doctor = doctors.FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
        [HttpPost]

        public ActionResult<Doctors> Post([FromBody] Doctors doctor)
        {
            doctor.Id = doctors.Count + 1;
            doctors.Add(doctor);
            //return CreatedAtRoute("GetDoctor", new { id = doctor.Id }, doctor);
            return doctor;

        }



        [HttpPut("{id}")]
        public ActionResult<Doctors> Put(int id, [FromBody] Doctors doctor)
        {
            var existingDoctor = doctors.FirstOrDefault(d => d.Id == id);
            if (existingDoctor == null)
            {
                return NotFound();
            }
            //Update existing doctor
            existingDoctor.Name = doctor.Name;
            existingDoctor.Speciality = doctor.Speciality;
            existingDoctor.Hospital = doctor.Hospital;
            existingDoctor.PhoneNumber = doctor.PhoneNumber;
            existingDoctor.Email = doctor.Email;
            existingDoctor.Address = doctor.Address;
            existingDoctor.City = doctor.City;
            existingDoctor.state = doctor.state;
            existingDoctor.ZipCode = doctor.ZipCode;
            return Ok(existingDoctor);

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var doctor = doctors.FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            doctors.Remove(doctor);
            return Ok(doctor);
        }

    }
}
