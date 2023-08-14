using WebApplication8.Models;

namespace WebApplication8.Interface;

public interface IReviewerRepository
{
    ICollection<Reviewer> GetReviewers();
    Reviewer GetReviewer(int reviewerId);
    ICollection<Review> GetReviewsByReviewer(int reviewerId);
    bool ReviewerExists(int reviewerId);
    bool CreateReviewer(Reviewer reviewer);
    bool UpdateReviewer(Reviewer reviewer);
    bool DeleteReviewer(Reviewer reviewer);
    bool Save();

}