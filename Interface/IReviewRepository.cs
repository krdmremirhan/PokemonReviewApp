using WebApplication8.Models;

namespace WebApplication8.Interface;

public interface IReviewRepository
{
    ICollection<Review> GetReviews();
    Review GetReview(int reviewId);
    ICollection<Review> GetReviewsOfPokemon(int pokeId);
    bool ReviewExists(int reviewId);
    bool CreateReview(Review review);
    bool UpdateReview(Review review);
    bool DeleteReviews(List<Review> reviews);
    bool DeleteReview(Review review);


    bool Save();
}