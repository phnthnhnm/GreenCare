namespace GreenCare.API.Models
{
    public class PlantTypeService
    {
        public int PlantTypeId { get; set; }
        public PlantType PlantType { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
