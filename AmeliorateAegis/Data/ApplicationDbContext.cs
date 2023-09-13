using AmeliorateAegis.Areas.Teacher.Data;
using AmeliorateAegis.Models;
using AmeliorateAegis.Models.Parents;
using AmeliorateAegis.Models.Teachers;
using AmeliorateAegis.Models.Visitors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AmeliorateAegis.Models.Applications;

namespace AmeliorateAegis.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LessonPlan> LessonPlans { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Centre> Centres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<ProgrammeCentre> ProgramCentre { get; set; }
        public DbSet<ProgrammeEnrollment> ProgramEnrollments { get; set; }
        public DbSet<ProgressReport> ProgressReports { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Regional> Regionals { get; set; }
        public DbSet<Financial> Financials { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Meeting> Meetings { get; set; }


        // Regional Coordinator
        public DbSet<Centre> Centre { get; set; }
        public DbSet<ScheduleVisit> ScheduleVisits { get; set; }


        // Parent
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
        public DbSet<AmeliorateAegis.Models.Applications.Application> Application { get; set; }
    }
}
