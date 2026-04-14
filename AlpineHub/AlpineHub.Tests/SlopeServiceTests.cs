using AlpineHub.Common.Enums;
using AlpineHub.Core.Contracts.Slope;
using AlpineHub.Core.Services;
using AlpineHub.Core.ViewModels.Slope;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using MockQueryable;
using Moq;

namespace AlpineHub.Tests
{
    public class SlopeServiceTests
    {
        private Mock<IRepo> repoMock;
        private SlopeService slopeService;
        private const string invalidGuid = "35F9DED6-3359-4B69-81CE-DB4C063775B5";
        private Slope slope1 = new Slope();
        private Slope slope2 = new Slope();
        private Slope slope3 = new Slope();
        private List<Slope> slopes = new List<Slope>();
        [SetUp]
        public void Setup()
        {
            repoMock = new Mock<IRepo>();
            slopeService = new SlopeService(repoMock.Object);
            slope1 = new()
            {
                Id = Guid.Parse("35F9DED6-3359-4B69-81CE-DB4C063775B4"),
                Name = "Test",
                Difficulty = SlopeDifficulty.Expert,
                SlopeCondition = SlopeCondition.Groomed,
                Length = 1000,
                IsOpen = true
            };
            slope2 = new()
            {
                Id = Guid.Parse("CFC97341-D6AD-49A8-8273-BDAA8F52C6DA"),
                Name = "Test2",
                Difficulty = SlopeDifficulty.Intermediate,
                SlopeCondition = SlopeCondition.Mogul,
                Length = 2000,
                IsOpen = false
            };
            slope3 = new()
            {
                Id = Guid.Parse("1C929207-67D7-4449-B834-25B9F0E02F57"),
                Name = "Test3",
                Difficulty = SlopeDifficulty.Hard,
                SlopeCondition = SlopeCondition.NotGroomed,
                Length = 3000,
                IsOpen = true
            };
            slopes = new List<Slope>() { slope1, slope2, slope3 };

            repoMock.Setup(s => s.GetAllReadonly<Slope>()).Returns(slopes.AsQueryable().BuildMock());
            repoMock.Setup(s => s.GetByIdAsync<Slope>(slope1.Id).Result).Returns(slope1);
            repoMock.Setup(s => s.GetByIdAsync<Slope>(slope2.Id).Result).Returns(slope2);
            repoMock.Setup(s => s.GetByIdAsync<Slope>(slope3.Id).Result).Returns(slope3);
        }

        [Test]
        public void GetAllSlopesAsync_ShouldReturnAllSlopes()
        {

            // Act
            var result = slopeService.GetAllSlopesAsync().Result;

            // Assert
            Assert.That(result.Count(), Is.EqualTo(3));
        }
        [Test]
        public void GetNumberOfOpenSlopesAsync_ShouldReturnNumberOfOpenSlopes()
        {

            // Act
            var result = slopeService.GetNumberOfOpenSlopesAsync().Result;

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }
        [Test]
        public void GetTotalNumberOfSlopesAsync_ShouldReturnTotalNumberOfSlopes()
        {


            // Act
            var result = slopeService.GetTotalNumberOfSlopesAsync().Result;

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        public void SlopeExistsByIdAsync_ShouldReturnTrue_WhenSlopeExists()
        {


            // Act
            var result = slopeService.SlopeExistsByIdAsync(slope1.Id).Result;

            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void SlopeExistsByIdAsync_ShouldReturnFalse_WhenSlopeDoesNotExist()
        {

            // Act
            var result = slopeService.SlopeExistsByIdAsync(Guid.NewGuid()).Result;

            // Assert
            Assert.IsFalse(result);
        }
        [Test]
        public void GetSlopeByIdAsync_ShouldReturnSlopeDetails_WhenSlopeExists()
        {

            // Act
            var result = slopeService.GetSlopeByIdAsync(slope1.Id.ToString()).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(slope1.Id.ToString()));
            Assert.That(result.Name, Is.EqualTo(slope1.Name));
            Assert.That(result.Difficulty, Is.EqualTo(slope1.Difficulty.ToString()));
            Assert.That(result.SlopeCondition, Is.EqualTo(slope1.SlopeCondition.ToString()));
            Assert.That(result.IsOpen, Is.EqualTo(slope1.IsOpen));
            Assert.That(result.Length, Is.EqualTo(slope1.Length));
        }
        [Test]
        public void GetSlopeByIdAsync_ShouldReturnNull_WhenSlopeDoesNotExist()
        {
            // Arrange
            ISlopeService slopeService = new SlopeService(repoMock.Object);

            // Act
            var result = slopeService.GetSlopeByIdAsync(Guid.NewGuid().ToString()).Result;

            // Assert
            Assert.IsNull(result);
        }
        [Test]
        public void GetSlopeByIdAsync_ShouldReturnNull_WhenSlopeIdIsInvalid()
        {

            // Act
            var result = slopeService.GetSlopeByIdAsync("hui").Result;

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetSlopeDetailsForMapAsync_ShouldReturnSlopeDetailsDto_WhenSlopeExists()
        {

            // Act
            var result = slopeService.GetSlopeDetailsForMapAsync(slope1.Id.ToString()).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Difficulty, Is.EqualTo(slope1.Difficulty.ToString()));
            Assert.That(result.Condition, Is.EqualTo(slope1.SlopeCondition.ToString()));
            Assert.That(result.IsOpen, Is.EqualTo(slope1.IsOpen));
            Assert.That(result.Length, Is.EqualTo(slope1.Length));
        }

        [Test]
        public void GetSlopeAsync_ShouldReturnSlope_WhenSlopeExists()
        {
            var result = slopeService.GetSlopeByIdAsync(slope1.Id.ToString()).Result;

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(slope1.Id.ToString()));
            Assert.That(result.Name, Is.EqualTo(slope1.Name));
            Assert.That(result.Difficulty, Is.EqualTo(slope1.Difficulty.ToString()));
            Assert.That(result.Length, Is.EqualTo(slope1.Length));
            Assert.That(result.UpperPointAltitude, Is.EqualTo(slope1.UpperPointAltitude));
            Assert.That(result.LowerPointAltitude, Is.EqualTo(slope1.LowerPointAltitude));
            Assert.That(result.IsOpen, Is.EqualTo(slope1.IsOpen));
            Assert.That(result.SlopeCondition, Is.EqualTo(slope1.SlopeCondition.ToString()));
        }
        [Test]
        [TestCase("hui")]
        [TestCase(null)]
        [TestCase(invalidGuid)]
        public void GetSlopeAsync_ShouldReturnNull_WhenSlopeIdIsInvalid(string? id)
        {
            var result = slopeService.GetSlopeByIdAsync(id).Result;

            Assert.IsNull(result);
        }
        [Test]
        public void GetSlopeForDeleteAsync_ShouldReturnDeleteSlopeViewModel_WhenSlopeExists()
        {
            var result = slopeService.GetSlopeForDeleteAsync(slope1.Id.ToString()).Result;

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(slope1.Id.ToString()));
            Assert.That(result.Name, Is.EqualTo(slope1.Name));
        }
        [Test]
        [TestCase("hui")]
        [TestCase(null)]
        [TestCase(invalidGuid)]

