﻿using HospitalAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HospitalAPI.Classes
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base()
        {

        }
        public DbSet<Doctors> Doctors { get; set; }
    }
}
