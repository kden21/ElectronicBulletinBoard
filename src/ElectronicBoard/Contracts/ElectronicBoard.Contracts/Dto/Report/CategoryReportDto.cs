namespace ElectronicBoard.Contracts.Dto.Report;

public class CategoryReportDto
{
    /// <summary>
    /// Идентификатор категории жалоб.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Наименование категории жалобы.
    /// </summary>
    public string Name { get; set; }
}