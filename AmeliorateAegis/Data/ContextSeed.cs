using AmeliorateAegis.Models;
using AmeliorateAegis.Models.Liason;
using AmeliorateAegis.Models.Manager;
using AmeliorateAegis.Models.Parents;
using AmeliorateAegis.Models.Regionals;
using AmeliorateAegis.Models.Teachers;
using AmeliorateAegis.Utility;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(SD.SuperAdmin));
            await roleManager.CreateAsync(new IdentityRole(SD.ProvincialLiason));
            await roleManager.CreateAsync(new IdentityRole(SD.RegionalManager));
            await roleManager.CreateAsync(new IdentityRole(SD.Teacher));
            await roleManager.CreateAsync(new IdentityRole(SD.Parent));
            await roleManager.CreateAsync(new IdentityRole(SD.RegionalCoordinator));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "admin@ameliorate.com",
                Email = "admin@ameliorate.com",
                FirstName = "Super",
                LastName = "Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password@1");
                    await userManager.AddToRoleAsync(defaultUser, SD.SuperAdmin);
                }
            }
        }

        public static async Task SeedParentAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new Parent
            {
                UserName = "parent@ameliorate.com",
                Email = "parent@ameliorate.com",
                FirstName = "Parent",
                LastName = "Ameliorate",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password@1");
                    await userManager.AddToRoleAsync(defaultUser, SD.Parent);
                }

            }
        }

        public static async Task SeedTeacherAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new Teacher
            {
                UserName = "teacher@ameliorate.com",
                Email = "teacher@ameliorate.com",
                FirstName = "Teacher",
                LastName = "Ameliorate",
                Qualification = "Bachelor Of Education",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password@1");
                    await userManager.AddToRoleAsync(defaultUser, SD.Teacher);
                }

            }
        }

        public static async Task SeedLiasonAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ProvincialLiason
            {
                UserName = "liason@ameliorate.com",
                Email = "liason@ameliorate.com",
                FirstName = "Provincial",
                LastName = "Liason",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password@1");
                    await userManager.AddToRoleAsync(defaultUser, SD.ProvincialLiason);
                }
            }
        }

        public static async Task SeedManagerAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new Manager
            {
                UserName = "manager@ameliorate.com",
                Email = "manager@ameliorate.com",
                FirstName = "Manager",
                LastName = "Ameliorate",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password@1");
                    await userManager.AddToRoleAsync(defaultUser, SD.RegionalManager);
                }
            }
        }
        public static async Task SeedCoordinatorAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new RegionalCoordinator
            {
                UserName = "coordinator@ameliorate.com",
                Email = "coordinator@ameliorate.com",
                FirstName = "Regional",
                LastName = "Coordinator",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password@1");
                    await userManager.AddToRoleAsync(defaultUser, SD.RegionalCoordinator);
                }
            }
        }
    }
}
