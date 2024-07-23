using HospitalAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HospitalAPI.Classes
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<EyeWard> Wards { get; set; }
        public DbSet<RoomModel> Room { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
    }
}
