using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models.ViewModels
{
    public class UserViewModel
    {
        public ICollection<UserRolesViewModel> Users { get; set; } = new List<UserRolesViewModel>();
        public RegisterInput Input { get; set; }
        public ICollection<string> Roles { get; set; } = new List<string>();
    }
}
