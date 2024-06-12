using System;
using System.Collections.Generic;

namespace GreenCare.API.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int PlantTypeId { get; set; }

    public int? ExpertId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Account? Expert { get; set; }

    public virtual PlantType PlantType { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
