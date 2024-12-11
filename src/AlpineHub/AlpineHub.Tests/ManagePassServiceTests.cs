using AlpineHub.Core.Services;
using AlpineHub.Core.ViewModels.Pass;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using MockQueryable;
using Moq;
using System.Linq;
using System.Text.RegularExpressions;

namespace AlpineHub.Tests
{
    public class ManagePassServiceTests
    {
        private Mock<IRepo> repoMock;
        private ManagePassService service;
        private PassAgeGroup group;
        private PassPeriod period;
        private Pass pass1;
        private Pass pass2;
        private const string invalidGuid = "B58EECF6-B3A2-4886-AFFE-B6D880DB7949";

        [SetUp]
        public void Setup()
        {
            group = new PassAgeGroup
            {
                Id = Guid.Parse("69296451-3AAC-4A6B-B5A4-516785BE1554"),
                Name = "Group1",
                MinAge = 10,
                MaxAge = 20
            };
            period = new()
            {
                Id = Guid.Parse("61636015-1A5F-486F-A632-1CFD3861F5BE"),
                Name = "Period1",
                ValidFromHour = new TimeOnly(8, 0, 0),
                ValidToHour = new TimeOnly(16, 0, 0),
                DaysCount = 5,
                Passes = new List<Pass>()


            };

            pass1 = new()
            {
                Id = Guid.Parse("61636015-1A5F-486F-A632-1CFD3861F5BE"),
                Name = "Pass1",
                Description = "Description1",
                Price = 10,
                PassPeriod = period,
                PassAgeGroup = group,
                IsDeleted = false
            };
            pass2 = new()
            {
                Id = Guid.Parse("61636015-1A5F-486F-A632-1CFD3861F5BF"),
                Name = "Pass2",
                Description = "Description2",
                Price = 20,
                PassPeriod = period,
                PassAgeGroup = group,
                IsDeleted = false
            };

            repoMock = new Mock<IRepo>();
            service = new ManagePassService(repoMock.Object);

            repoMock.Setup(s => s.GetByIdAsync<PassPeriod>(period.Id).Result).Returns(period);
            repoMock.Setup(s => s.GetByIdAsync<PassAgeGroup>(group.Id).Result).Returns(group);
            repoMock.Setup(s => s.GetByIdAsync<Pass>(pass1.Id).Result).Returns(pass1);
            repoMock.Setup(s => s.GetByIdAsync<Pass>(pass2.Id).Result).Returns(pass2);
            repoMock.Setup(s => s.GetAll<Pass>()).Returns(new List<Pass>() { pass1, pass2 }.AsQueryable().BuildMock());
            repoMock.Setup(s => s.GetAllReadonly<Pass>()).Returns(new List<Pass>() { pass1, pass2 }.AsQueryable().BuildMock());

        }
        [Test]
        public async Task GetAllPassesAsync_ShouldReturnAllPasses()
        {
            // Act
            var result = await service.GetAllPassesAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Name, Is.EqualTo(pass1.Name));
            Assert.That(result.Last().Name, Is.EqualTo(pass2.Name));
        }
        [Test]
        public async Task AddPassAsync_ShouldAddPass()
        {
            // Arrange
            var model = new AddPassFormModel
            {
                Name = "Pass3",
                Description = "Description3",
                Price = 30,
                PeriodId = period.Id.ToString(),
                AgeGroupId = group.Id.ToString()
            };

            // Act
            await service.AddPassAsync(model);

            // Assert
            repoMock.Verify(r => r.AddAsync(It.Is<Pass>(p =>
                p.Name == model.Name &&
                p.Description == model.Description &&
                p.Price == model.Price &&
                p.PassPeriod == period &&
                p.PassAgeGroup == group)), Times.Once);
            repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("invalidGuid")]
        [TestCase(invalidGuid)]

