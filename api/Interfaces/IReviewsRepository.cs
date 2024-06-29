using api.Dtos.Review;
using api.Models;

namespace api.Interfaces
{
    public interface IReviewsRepository
    {
        Task<List<Review>> GetAllAsync();
        Task<Review?> GetByIdAsync(int id);
        Task<Review> CreateAsync(Review review);
        Task<Review?> UpdateAsync(int id, UpdateReviewDto reviewDto);
        Task<Review?> DeleteAsync(int id);
        Task<List<Review>> GetReviewsByUserAsync(ApplicationUser user);
        Task<List<Review>> GetReviewsByUserIdAsync(string userId);
    }
}
