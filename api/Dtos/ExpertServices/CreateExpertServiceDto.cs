using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.ExpertServices
{
    public class CreateExpertServiceDto
    {
        public string ExpertId { get; set; }
        public int ServiceId { get; set; }
    }
}
