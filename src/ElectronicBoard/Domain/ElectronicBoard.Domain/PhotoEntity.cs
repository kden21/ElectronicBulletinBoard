using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain;

public class PhotoEntity:Entity
{
    public byte[]? Photo { get; set; }
    public  int? AdvtId { get; set; }
    public AdvtEntity Advt { get; set; }
}