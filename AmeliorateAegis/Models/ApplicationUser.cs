using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime? CreationTime { get; set; }

        [ForeignKey(nameof(CentreId))]
        public Centre Centre { get; set; }
        public long? CentreId { get; set; }

        [NotMapped]
        public bool IsSuperAdmin { get; set; }

        public ApplicationUser()
        {
            CreationTime = DateTime.Now;
        }
    }
}
