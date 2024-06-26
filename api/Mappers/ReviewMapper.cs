using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Review;
using api.Models;

namespace api.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewDto ToReviewDto(this Review review)
        {
            return new ReviewDto
            {
                Id = review.Id,
                UserId = review.UserId,
                ServiceId = review.ServiceId,
                Rating = review.Rating,
                Comment = review.Comment,
                DateTime = review.DateTime
            };
        }

        public static Review ToReviewFromCreateDto(this CreateReviewDto createDto)
        {
            return new Review
            {
                UserId = createDto.UserId,
                ServiceId = createDto.ServiceId,
                Rating = createDto.Rating,
                Comment = createDto.Comment,
                DateTime = createDto.DateTime
            };
        }

        public static Review ToReviewFromUpdateDto(this UpdateReviewDto updateDto)
        {
            return new Review
            {
                UserId = updateDto.UserId,
                ServiceId = updateDto.ServiceId,
                Rating = updateDto.Rating,
                Comment = updateDto.Comment,
                DateTime = updateDto.DateTime
            };
        }
    }
}
