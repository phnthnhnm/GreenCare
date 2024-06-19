namespace GreenCare.API.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int AppointmentId { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public DateTime PaymentDateTime { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;
}
