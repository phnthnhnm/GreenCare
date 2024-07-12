using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ExpertServices;
using api.Models;

namespace api.Mappers
{
    public static class ExpertServiceMapper
    {
        public static ExpertServiceDto ToExpertServiceDto(this ExpertService expertService)
        {
            return new ExpertServiceDto
            {
                ExpertId = expertService.ExpertId,
                ServiceId = expertService.ServiceId
            };
        }

        public static ExpertService ToExpertServiceFromCreateDto(this CreateExpertServiceDto createDto)
        {
            return new ExpertService
            {
                ExpertId = createDto.ExpertId,
                ServiceId = createDto.ServiceId
            };

        }
    }
}
