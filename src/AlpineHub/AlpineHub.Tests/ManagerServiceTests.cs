using AlpineHub.Core.Contracts;
using AlpineHub.Core.Services;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using Microsoft.AspNetCore.Identity;
using MockQueryable;
using Moq;
using System.Security.Claims;
using static AlpineHub.Data.Constants.CustomClaims;

namespace AlpineHub.Tests
{
    public class Tests
    {
        private Mock<IRepo> repoMock;
        private Mock<UserManager<ApplicationUser>> userManagerMock;
        private IManagerService managerService;

        private Guid manager1Id = Guid.NewGuid();
        private Guid manager2Id = Guid.NewGuid();
        private ApplicationUser user1;
        private Guid user1Id = Guid.NewGuid();
        private Guid user2Id = Guid.NewGuid();
        private Guid user3Id = Guid.NewGuid();

        private ApplicationUser notManagerUser;
        private ResortManager manager1;
        private ResortManager manager2;
        private List<ResortManager> managers;
        [SetUp]
        public void Setup()
        {
            repoMock = new Mock<IRepo>();
            userManagerMock = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(),
                null, null, null, null, null, null, null, null);

            managerService = new ManagerService(repoMock.Object, userManagerMock.Object);

            notManagerUser = new()
            {
                Id = user3Id,
                FirstName = "NotManager",
                LastName = "NotManager"
               ,
                Email = "test@mail.com"
               ,
                UserName = "notmanager"
            };
            manager1 = new ResortManager()
            {
                Id = manager1Id,
                ApplicationUserId = user1Id
            };

            manager2 = new ResortManager()
            {
                Id = manager2Id,
                ApplicationUserId = user2Id
            };

            user1 = new() { Id = user1Id };

            managers = new List<ResortManager> { manager1, manager2 };
            userManagerMock.Setup(u => u.FindByIdAsync(user1Id.ToString()).Result).Returns(notManagerUser);
            repoMock.Setup(r => r.GetByIdAsync<ResortManager>(manager1Id).Result).Returns(manager1);
            repoMock.Setup(r => r.GetByIdAsync<ResortManager>(manager2Id).Result).Returns(manager2);
            repoMock.Setup(r => r.GetAllReadonly<ResortManager>()).Returns(managers.AsQueryable().BuildMock());
            repoMock.Setup(r => r.GetAll<ResortManager>()).Returns(managers.AsQueryable().BuildMock());
        }
        [Test]
        public void IsManagerIdValid_ShouldWorkProperly()
        {
            // Arrange
            string managerId = manager1Id.ToString();

            // Act
            bool result = managerService.IsManagerIdValid(managerId, user1Id.ToString()).Result;
            Assert.IsTrue(result);
        }
        [Test]
        [TestCase(null)]
        [TestCase("hui")]
        [TestCase(" ")]

        public void IsManagerIdValid_ShouldReturnFalse_WhenManagerIdIsInvalid(string? managerId)
        {
            var result = managerService.IsManagerIdValid(managerId, user1Id.ToString()).Result;
            Assert.IsFalse(result);
        }
        [Test]
        [TestCase(null)]
        [TestCase("hui")]
        [TestCase(" ")]

        public void IsManagerIdValid_ShouldReturnFalse_WhenUserIdIsInvalid(string? userId)
        {

            var result = managerService.IsManagerIdValid(manager1Id.ToString(), userId).Result;
            Assert.IsFalse(result);
        }
        [Test]
        public void IsManagerIdValid_ShouldReturnFalse_WhenManagerIsNotFound()
        {
            var result = managerService.IsManagerIdValid(Guid.NewGuid().ToString(), user1Id.ToString()).Result;
            Assert.IsFalse(result);
        }
        [Test]
        public void IsManagerIdValid_ShouldReturnFalse_WhenManagerIsNotTheUser()
        {
            var result = managerService.IsManagerIdValid(manager1Id.ToString(), user2Id.ToString()).Result;
            Assert.IsFalse(result);
        }
        [Test]
        public void IsUserManager_ShouldReturnTrue_WhenUserIsManager()
        {
            var result = managerService.IsUserManager(user1Id.ToString()).Result;
            Assert.IsTrue(result);
        }
        [Test]
        public void IsUserManager_ShouldReturnFalse_WhenUserIsNotManager()
        {
            var result = managerService.IsUserManager(user3Id.ToString()).Result;
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("hui")]
        [TestCase(null)]
        [TestCase(" ")]
        public void IsUserManager_ShouldReturnFalse_WhenUserIdIsInvalid(string? id)
        {
            var result = managerService.IsUserManager(id).Result;
            Assert.IsFalse(result);
        }
        [Test]
        public void MakeUserManager_ShouldWorkProperly()
        {
            var user = new ApplicationUser()
            {
                Id = Guid.NewGuid()
            };

            managerService.MakeUserManager(user).Wait();
            repoMock.Verify(r => r.AddAsync<ResortManager>(It.Is<ResortManager>(m => m.ApplicationUserId == user.Id)), Times.Once);
            repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            userManagerMock.Verify(u => u.AddClaimAsync(user, It.Is<Claim>(c => c.Type == ManagerIdClaim)), Times.Once);
        }

        [Test]
        public void RemoveManager_ShouldWorkProperly()
        {
            managerService.RemoveManager(user1).Wait();
            repoMock.Verify(r => r.Delete(It.Is<ResortManager>(m => m.ApplicationUserId == user1Id)), Times.Once);
            repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            userManagerMock.Verify(u => u.RemoveClaimAsync(user1, It.Is<Claim>(c => c.Type == ManagerIdClaim)), Times.Once);
        }
    }
}