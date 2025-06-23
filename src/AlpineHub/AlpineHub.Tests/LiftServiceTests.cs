using AlpineHub.Core.Services;
using AlpineHub.Core.ViewModels.Lift;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using MockQueryable;
using Moq;

namespace AlpineHub.Tests.Services
{
    [TestFixture]
    public class LiftServiceTests
    {
        private Mock<IRepo> mockRepo;
        private LiftService liftService;
        private Lift lift1;
        private Lift lift2;
        private LiftType LiftType;
        private const string InvalidId = "000000000000000";

        [SetUp]
        public void Setup()
        {
            LiftType = new()
            {
                Id = Guid.Parse("BF82F17A-87E7-4A67-87A7-0864DF814C8B"),
                Name = "Test"
            };

            mockRepo = new Mock<IRepo>();
            liftService = new LiftService(mockRepo.Object);
            lift1 = new Lift()
            {
                Id = Guid.NewGuid(),
                Name = "Lift1",
                LiftType = LiftType
            };
            lift2 = new Lift()
            {
                Id = Guid.NewGuid(),
                Name = "Lift2",
                LiftType = LiftType
            };
            mockRepo.Setup(r => r.GetAllReadonly<Lift>()).Returns(new List<Lift> { lift1, lift2 }.AsQueryable().BuildMock());
            mockRepo.Setup(r => r.GetByIdAsync<Lift>(lift1.Id).Result).Returns(lift1);
            mockRepo.Setup(r => r.GetByIdAsync<Lift>(lift2.Id).Result).Returns(lift2);
            mockRepo.Setup(r => r.GetByIdAsync<LiftType>(LiftType.Id).Result).Returns(LiftType);
        }

        [Test]
        public async Task GetAllLiftsDetailsAsync_ShouldReturnAllLifts()
        {

            // Act
            var result = await liftService.GetAllLiftsDetailsAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Name, Is.EqualTo("Lift1"));
        }

        [Test]
        public async Task GetTotalNumberOfLiftsAsync_ShouldReturnTotalNumberOfLifts()
        {
            // Act
            var result = await liftService.GetTotalNumberOfLiftsAsync();

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }
        
        [Test]
        public async Task LiftExistsByIdAsync_ShouldReturnTrue_WhenLiftExists()
        {
            // Act
            var result = await liftService.LiftExistsByIdAsync(lift1.Id);

            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        [TestCase(null)]
        [TestCase("hui")]
        [TestCase(" ")]
        [TestCase(InvalidId)]

        public void GetLiftById_ShouldThrowException_IfIdIsInvalid(string? id)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await liftService.GetLiftByIdAsync(id));
        }
        [Test]
        public void GetAllLifts_ShouldReturnAllLifts()
        {
            var result = liftService.GetAllLiftsAsync().Result;
            Assert.That(result.Count(), Is.EqualTo(2));
        }
        
        [Test]
        [TestCase(null)]
        [TestCase("hui")]
        [TestCase(" ")]
        [TestCase(InvalidId)]
        public void GetLiftForEdit_ShouldThrowException_IfIdIsInvalid(string? id)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await liftService.GetLiftForEditAsync(id));
        }

        
        [Test]
        [TestCase(null)]
        [TestCase("hui")]
        [TestCase(" ")]
        [TestCase(InvalidId)]
        public void EditLiftAsync_ShouldThrowException_IfIdIsInvalid(string? id)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await liftService.EditLiftAsync(new EditLiftFormModel()
            {
                Id = id,
                Name = "Lift5"
            }));
        }
       

        [Test]
        [TestCase(null)]
        [TestCase("hui")]
        [TestCase(" ")]
        [TestCase(InvalidId)]
        public void GetLiftForDelete_ShouldThrowException_IfIdIsInvalid(string? id)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await liftService.GetLiftForDeleteAsync(id));
        }

        

        [Test]
        [TestCase(null)]
        [TestCase("hui")]
        [TestCase(" ")]
        [TestCase(InvalidId)]
        public void DeleteLiftAsync_ShouldThrowException_IfIdIsInvalid(string? id)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await liftService.DeleteLiftAsync(new DeleteLiftViewModel() { Id = id }));
        }

        [Test]
        public void AddLift_ShouldAddLift()
        {
            liftService.AddLiftAsync(new AddLiftFormModel()
            {
                Name = "Lift5",
                LiftTypeId = LiftType.Id.ToString()
            }).Wait();

            mockRepo.Verify(r => r.AddAsync<Lift>(It.Is<Lift>(l => l.Name == "Lift5")), Times.Once);
        }
        [Test]
        [TestCase(null)]
        [TestCase("hui")]
        [TestCase(" ")]
        [TestCase(InvalidId)]
        public void AddLift_ShouldThrowException_IfTypeIdIsInvalid(string? id)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await liftService.AddLiftAsync(new AddLiftFormModel()
            {
                Name = "Lift5",
                LiftTypeId = id
            }));
        }

        [Test]
        public void GetAllLiftsForMap_ShouldReturnAllLiftsForMap()
        {
            var result = liftService.GetAllLiftsForMapAsync().Result;
            Assert.That(result.Count(), Is.EqualTo(2));
        }
    }
}
