using HospitalAPI.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HospitalAPI.Controllers
{
    public class Hospital_ManagmentController : Controller
    {
        private readonly AppDbContext _context;
        public Hospital_ManagmentController(AppDbContext context)
        {
            _context = context;

        }
        private static List<Facility> Facility = new List<Facility>
        {
            // Sample Information

        new Facility { Ward = 1, Room = 101, Staff = 10, Equipment = "All Medical Equipment" },
        };

        //Ward Information

        [HttpGet("{FacilityId}/ward")]
        public async Task<ActionResult<List<EyeWard>>> Getward()
        {
            if (Facility.Count == null)
            {
                return BadRequest();
            }
            return Ok(Facility.ToList());

        }

        [HttpPost("{FacilityId}/ward")]
        public async Task<ActionResult<EyeWard>> postWard(EyeWard ward)


        {
            try
            {
                _context.Wards.Add(ward);
                await _context.SaveChangesAsync();
                var response = _context.SaveChanges();
                return CreatedAtAction(nameof(Getward), new { id = ward.Ward }, ward);
                
            }
            catch (Exception ex)
            {
                return null;
            }
            return Ok("Ward added successfully");
        }
        [HttpPut("{FacilityId}/ward")]
        public IActionResult UpdateWard(int wardId, [FromBody] EyeWard ward)
        {
            var existingWard = Facility.FirstOrDefault(w => w.Ward == wardId);
            if (existingWard == null)
            {
                return NotFound($"Ward with ID {wardId} not found");
            }

            existingWard.Room = ward.Room;
            existingWard.Staff = ward.Staff;
            existingWard.Equipment = ward.Equipment;

            return Ok($"Ward with ID {wardId} updated successfully");
        }

        [HttpDelete("{FacilityId}/ward")]
        public IActionResult DeleteWard(int wardId)
        {

            return Ok($"Ward with ID {wardId} deleted successfully");
        }


        //Room Information

        [HttpGet("{wardId}/rooms")]
        public async Task<ActionResult<List<RoomModel>>> Getroom()
        {
            if (Facility.Count == null)
            {
                return BadRequest();
            }
            return Ok(Facility.ToList());

        }

        [HttpPost("{wardId}/rooms")]
        public IActionResult AddRoom(int wardId, [FromBody] RoomModel room)
        {
            try
            {
                _context.Room.Add(room);
                var response = _context.SaveChanges();
                return CreatedAtAction(nameof(Getroom), new { id = room.Room }, room);
               
            }
            catch (Exception ex)
            {
                return null;
            }

            return Ok($"Room added to ward {wardId} successfully");
        }
        [HttpPut("{wardId}/rooms")]
        public IActionResult Updateroom(int wardId, [FromBody] EyeWard ward)
        {
            var existingWard = Facility.FirstOrDefault(w => w.Ward == wardId);
            if (existingWard == null)
            {
                return NotFound($"Ward with ID {wardId} not found");
            }

            existingWard.Room = ward.Room;
            existingWard.Staff = ward.Staff;
            existingWard.Equipment = ward.Equipment;

            return Ok($"Ward with ID {wardId} updated successfully");
        }

        [HttpDelete("{wardId}/rooms")]
        public IActionResult Deleteroom(int wardId)
        {

            return Ok($"Ward with ID {wardId} deleted successfully");
        }


        // Equipment Information


        [HttpGet("{roomId}/equipment")]
        public async Task<ActionResult<List<EquipmentType>>> Getequipment()
        {
            if (Facility.Count == null)
            {
                return BadRequest();
            }
            return Ok(Facility.ToList());

        }

        [HttpPost("{roomId}/equipment")]
        public IActionResult AddEquipment(int roomId, [FromBody] EquipmentType equipment)
        {
            try
            {
                _context.EquipmentTypes.Add(equipment);
                var response = _context.SaveChanges();
                return CreatedAtAction(nameof(Getequipment), new { id = equipment.Equipment }, equipment);
              
            }
            catch (Exception ex)
            {
                return null;
            }
            return Ok($"Equipment added to room {roomId} successfully");
        }
        [HttpPut("{roomId}/equipment")]
        public IActionResult UpdateEquipment(int wardId, [FromBody] EyeWard ward)
        {
            var existingWard = Facility.FirstOrDefault(w => w.Ward == wardId);
            if (existingWard == null)
            {
                return NotFound($"Ward with ID {wardId} not found");
            }

            existingWard.Room = ward.Room;
            existingWard.Staff = ward.Staff;
            existingWard.Equipment = ward.Equipment;

            return Ok($"Ward with ID {wardId} updated successfully");
        }

        [HttpDelete("{roomId}/equipment")]
        public IActionResult DeleteEquipment(int wardId)
        {

            return Ok($"Ward with ID {wardId} deleted successfully");
        }


        //Staff Information 
        //Get

        [HttpGet("{roomId}/StaffMember")]
        public async Task<ActionResult<List<StaffMember>>> Getstaff()
        {
            if (Facility.Count == null)
            {
                return BadRequest();
            }
            return Ok(Facility.ToList());

        }

        [HttpPost("{wardId}/StaffMember")]
        public IActionResult AddStaff([FromBody] StaffMember staff)
        {
            try
            {
                _context.StaffMembers.Add(staff);
                var response = _context.SaveChanges();
                return CreatedAtAction(nameof(Getstaff), new { id = staff.Staff }, staff);
             
            }
            catch (Exception ex)
            {
                return null;
            }

            return Ok("Staff member added successfully");
        }

        //Put

        [HttpPut("{wardId}/Facility")]
        public IActionResult UpdateStaff(int wardId, [FromBody] EyeWard ward)
        {
            var existingWard = Facility.FirstOrDefault(w => w.Ward == wardId);
            if (existingWard == null)
            {
                return NotFound($"Ward with ID {wardId} not found");
            }

            existingWard.Room = ward.Room;
            existingWard.Staff = ward.Staff;
            existingWard.Equipment = ward.Equipment;

            return Ok($"Ward with ID {wardId} updated successfully");
        }
        //Delete

        [HttpDelete("{wardId}/Facility")]
        public IActionResult DeleteStaff(int wardId)
        {

            return Ok($"Ward with ID {wardId} deleted successfully");
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
