using System;
using System.Collections.Generic;

namespace GreenCare.API.Models;

public partial class Review
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ServiceId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public virtual Account Customer { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
