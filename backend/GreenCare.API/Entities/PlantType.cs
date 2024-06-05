using System;
using System.Collections.Generic;

namespace GreenCare.API.Entities;

public partial class PlantType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
