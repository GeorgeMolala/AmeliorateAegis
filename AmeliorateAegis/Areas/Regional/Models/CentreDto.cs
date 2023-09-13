using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Regional.Models
{
    public class CentreDto
    {
        public long CentreId { get; set; }
        public string CentreCode { get; set; }
        public string CentreName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
