using AlpineHub.Core.Services;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using Microsoft.AspNetCore.Identity;
using MockQueryable;
using Moq;

namespace AlpineHub.Tests
{
    public class CartServiceTests
    {
        private CartService cartService;
        private Mock<IRepo> repoMock;
        private Mock<UserManager<ApplicationUser>> userManagerMock;
        private Pass pass1;
        private Pass pass2;
        private UserCart cart;
        private Guid cartId = Guid.Parse("B6C15F2A-3F6C-4511-BB84-659A388D4E02");
        private CartItem item1;
        private CartItem item2;
        private ApplicationUser user;
        private ApplicationUser user2;
        [SetUp]
        public void Setup()
        {
            pass1 = new Pass()
            {
                Id = Guid.Parse("570FF57F-C607-49B2-A840-392FA2C4CE12"),
                Name = "Pass1",
                Price = 10,
                PassAgeGroupId = Guid.Parse("E7A1B0F6-AC65-467C-9136-6DE47D011219"),
                PassPeriodId = Guid.Parse("B5C15F2A-3F6C-4511-BB84-659A388D4E02"),
            };

            pass2 = new()
            {
                Id = Guid.Parse("2913452C-8B14-4D13-BC2B-80B74140958F"),
                Name = "Pass2",
                Price = 20,
                PassAgeGroupId = Guid.Parse("760CAE70-59B6-4C61-9CDA-9AD82086A903"),
                PassPeriodId = Guid.Parse("73DF4484-9833-4E7C-B340-90346DAA2E8B"),
            };
            user = new ApplicationUser()
            {
                Id = Guid.Parse("7E7CE420-5F4D-4ACE-B117-9B74F86DA36F"),
                FirstName = "Test",
                LastName = "Test",
            };
            user2 = new ApplicationUser()
            {
                Id = Guid.Parse("7E7CF420-5F4D-4ACE-B117-9B74F86DA36F"),
                FirstName = "Test",
                LastName = "Test",
            };
            item1 = new CartItem()
            {
                Id = Guid.Parse("B6C25F2A-3F6C-4511-BB84-659A388D4E02"),

                CartId = cartId,
                PassId = pass1.Id,
                Pass=pass1,
                TotalPrice = 12
            };
            item2 = new CartItem()
            {
                Id = Guid.Parse("B6C35F4A-3F6C-4511-BB84-659A388D4E02"),
                CartId = cartId,
                PassId = pass2.Id,
                Pass = pass2,
                TotalPrice = 13
            };
            cart = new UserCart()
            {
                Id = cartId,
                UserId = user.Id,
                CartItems = new List<CartItem>() { item1 },
            };
            repoMock = new Mock<IRepo>();
            userManagerMock = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(),
                null, null, null, null, null, null, null, null);

            userManagerMock.Setup(s => s.FindByIdAsync(user.Id.ToString()).Result).Returns(user);
            userManagerMock.Setup(s => s.FindByIdAsync(user2.Id.ToString()).Result).Returns(user2);

            repoMock.Setup(s => s.GetAll<Pass>()).Returns(new List<Pass>() { pass1, pass2 }.AsQueryable().BuildMock());
            repoMock.Setup(s => s.GetByIdAsync<Pass>(pass1.Id).Result).Returns(pass1);
            repoMock.Setup(s => s.GetByIdAsync<Pass>(pass2.Id).Result).Returns(pass2);
            repoMock.Setup(s => s.GetByIdAsync<CartItem>(item1.Id).Result).Returns(item1);
            repoMock.Setup(s => s.GetByIdAsync<CartItem>(item2.Id).Result).Returns(item2);
            repoMock.Setup(s => s.GetAll<UserCart>()).Returns(new List<UserCart>() { cart }.AsQueryable().BuildMock());
            repoMock.Setup(s => s.GetAllReadonly<UserCart>()).Returns(new List<UserCart>() { cart }.AsQueryable().BuildMock());
            repoMock.Setup(s => s.GetAll<CartItem>()).Returns(new List<CartItem>() { item1, item2 }.AsQueryable().BuildMock());

            repoMock.Setup(m => m.AddAsync(It.IsAny<CartItem>())).Callback<CartItem>((s) =>
            {
                cart.CartItems.Add(s);
            });

            repoMock.Setup(m => m.Delete(It.IsAny<CartItem>())).Callback<CartItem>(s =>
            {
                cart.CartItems.Remove(cart.CartItems.FirstOrDefault(t => t.Id == s.Id));
            });

