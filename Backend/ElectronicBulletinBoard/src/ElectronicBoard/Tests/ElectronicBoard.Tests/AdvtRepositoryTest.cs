using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.DataAccess.Repositories;
using ElectronicBoard.Domain;
using MockQueryable.Moq;
using Moq;

namespace ElectronicBoard.Tests;

public class AdvtRepositoryTest
{
    [Fact]
    public async Task GetFilter_Advt_Success()
    {
        //arrange
        var entities = new List<AdvtEntity>(new[]
        {
            new AdvtEntity
            {
                Id = 1, Description = "первое", Name = "Advt", Price = 200, Status = 0,
                ModifyDate = DateTime.Today
            },
            new AdvtEntity
            {
            Id = 2, Description = "второе", Name = "Advt", Price = 200, Status = 0,
            ModifyDate = DateTime.Today
            },
            new AdvtEntity
            {
            Id = 2, Description = "третье", Name = "Объявление", Price = 200, Status = 0,
            ModifyDate = DateTime.Today
            }
        });

        var entitiesMock = entities.BuildMock();
        
        var repositoryMock = new Mock<IRepository<AdvtEntity>>();
        repositoryMock.Setup(x => x.GetAllEntities()).Returns(entitiesMock);
        
        //act
        CancellationToken tocken = new CancellationToken(false);
        AdvtFilterRequest filter = new AdvtFilterRequest {Description = "Advt"};
        
        AdvtRepository repository = new AdvtRepository(repositoryMock.Object);
        var result = await repository.GetFilterAdvtEntities(filter, tocken);
        
        //assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        foreach (var res in result)
        {
            Assert.Equal("Advt", res.Name);
        }
    }
}