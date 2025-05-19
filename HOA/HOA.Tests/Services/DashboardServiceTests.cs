using HOA.Models;
using HOA.Services;
using HOA.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class DashboardServiceTests
{
    [Fact]
    public void GetDashboardData_NoAnnouncements_ReturnsEmptyRecentAnnouncements()
    {
        // Arrange
        var mockRepoWrapper = new Mock<IRepositoryWrapper>();
        mockRepoWrapper.Setup(r => r.ResidentsRepository.FindAll()).Returns(new List<Resident>().AsQueryable());
        mockRepoWrapper.Setup(r => r.PaymentsRepository.FindByCondition(It.IsAny<System.Linq.Expressions.Expression<System.Func<Payment, bool>>>()))
            .Returns(new List<Payment>().AsQueryable());
        mockRepoWrapper.Setup(r => r.EventsRepository.FindAll()).Returns(new List<Event>().AsQueryable());
        mockRepoWrapper.Setup(r => r.AnnouncementsRepository.FindAll()).Returns(new List<Announcement>().AsQueryable());

        var service = new DashboardService(mockRepoWrapper.Object);

        // Act
        var dashboard = service.GetDashboardData();

        // Assert
        Assert.NotNull(dashboard);
        Assert.Empty(dashboard.RecentAnnouncements);
        Assert.Equal(0, dashboard.TotalResidents);
        Assert.Equal(0, dashboard.TotalDuePayments);
        Assert.Equal(0, dashboard.TotalEvents);
    }
}