            cartService = new CartService(repoMock.Object, userManagerMock.Object);
        }
        [Test]
        public void AddToCart_WithValidData_ShouldAddToCart()
        {
            var passId = pass2.Id.ToString();
            var userId = user.Id.ToString();
            var quantity = 2;

            var result = cartService.AddToCart(passId, userId, quantity).Result;
            var cart = cartService.GetCart(userId).Result;
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void AddToCart_WithExistingPass_ShouldIncreaseQuantity()
        {
            var passId = pass1.Id.ToString();
            var userId = user.Id.ToString();
            var quantity = 2;


            var result = cartService.AddToCart(passId, userId, quantity).Result;

            Assert.That(result, Is.EqualTo(1));
        }
        [Test]

        public void AddToCart_WithInvalidPassId_ShouldThrowArgumentException()
        {
            var passId = "invalid";
            var userId = user.Id.ToString();
            var quantity = 2;

            Assert.That(() => cartService.AddToCart(passId, userId, quantity), Throws.ArgumentException);
        }
        [Test]
        public void AddToCart_WithInvalidUserId_ShouldThrowArgumentException()
        {
            var passId = pass2.Id.ToString();
            var userId = "invalid";
            var quantity = 2;

            Assert.That(() => cartService.AddToCart(passId, userId, quantity), Throws.ArgumentException);
        }
        [Test]
        public void AddToCart_WithInvalidQuantity_ShouldThrowArgumentException()
        {
            var passId = pass2.Id.ToString();
            var userId = user.Id.ToString();
            var quantity = -2;

            Assert.That(() => cartService.AddToCart(passId, userId, quantity), Throws.ArgumentException);
        }
        [Test]
        public void ClearCart_WithValidData_ShouldClearCart()
        {
            var userId = user.Id.ToString();

            cartService.ClearCart(userId).Wait();
            repoMock.Verify(r => r.Delete(cart), Times.Once);
        }
        [Test]
        public void ClearCart_WithInvalidUserId_ShouldThrowArgumentException()
        {
            var userId = "invalid";


            Assert.That(() => cartService.ClearCart(userId), Throws.ArgumentException);
        }
        [Test]
        public void GetCart_WithValidData_ShouldReturnCart()
        {

            var userId = user.Id.ToString();


            var result = cartService.GetCart(userId).Result;

            Assert.That(result.CartTotalPrice, Is.EqualTo(12));
        }
        [Test]
        public void GetCart_WithInvalidUserId_ShouldThrowArgumentException()
        {
            var userId = "invalid";

            Assert.ThrowsAsync<ArgumentException>(async () => await cartService.GetCart(userId));
        }
        [Test]
        public void GetCartCount_WithValidData_ShouldReturnCartCount()
        {
            var userId = user.Id.ToString();

            var result = cartService.GetCartCount(userId).Result;

            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void GetCartCount_WithInvalidUserId_ShouldReturnZero()
        {

            var userId = "invalid";

            var result = cartService.GetCartCount(userId).Result;

            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void delete_WithValidData_ShouldRemoveFromCart()
        {
            var itemId = item1.Id.ToString();
            var userId = user.Id.ToString();
            cartService.DeleteItem(itemId, userId).Wait();
            repoMock.Verify(r => r.Delete(item1), Times.Once);
        }
        [Test]
        public void Delete_WithInvalidItemId_ShouldThrowArgumentException()
        {

            var itemId = "invalid";
            var userId = user.Id.ToString();

            Assert.That(() => cartService.DeleteItem(itemId, userId), Throws.ArgumentException);
        }
        [Test]
        public void Delete_WithInvalidUserId_ShouldThrowArgumentException()
        {
            var itemId = item1.Id.ToString();
            var userId = "invalid";


            Assert.That(() => cartService.DeleteItem(itemId, userId), Throws.ArgumentException);
        }
        [Test]
        public void Delete_WithItemNotFound_ShouldThrowArgumentException()
        {
            var itemId = Guid.NewGuid().ToString();
            var userId = user.Id.ToString();

            Assert.That(() => cartService.DeleteItem(itemId, userId), Throws.ArgumentException);
        }
        [Test]
        public void Delete_WithCartNotFound_ShouldThrowInvalidOperationException()
        {
            var itemId = item1.Id.ToString();
            var userId = user2.Id.ToString();

            Assert.That(() => cartService.DeleteItem(itemId, userId), Throws.InvalidOperationException);
        }
        [Test]
        public void UpdateItemQuantity_WithValidData_ShouldUpdateQuantity()
        {
            var itemId = item1.Id.ToString();
            var userId = user.Id.ToString();
            var quantity = 2;

            cartService.UpdateItemQuantity(itemId, userId, quantity).Wait();

            Assert.That(item1.Quantity == 2);
        }
        [Test]
        public void UpdateItemQuantity_WithInvalidItemId_ShouldThrowArgumentException()
        {
            var itemId = "invalid";
            var userId = user.Id.ToString();
            var quantity = 2;

            Assert.That(() => cartService.UpdateItemQuantity(itemId, userId, quantity), Throws.ArgumentException);
        }
        [Test]
        public void UpdateItemQuantity_WithInvalidUserId_ShouldThrowArgumentException()
        {
            var itemId = item1.Id.ToString();
            var userId = "invalid";
            var quantity = 2;

            Assert.That(() => cartService.UpdateItemQuantity(itemId, userId, quantity), Throws.ArgumentException);
        }
        [Test]
        public void UpdateItemQuantity_WithQuantityZero_ShouldRemoveItem()
        {
            var itemId = item1.Id.ToString();
            var userId = user.Id.ToString();
            var quantity = 0;

            cartService.UpdateItemQuantity(itemId, userId, quantity).Wait();

            Assert.That(cart.CartItems.Count, Is.EqualTo(0));
        }
    }

}
