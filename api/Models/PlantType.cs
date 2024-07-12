using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class PlantType
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; } = string.Empty;

        public List<PlantTypeService> PlantTypeServices { get; set; } = new List<PlantTypeService>();
    }
}
