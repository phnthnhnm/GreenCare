using System;
using System.Collections.Generic;

namespace GreenCare.API.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ServiceId { get; set; }

    public int ExpertId { get; set; }

    public DateTime AppointmentDateTime { get; set; }

    public string Status { get; set; } = null!;

    public virtual Account Customer { get; set; } = null!;

    public virtual Account Expert { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<PlantCareLog> PlantCareLogs { get; set; } = new List<PlantCareLog>();

    public virtual Service Service { get; set; } = null!;
}
