using System;
using System.Collections.Generic;

namespace GreenCare.API.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Appointment> AppointmentCustomers { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentExperts { get; set; } = new List<Appointment>();

    public virtual ICollection<PlantCareLog> PlantCareLogs { get; set; } = new List<PlantCareLog>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
