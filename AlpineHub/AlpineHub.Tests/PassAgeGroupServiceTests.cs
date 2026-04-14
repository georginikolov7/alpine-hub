using AlpineHub.Core.Services;
using AlpineHub.Core.ViewModels.PassAgeGroup;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using MockQueryable;
using Moq;

namespace AlpineHub.Tests
{
    public class PassAgeGroupServiceTests
    {
        private Mock<IRepo> mockRepo;
        private PassAgeGroup group1;
        private PassAgeGroup group2;
        private PassAgeGroupService service;
        private const string invalidGuid = "B58EECF6-B3A2-4886-AFFE-B6D880DB7949";

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IRepo>();
            service = new PassAgeGroupService(mockRepo.Object);
            // Arrange
            group1 = new PassAgeGroup
            {
                Id = Guid.Parse("69296451-3AAC-4A6B-B5A4-516785BE1554"),
                Name = "Group1",
                MinAge = 10,
                MaxAge = 20
            };
            group2 = new PassAgeGroup
            {
                Id = Guid.Parse("79296451-3AAC-4A6B-B5A4-516785BE1554"),
                Name = "Group2",
                MinAge = 21,
                MaxAge = 30
            };
            mockRepo.Setup(r => r.GetAllReadonly<PassAgeGroup>())
                .Returns(new List<PassAgeGroup> { group1, group2 }.AsQueryable().BuildMock());
            mockRepo.Setup(r => r.GetByIdAsync<PassAgeGroup>(group1.Id)).ReturnsAsync(group1);
            mockRepo.Setup(r => r.GetByIdAsync<PassAgeGroup>(group2.Id)).ReturnsAsync(group2);
        }
        [Test]
        public async Task GetAllAgeGroupsAsync_ShouldReturnAllAgeGroups()
        {


            // Act
            var result = await service.GetAllAgeGroupsAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Name, Is.EqualTo(group1.Name));
            Assert.That(result.Last().Name, Is.EqualTo(group2.Name));
        }
        [Test]
        public async Task AddAgeGroupAsync_ShouldAddAgeGroup()
        {
            // Arrange
            var model = new AddAgeGroupFormModel
            {
                Name = "Group3",
                MinAge = 31,
                MaxAge = 40
            };

            // Act
            await service.AddAgeGroupAsync(model);

            // Assert
            mockRepo.Verify(r => r.AddAsync(It.Is<PassAgeGroup>(ag =>
                ag.Name == model.Name &&
                ag.MinAge == model.MinAge &&
                ag.MaxAge == model.MaxAge)), Times.Once);
            mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteAgeGroupAsync_ShouldDeleteAgeGroup()
        {
            // Arrange
            var model = new DeleteAgeGroupViewModel
            {
                Id = group1.Id.ToString()
            };

            // Act
            await service.DeleteAgeGroupAsync(model);

            // Assert
            mockRepo.Verify(r => r.Delete(It.Is<PassAgeGroup>(ag => ag.Id == group1.Id)), Times.Once);
            mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
        [Test]
        public async Task EditAgeGroup_ShouldEditAgeGroup()
        {
            // Arrange
            var model = new EditAgeGroupFormModel
            {
                Id = group1.Id.ToString(),
                Name = "Group1Edited",
                MinAge = 5,
                MaxAge = 15
            };

            // Act
            await service.EditAgeGroup(model);

            // Assert
            mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.That(group1.Name, Is.EqualTo(model.Name));
            Assert.That(group1.MinAge, Is.EqualTo(model.MinAge));
            Assert.That(group1.MaxAge, Is.EqualTo(model.MaxAge));
        }
        [Test]
        public async Task GetAgeGroupForDeleteAsync_ShouldReturnAgeGroup()
        {
            // Arrange
            var model = new DeleteAgeGroupViewModel
            {
                Id = group1.Id.ToString()
            };

            // Act
            var result = await service.GetAgeGroupForDeleteAsync(model.Id);

            // Assert
            Assert.That(result.Id, Is.EqualTo(group1.Id.ToString()));
            Assert.That(result.Name, Is.EqualTo(group1.Name));
        }
        [Test]
        public async Task GetAgeGroupForEditAsync_ShouldReturnAgeGroup()
        {
            // Arrange
            var model = new EditAgeGroupFormModel
            {
                Id = group1.Id.ToString()
            };

            // Act
            var result = await service.GetAgeGroupForEditAsync(model.Id);

            // Assert
            Assert.That(result.Id, Is.EqualTo(group1.Id.ToString()));
            Assert.That(result.Name, Is.EqualTo(group1.Name));
            Assert.That(result.MinAge, Is.EqualTo(group1.MinAge));
            Assert.That(result.MaxAge, Is.EqualTo(group1.MaxAge));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("invalid")]
        [TestCase(invalidGuid)]

        public void GetAgeGroupForEdit_ShouldThrowError_IfIdIsInvalid(string? id)
        {

            Assert.ThrowsAsync<ArgumentException>(async () => await service.GetAgeGroupForEditAsync(id));

        }

        [Test]
        public void EditAgeGroup_ShouldThrowError_IfAgeGroupNotFound()
        {
            // Arrange
            var model = new EditAgeGroupFormModel
            {
                Id = Guid.NewGuid().ToString()
            };

            // Act
            Assert.ThrowsAsync<ArgumentException>(async () => await service.EditAgeGroup(model));
        }
        [Test]
        public void Delete_ShouldThrowError_IfAgeGroupNotFound()
        {
            // Arrange
            var model = new DeleteAgeGroupViewModel
            {
                Id = Guid.NewGuid().ToString()
            };

            // Act
            Assert.ThrowsAsync<ArgumentException>(async () => await service.DeleteAgeGroupAsync(model));
        }
        [Test]
        public void GetAgeGroupForDelete_ShouldThrowError_IfAgeGroupNotFound()
        {
            // Arrange
            var model = new DeleteAgeGroupViewModel
            {
                Id = Guid.NewGuid().ToString()
            };

            // Act
            Assert.ThrowsAsync<ArgumentException>(async () => await service.GetAgeGroupForDeleteAsync(model.Id));
        }
    }
}
