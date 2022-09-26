using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain.Report;

public abstract class Report : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public bool Reviewed { get; set; }
    public string ReviewResult { get; set; }
    //
    public int AuthorId { get; set; }
    public UserEntity Author { get; set; }
}