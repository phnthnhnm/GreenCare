using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Review;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsRepository _reviewsRepo;

        public ReviewsController(IReviewsRepository reviewsRepo)
        {
            _reviewsRepo = reviewsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewsRepo.GetAllAsync();
            var reviewDtos = reviews.Select(review => review.ToReviewDto());
            return Ok(reviewDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _reviewsRepo.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review.ToReviewDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReviewDto createDto)
        {
            var review = createDto.ToReviewFromCreateDto();
            var createdReview = await _reviewsRepo.CreateAsync(review);
            return CreatedAtAction(nameof(GetById), new { id = createdReview.Id }, createdReview.ToReviewDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateReviewDto updateDto)
        {
            var updatedReview = await _reviewsRepo.UpdateAsync(id, updateDto);
            if (updatedReview == null)
            {
                return NotFound();
            }

            return Ok(updatedReview.ToReviewDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedReview = await _reviewsRepo.DeleteAsync(id);
            if (deletedReview == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
