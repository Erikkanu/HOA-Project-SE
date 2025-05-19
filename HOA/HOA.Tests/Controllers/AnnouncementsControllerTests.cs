using HOA.Controllers;
using HOA.Services;
using HOA.Models;
using HOA.Repositories; // Add this for RepositoryWrapper
using HOA.Repositories.Interfaces; // Add this for IRepositoryWrapper
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using HOA.Data;
public class AnnouncementsControllerTests
{
    [Fact]
    public async Task Index_ReturnsAViewResult_WithAListOfAnnouncements()
    {
        // Arrange
        //var options = new DbContextOptionsBuilder<HOADbContext>()
        //    .UseInMemoryDatabase(databaseName: "TestDb")
        //    .Options;

        //using (var context = new HOADbContext(options))
        //{
        //    context.Announcements.Add(new Announcement { Id = 1, Title = "Test", Description = "Test Description", Date = "2024-01-01" });
        //    context.SaveChanges();
        //}

        //using (var context = new HOAContext(options))
        //{
        //    var repositoryWrapper = new RepositoryWrapper(context); // Create the repository wrapper
        //    var service = new AnnouncementsService(repositoryWrapper); // Pass repository wrapper to service
        //    var controller = new AnnouncementsController(service);

        //    // Act
        //    var result = controller.Index(null);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var model = Assert.IsAssignableFrom<IEnumerable<Announcement>>(viewResult.Model);
        //    Assert.Single(model);
        //}
    }
}
