using Microsoft.EntityFrameworkCore;
using Moq;
using MyHealth.API.Controllers;
using MyHealth.API.Validators;
using MyHealth.Data;
using MyHealth.Data.Repositories;
using MyHealth.Model;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MyHealthWeb.UnitTest
{
    public class UsersControllerTests
    {

        private Mock<ApplicationUserValidators> _applicationUserValidatorsMock;
        private Mock<ApplicationUsersRepository> _applicationUserRepositoryMock;
        private Mock<MyHealthContext> _myHealthContextMock;
        private UsersController _usersController;


        [SetUp]
        public void Setup()
        {
            _myHealthContextMock = new Mock<MyHealthContext>(new DbContextOptions<MyHealthContext>());
            _applicationUserValidatorsMock = new Mock<ApplicationUserValidators>();
            _applicationUserRepositoryMock = new Mock<ApplicationUsersRepository>();

            _usersController = new UsersController(
                _applicationUserRepositoryMock.Object,
                _applicationUserValidatorsMock.Object,
                _myHealthContextMock.Object);

        }

        [Test]
        public async Task requestShouldFailWhenPasswordIsInvalid()
        {
            var request = new ApplicationUserAddRequest()
            {
                user = new ApplicationUser(),
                password = "test"
            };

            var invalidPasswordMessage = "Invalid Password Message";

            _applicationUserValidatorsMock.Setup(v => v.InvalidPasswordMessage).Returns(invalidPasswordMessage);
            _applicationUserValidatorsMock.Setup(v => v.ValidatePasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .Returns(Task.FromResult(false));

            var response = await _usersController.AddAsync(request);

            Assert.IsFalse(response.status);
            Assert.AreEqual(response.message, invalidPasswordMessage);
        }
    }
}