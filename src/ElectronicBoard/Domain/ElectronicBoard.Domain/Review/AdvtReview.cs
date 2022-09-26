namespace ElectronicBoard.Domain;

public class AdvtReview : Review
{
    //
    public int AdvtId { get; set; }
    public AdvtEntity Advt { get; set; }
}