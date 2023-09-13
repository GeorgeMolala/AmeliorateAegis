using System;
using System.Collections.Generic;
using System.Linq;
using AmeliorateAegis.Models.Tasks;

namespace AmeliorateAegis.Models.Regionals
{
    public class Manage
    {
        public int ManageID { get; set; }
        public string ManageDescr { get; set; }
        public int ReportID { get; set; }
        public int TaskID { get; set; }
        public int RegCodID { get; set; }
        public int? ProgramID { get; set; }

        public virtual Programme Program { get; set; }
        public virtual Report Report { get; set; }
        public virtual Task Task { get; set; }
    }
}
