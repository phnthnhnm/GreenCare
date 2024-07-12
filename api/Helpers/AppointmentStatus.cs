using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public enum AppointmentStatus
    {
        [Display(Name = "In Progress")]
        InProgress,
        [Display(Name = "Completed")]
        Completed,
        [Display(Name = "Cancelled")]
        Cancelled
    }
}
