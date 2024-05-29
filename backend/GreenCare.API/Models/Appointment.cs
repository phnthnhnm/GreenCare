namespace GreenCare.API.Models
{
    public class Appointment
    {
        public int id { get; private set; }
        public int customerId { get; private set; }
        public int serviceId { get; private set; }
        public int expertId { get; private set; }
        public string appointmentDateTime { get; private set; }
        public string status { get; private set; }

        public Appointment(int id, int customerId, int serviceId, int expertId, string appointmentDateTime, string status)
        {
            this.id = id;
            this.customerId = customerId;
            this.serviceId = serviceId;
            this.expertId = expertId;
            this.appointmentDateTime = appointmentDateTime;
            this.status = status;
        }
    }
}
