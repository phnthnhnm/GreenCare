using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Review;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly GreenCareDbContext _context;

        public ReviewsRepository(GreenCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<Review> CreateAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review?> UpdateAsync(int id, UpdateReviewDto updateDto)
        {
            var existingReview = await _context.Reviews.FindAsync(id);
            if (existingReview == null)
            {
                return null;
            }

            existingReview.UserId = updateDto.UserId;
            existingReview.ServiceId = updateDto.ServiceId;
            existingReview.Rating = updateDto.Rating;
            existingReview.Comment = updateDto.Comment;
            existingReview.DateTime = updateDto.DateTime;

            await _context.SaveChangesAsync();
            return existingReview;
        }

        public async Task<Review?> DeleteAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return null;
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return review;
        }
    }
}
