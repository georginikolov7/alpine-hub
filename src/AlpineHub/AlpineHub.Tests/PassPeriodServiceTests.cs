using AlpineHub.Core.Services;
using AlpineHub.Core.ViewModels.PassPeriod;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using MockQueryable;
using Moq;

namespace AlpineHub.Tests
{
    public class PassPeriodServiceTests
    {
        private Mock<IRepo> repoMock;
        private PassPeriodService passPeriodService;

        private PassPeriod passPeriod1;
        private PassPeriod passPeriod2;
        [SetUp]
        public void Setup()
        {
            repoMock = new Mock<IRepo>();
            passPeriodService = new PassPeriodService(repoMock.Object);

            passPeriod1 = new()
            {
                Id = Guid.Parse("61636015-1A5F-486F-A632-1CFD3861F5BE"),
                Name = "Period1",
                ValidFromHour = new TimeOnly(8, 0, 0),
                ValidToHour = new TimeOnly(16, 0, 0),
                DaysCount = 5,
                Passes = new List<Pass>()

            };
            passPeriod2 = new()
            {
                Id = Guid.Parse("61636015-1A5F-486F-A632-1CFD3861F5BF"),
                Name = "Period2",
                ValidFromHour = new TimeOnly(9, 0, 0),
                ValidToHour = new TimeOnly(17, 0, 0),
                DaysCount = 7,
                Passes = new List<Pass>()

            };

            repoMock.Setup(s => s.GetAllReadonly<PassPeriod>()).Returns(new List<PassPeriod>() { passPeriod1, passPeriod2 }.AsQueryable().BuildMock());
            repoMock.Setup(s => s.GetByIdAsync<PassPeriod>(passPeriod1.Id).Result).Returns(passPeriod1);
            repoMock.Setup(s => s.GetByIdAsync<PassPeriod>(passPeriod2.Id).Result).Returns(passPeriod2);
        }
        [Test]
        public async Task GetAllPeriods_ShouldReturnAllPeriods()
        {

            IEnumerable<PeriodViewModel> actualPeriods = await passPeriodService.GetAllPeriods();

            // Assert
            Assert.That(actualPeriods.Count(), Is.EqualTo(2));
        }
        [Test]
        public async Task AddPeriodAsync_ShouldAddPeriod()
        {
            // Arrange
            AddPeriodFormModel model = new()
            {
                Name = "Period3",

                DaysCount = 7
            };

            // Act
            await passPeriodService.AddPeriodAsync(model);

            // Assert
            repoMock.Verify(r => r.AddAsync(It.Is<PassPeriod>(p => p.Name == model.Name)), Times.Once);
            repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
        [Test]
        public async Task GetPeriodForEditAsync_ShouldReturnPeriod()
        {
            // Arrange
            string id = passPeriod1.Id.ToString();
            EditPeriodFormModel expectedModel = new()
            {
                Id = passPeriod1.Id.ToString(),
                Name = passPeriod1.Name,
                ValidFromHour = passPeriod1.ValidFromHour,
                ValidToHour = passPeriod1.ValidToHour,
                DaysCount = passPeriod1.DaysCount
            };

            // Act
            EditPeriodFormModel actualModel = await passPeriodService.GetPeriodForEditAsync(id);

            // Assert
            Assert.That(actualModel.Id, Is.EqualTo(expectedModel.Id));
            Assert.That(actualModel.Name, Is.EqualTo(expectedModel.Name));

        }
        [Test]
        public async Task EditPeriodAsync_ShouldEditPeriod()
        {
            // Arrange
            EditPeriodFormModel model = new()
            {
                Id = passPeriod1.Id.ToString(),
                Name = "Period3",
                ValidFromHour = new TimeOnly(8, 0, 0),
                ValidToHour = new TimeOnly(16, 0, 0),
                DaysCount = 5
            };

            // Act
            await passPeriodService.EditPeriodAsync(model);

            // Assert
            repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
        [Test]
        public async Task GetPeriodForDeleteAsync_ShouldReturnPeriod()
        {
            // Arrange
            string id = passPeriod1.Id.ToString();
            DeletePeriodViewModel expectedModel = new()
            {
                Id = passPeriod1.Id.ToString(),
                Name = passPeriod1.Name
            };

            // Act
            DeletePeriodViewModel actualModel = await passPeriodService.GetPeriodForDeleteAsync(id);

            // Assert
            Assert.That(actualModel.Id, Is.EqualTo(expectedModel.Id));
            Assert.That(actualModel.Name, Is.EqualTo(expectedModel.Name));
        }
        [Test]
        public async Task DeletePeriodAsync_ShouldDeletePeriod()
        {
            // Arrange
            DeletePeriodViewModel model = new()
            {
                Id = passPeriod1.Id.ToString(),
                Name = passPeriod1.Name
            };

            // Act
            await passPeriodService.DeletePeriodAsync(model);

            // Assert
            repoMock.Verify(r => r.Delete(It.Is<PassPeriod>(p => p.Id == passPeriod1.Id)), Times.Once);
            repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]

        public void GetPeriodForEditAsync_ShouldThrowException_WhenIdIsInvalid(string? id)
        {


            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async() => await passPeriodService.GetPeriodForEditAsync(id));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void EditPeriodAsync_ShouldThrowException_WhenIdIsInvalid(string? id)
        {
            // Arrange
            EditPeriodFormModel model = new()
            {
                Id = id,
                Name = "Period3",
                ValidFromHour = new TimeOnly(8, 0, 0),
                ValidToHour = new TimeOnly(16, 0, 0),
                DaysCount = 5
            };

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await passPeriodService.EditPeriodAsync(model));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetPeriodForDeleteAsync_ShouldThrowException_WhenIdIsInvalid(string? id)
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>( async()=> await passPeriodService.GetPeriodForDeleteAsync(id));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void DeletePeriodAsync_ShouldThrowException_WhenIdIsInvalid(string? id)
        {
            // Arrange
            DeletePeriodViewModel model = new()
            {
                Id = id,
                Name = "Period3"
            };

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await passPeriodService.DeletePeriodAsync(model));
        }
    }
}
