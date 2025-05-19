using HOA.Models;
using HOA.Services;
using HOA.Repositories.Interfaces;
using Moq;
using Xunit;
using System.Linq;

public class ResidentsServiceTests
{
    [Fact]
    public void GetResidentById_NonExistentId_ReturnsNull()
    {
        // Arrange
        var mockRepoWrapper = new Mock<IRepositoryWrapper>();
        mockRepoWrapper.Setup(r => r.ResidentsRepository.FindByCondition(It.IsAny<System.Linq.Expressions.Expression<System.Func<Resident, bool>>>()))
            .Returns(Enumerable.Empty<Resident>().AsQueryable());

        var service = new ResidentsService(mockRepoWrapper.Object);

        // Act
        var resident = service.GetResidentById(999); // 999 is a non-existent ID

        // Assert
        Assert.Null(resident);
    }
}
