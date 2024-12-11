using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlpineHub.Core.Services;
using AlpineHub.Core.ViewModels.LiftType;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using MockQueryable;
using Moq;
using NUnit.Framework;

[TestFixture]
public class LiftTypeServiceTests
{
    private Mock<IRepo> _mockRepo;
    private LiftTypeService _service;

    [SetUp]
    public void Setup()
    {
        _mockRepo = new Mock<IRepo>();
        _service = new LiftTypeService(_mockRepo.Object);
    }

    [Test]
    public async Task GetAllLiftTypesAsync_ReturnsAllLiftTypes()
    {
        // Arrange
        var liftTypes = new List<LiftType>
        {
            new LiftType { Id = Guid.NewGuid(), Name = "Type A" },
            new LiftType { Id = Guid.NewGuid(), Name = "Type B" }
        };

        _mockRepo.Setup(r => r.GetAllReadonly<LiftType>())
                 .Returns(liftTypes.AsQueryable().BuildMock());

        // Act
        var result = await _service.GetAllLiftTypesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.AreEqual(2, result.Count());
        Assert.IsTrue(result.Any(lt => lt.Name == "Type A"));
        Assert.IsTrue(result.Any(lt => lt.Name == "Type B"));
    }

    [Test]
    public async Task AddLiftTypeAsync_AddsLiftType()
    {
        // Arrange
        var model = new AddLiftTypeFormModel { Name = "New Lift Type" };

        // Act
        await _service.AddLiftTypeAsync(model);

        // Assert
        _mockRepo.Verify(r => r.AddAsync(It.Is<LiftType>(lt => lt.Name == "New Lift Type")), Times.Once);
        _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public async Task GetLiftTypeForEditAsync_ReturnsLiftTypeForEdit()
    {
        // Arrange
        var id = Guid.NewGuid();
        var liftType = new LiftType { Id = id, Name = "Edit Lift Type" };

        _mockRepo.Setup(r => r.GetByIdAsync<LiftType>(id)).ReturnsAsync(liftType);

        // Act
        var result = await _service.GetLiftTypeForEditAsync(id.ToString());

        // Assert
        Assert.NotNull(result);
        Assert.AreEqual(id.ToString(), result.Id);
        Assert.AreEqual("Edit Lift Type", result.Name);
    }

    [Test]
    public void GetLiftTypeForEditAsync_InvalidId_ThrowsException()
    {
        // Arrange
        var invalidId = "invalid-guid";

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(async () => { await _service.GetLiftTypeForEditAsync(invalidId); });
    }

    [Test]
    public async Task EditLiftTypeAsync_UpdatesLiftType()
    {
        // Arrange
        var id = Guid.NewGuid();
        var liftType = new LiftType { Id = id, Name = "Old Name" };
        var model = new EditLiftTypeFormModel { Id = id.ToString(), Name = "Updated Name" };

        _mockRepo.Setup(r => r.GetByIdAsync<LiftType>(id)).ReturnsAsync(liftType);

        // Act
        await _service.EditLiftTypeAsync(model);

        // Assert
        Assert.AreEqual("Updated Name", liftType.Name);
        _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public void EditLiftTypeAsync_InvalidId_ThrowsException()
    {
        // Arrange
        var invalidId = "invalid-guid";
        var model = new EditLiftTypeFormModel { Id = invalidId, Name = "New Name" };

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(async () => { await _service.EditLiftTypeAsync(model); });
    }

    [Test]
    public async Task GetLiftTypeForDeleteAsync_ReturnsLiftTypeForDelete()
    {
        // Arrange
        var id = Guid.NewGuid();
        var liftType = new LiftType { Id = id, Name = "Delete Lift Type" };

        _mockRepo.Setup(r => r.GetByIdAsync<LiftType>(id)).ReturnsAsync(liftType);

        // Act
        var result = await _service.GetLiftTypeForDeleteAsync(id.ToString());

        // Assert
        Assert.NotNull(result);
        Assert.AreEqual(id.ToString(), result.Id);
        Assert.AreEqual("Delete Lift Type", result.Name);
    }

    [Test]
    public void GetLiftTypeForDeleteAsync_InvalidId_ThrowsException()
    {
        // Arrange
        var invalidId = "invalid-guid";

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(async () => await _service.GetLiftTypeForDeleteAsync(invalidId));
    }

    [Test]
    public async Task DeleteLiftTypeAsync_DeletesLiftType()
    {
        // Arrange
        var id = Guid.NewGuid();
        var model = new DeleteLiftTypeViewModel { Id = id.ToString(), Name = "Delete Lift Type" };

        // Act
        await _service.DeleteLiftTypeAsync(model);

        // Assert
        _mockRepo.Verify(r => r.DeleteByIdAsync<LiftType>(id), Times.Once);
        _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public void DeleteLiftTypeAsync_InvalidId_ThrowsException()
    {
        // Arrange
        var invalidId = "invalid-guid";
        var model = new DeleteLiftTypeViewModel { Id = invalidId, Name = "Invalid Type" };

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(async () => { await _service.DeleteLiftTypeAsync(model); });
    }

}
