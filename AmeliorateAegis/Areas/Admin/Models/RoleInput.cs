using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Admin.Models
{
    public class RoleInput
    {

        [Required]
        public string Name { get; set; }

    }
}