        public void GetSlopeForDeleteAsync_ShouldThrowException_WhenSlopeDoesNotExist(string? id)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await slopeService.GetSlopeForDeleteAsync(id));

        }
        [Test]
        public void DeleteSlopeAsync_ShouldDeleteSlope_WhenSlopeExists()
        {
            var result = slopeService.DeleteSlopeAsync(new DeleteSlopeViewModel() { Id = slope1.Id.ToString() });
            repoMock.Verify(repoMock => repoMock.Delete<Slope>(slope1), Times.Once);
        }
        [Test]
        [TestCase("hui")]
        [TestCase(null)]
        [TestCase(invalidGuid)]
        public void DeleteSlopeAsync_ShouldThrowException_WhenSlopeDoesNotExist(string? id)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await slopeService.DeleteSlopeAsync(new DeleteSlopeViewModel() { Id = id }));
        }
        [Test]
        public void EditSlopeAsync_ShouldEditSlope_WhenSlopeExists()
        {
            var model = new EditSlopeFormModel()
            {
                Id = slope1.Id.ToString(),
                Name = "Test2",
                Difficulty = SlopeDifficulty.Intermediate,
                SlopeCondition = SlopeCondition.Mogul,
                IsOpen = false,
                Length = 2000,
                UpperPointAltitude = 2000,
                LowerPointAltitude = 1000
            };
            var result = slopeService.EditSlopeAsync(model);
            repoMock.Verify(repoMock => repoMock.SaveChangesAsync(), Times.Once);
        }
        [Test]
        [TestCase("hui")]
        [TestCase(null)]
        [TestCase(invalidGuid)]
        public void EditSlopeAsync_ShouldThrowException_WhenSlopeDoesNotExist(string? id)
        {
            var model = new EditSlopeFormModel()
            {
                Id = id,
                Name = "Test2",
                Difficulty = SlopeDifficulty.Intermediate,
                SlopeCondition = SlopeCondition.Mogul,
                IsOpen = false,
                Length = 2000,
                UpperPointAltitude = 2000,
                LowerPointAltitude = 1000
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await slopeService.EditSlopeAsync(model));
        }

        [Test]
        public void GetSlopeForEdit_ShouldWorkProperly()
        {
            var result = slopeService.GetSlopeForEditAsync(slope1.Id.ToString()).Result;
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(slope1.Id.ToString()));
            Assert.That(result.Name, Is.EqualTo(slope1.Name));
            Assert.That(result.Difficulty, Is.EqualTo(slope1.Difficulty));
            Assert.That(result.SlopeCondition, Is.EqualTo(slope1.SlopeCondition));
            Assert.That(result.IsOpen, Is.EqualTo(slope1.IsOpen));
            Assert.That(result.Length, Is.EqualTo(slope1.Length));
            Assert.That(result.UpperPointAltitude, Is.EqualTo(slope1.UpperPointAltitude));
            Assert.That(result.LowerPointAltitude, Is.EqualTo(slope1.LowerPointAltitude));
        }
        [Test]
        [TestCase("hui")]
        [TestCase(null)]
        [TestCase(invalidGuid)]
        public void GetSlopeForEdit_ShouldThrowException_WhenSlopeDoesNotExist(string? id)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await slopeService.GetSlopeForEditAsync(id));
        }
        [Test]
        public void GetAllSlopesForMapAsync_ShouldWorkProperly()
        {
            var result = slopeService.GetAllSlopesForMapAsync().Result;
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(3));
        }
        [Test]
        public void GetAllManagerSlopesAsync_ShouldWorkProperly()
        {
            var result = slopeService.GetAllManagerSlopesAsync().Result;
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(3));
        }
    }
}