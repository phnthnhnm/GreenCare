using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Review;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsRepository _reviewsRepo;
        private readonly IAccountsRepository _accountsRepo;

        public ReviewsController(IReviewsRepository reviewsRepo, IAccountsRepository accountsRepo)
        {
            _reviewsRepo = reviewsRepo;
            _accountsRepo = accountsRepo;
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

        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetReviewsByUser()
        {
            var userEmail = User.GetUserEmail();
            var user = await _accountsRepo.GetUserByEmailAsync(userEmail);
            if (user == null)
            {
                return NotFound();
            }

            var reviews = await _reviewsRepo.GetReviewsByUserAsync(user);
            var reviewDtos = reviews.Select(review => review.ToReviewDto());
            return Ok(reviewDtos);
        }

        [HttpGet("user/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetReviewsByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userIdGuid))
            {
                ModelState.AddModelError("userId", "Invalid user ID format.");
                return BadRequest(ModelState);
            }

            var user = await _accountsRepo.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            var reviews = await _reviewsRepo.GetReviewsByUserIdAsync(userId);
            var reviewDtos = reviews.Select(review => review.ToReviewDto());
            return Ok(reviewDtos);
        }
    }
}
