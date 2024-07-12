using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public enum PaymentStatus
    {
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Completed")]
        Completed,
        [Display(Name = "Cancelled")]
        Cancelled
    }
}
