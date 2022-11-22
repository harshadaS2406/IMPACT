using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerModule.Models
{
    public class VisitStatuses
    {
        [Key]
        public int VisitStatusId { get; set; }
        public string VisitStatusName { get; set; }
        //public string VisitStatusCode { get; set; }
    }
}
