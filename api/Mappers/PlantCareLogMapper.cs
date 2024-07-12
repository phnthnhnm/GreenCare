using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PlantCareLog;
using api.Models;

namespace api.Mappers
{
    public static class PlantCareLogMapper
    {
        public static PlantCareLogDto ToPlantCareLogDto(this PlantCareLog plantCareLog)
        {
            return new PlantCareLogDto
            {
                Id = plantCareLog.Id,
                ExpertId = plantCareLog.ExpertId,
                AppointmentId = plantCareLog.AppointmentId,
                Notes = plantCareLog.Notes,
                LogDate = plantCareLog.LogDate
            };
        }

        public static PlantCareLog ToPlantCareLogFromCreateDto(this CreatePlantCareLogDto createDto)
        {
            return new PlantCareLog
            {
                ExpertId = createDto.ExpertId,
                AppointmentId = createDto.AppointmentId,
                Notes = createDto.Notes,
                LogDate = createDto.LogDate
            };
        }

        public static PlantCareLog ToPlantCareLogFromUpdateDto(this UpdatePlantCareLogDto updateDto)
        {
            return new PlantCareLog
            {
                ExpertId = updateDto.ExpertId,
                AppointmentId = updateDto.AppointmentId,
                Notes = updateDto.Notes,
                LogDate = updateDto.LogDate
            };
        }
    }
}
