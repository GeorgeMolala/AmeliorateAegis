using AmeliorateAegis.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models.ViewModels
{
    public class RoleViewModel
    {
        public ICollection<IdentityRole> Roles { get; set; } = new List<IdentityRole>();

        public RoleInput Input { get; set; }
    }
}
