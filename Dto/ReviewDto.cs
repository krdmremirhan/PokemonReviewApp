using WebApplication8.Models;

namespace WebApplication8.Dto;

public class ReviewDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; }

    // public virtual Reviewer Reviewer { get; set; }
    // public virtual Pokemon Pokemon { get; set; }
}