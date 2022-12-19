using ElectronicBoard.Contracts.Advt.Dto;

namespace ElectronicBoard.Contracts.Advt.UpdateAdvt;

public class UpdateAdvtRequest
{
    public AdvtDto Advt { get; set; }
    public string[] Photos { get; set; }
    public int[] DeletePhotoIds { get; set; }
}