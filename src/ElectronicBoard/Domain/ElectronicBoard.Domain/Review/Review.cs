using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain;

public abstract class Review : Entity
{
    public string Description { get; set; }
    public double Rating { get; set; }
    public DateTime CreateDate { get; set; }
    //
    public int AuthorId { get; set; }
    public UserEntity Author { get; set; }
}