        public void AddPassAsync_ShouldThrowException_WhenInvalidPeriodId(string? periodId)
        {
            var model = new AddPassFormModel
            {
                Name = "Pass3",
                Description = "Description3",
                Price = 30,
                PeriodId = periodId,
                AgeGroupId = group.Id.ToString()
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await service.AddPassAsync(model));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("invalidGuid")]
        [TestCase(invalidGuid)]
        public void AddPassAsync_ShouldThrowException_WhenInvalidAgeGroupId(string? ageGroupId)
        {
            var model = new AddPassFormModel
            {
                Name = "Pass3",
                Description = "Description3",
                Price = 30,
                PeriodId = period.Id.ToString(),
                AgeGroupId = ageGroupId
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await service.AddPassAsync(model));
        }

        [Test]
        public async Task GetPassForEditAsync_ShouldReturnPassForEdit()
        {
            // Act
            var result = await service.GetPassForEditAsync(pass1.Id.ToString());

            // Assert
            Assert.That(result.Id, Is.EqualTo(pass1.Id.ToString()));
            Assert.That(result.Name, Is.EqualTo(pass1.Name));
            Assert.That(result.Description, Is.EqualTo(pass1.Description));
            Assert.That(result.PeriodId, Is.EqualTo(pass1.PassPeriod.Id.ToString()));
            Assert.That(result.AgeGroupId, Is.EqualTo(pass1.PassAgeGroup.Id.ToString()));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("invalidGuid")]
        [TestCase(invalidGuid)]

        public void GetPassForEditAsync_ShouldThrowException_WhenInvalidId(string? id)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await service.GetPassForEditAsync(id));
        }
        [Test]
        public void EditPassAsync_ShouldWork()
        {
            // Arrange
            var model = new EditPassFormModel
            {
                Id = pass1.Id.ToString(),
                Name = "Pass3",
                Description = "Description3",
                Price = 30,
                PeriodId = period.Id.ToString(),
                AgeGroupId = group.Id.ToString()
            };

            // Act
            service.EditPassAsync(model).Wait();

            // Assert
            repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.That(pass1.Name, Is.EqualTo(model.Name));
            Assert.That(pass1.Description, Is.EqualTo(model.Description));
            Assert.That(pass1.Price, Is.EqualTo(model.Price));
            Assert.That(pass1.PassPeriod.Id, Is.EqualTo(Guid.Parse(model.PeriodId)));
            Assert.That(pass1.PassAgeGroup.Id, Is.EqualTo(Guid.Parse(model.AgeGroupId)));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("invalidGuid")]
        [TestCase(invalidGuid)]
        public void EditPassAsync_ShouldThrowError_IfIdIsInvalid(string? id)
        {
            var model = new EditPassFormModel
            {
                Id = id,
                Name = "Pass3",
                Description = "Description3",
                Price = 30,
                PeriodId = period.Id.ToString(),
                AgeGroupId = group.Id.ToString()
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await service.EditPassAsync(model));

        }
        [Test]
        public async Task GetPassForDeleteAsync_ShouldReturnPassForDelete()
        {
            // Arrange
            var model = new DeletePassViewModel
            {
                Id = pass1.Id.ToString()
            };

            // Act
            var result = await service.GetPassForDeleteAsync(model.Id);

            // Assert
            Assert.That(result.Id, Is.EqualTo(pass1.Id.ToString()));
            Assert.That(result.Name, Is.EqualTo(pass1.Name));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("invalidGuid")]
        [TestCase(invalidGuid)]
        public void GetPassForDeleteAsync_ShouldThrowException_WhenInvalidId(string? id)
        {
            var model = new DeletePassViewModel
            {
                Id = id
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await service.GetPassForDeleteAsync(model.Id));
        }
        [Test]
        public void DeletePassAsync_ShouldWork()
        {
            // Arrange
            var model = new DeletePassViewModel
            {
                Id = pass1.Id.ToString()
            };

            // Act
            service.DeletePassAsync(model).Wait();

            // Assert
            repoMock.Verify(r => r.Delete(pass1), Times.Once);
            repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("invalidGuid")]
        [TestCase(invalidGuid)]
        public void DeletePassAsync_ShouldThrowError_IfIdIsInvalid(string? id)
        {
            var model = new DeletePassViewModel
            {
                Id = id
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await service.DeletePassAsync(model));
        }
    }
}
