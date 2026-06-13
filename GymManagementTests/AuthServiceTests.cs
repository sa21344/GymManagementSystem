using GymManagementAPI.DTOs;
using GymManagementAPI.Models;
using GymManagementAPI.Repositories;
using GymManagementAPI.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace GymManagementTests
{
    public class AuthServiceTests
    {
        [Fact]
        public async Task LoginAsync_ReturnsNull_WhenUserDoesNotExist()
        {
            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock
                .Setup(x => x.GetByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((User?)null);

            var configurationMock = new Mock<IConfiguration>();

            var service = new AuthService(
                userRepositoryMock.Object,
                configurationMock.Object);

            var loginDto = new LoginDto
            {
                Email = "test@test.com",
                Password = "123456"
            };

            var result = await service.LoginAsync(loginDto);

            Assert.Null(result);
        }

        [Fact]
        public async Task LoginAsync_ReturnsNull_WhenPasswordIsWrong()
        {
            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock
                .Setup(x => x.GetByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(new User
                {
                    FullName = "Sadri",
                    Email = "test@test.com",
                    PasswordHash = "correctpassword",
                    Role = "Member"
                });

            var configurationMock = new Mock<IConfiguration>();

            var service = new AuthService(
                userRepositoryMock.Object,
                configurationMock.Object);

            var loginDto = new LoginDto
            {
                Email = "test@test.com",
                Password = "wrongpassword"
            };

            var result = await service.LoginAsync(loginDto);

            Assert.Null(result);
        }

        [Fact]
        public async Task RegisterAsync_ThrowsException_WhenEmailExists()
        {
            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock
                .Setup(x => x.GetByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(new User());

            var configurationMock = new Mock<IConfiguration>();

            var service = new AuthService(
                userRepositoryMock.Object,
                configurationMock.Object);

            var dto = new RegisterDto
            {
                FullName = "Sadri",
                Email = "test@test.com",
                Password = "123456"
            };

            await Assert.ThrowsAsync<Exception>(
                () => service.RegisterAsync(dto));
        }

        [Fact]
        public async Task RegisterAsync_CreatesUser_WhenEmailDoesNotExist()
        {
            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock
                .Setup(x => x.GetByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((User?)null);

            var configurationMock = new Mock<IConfiguration>();

            var service = new AuthService(
                userRepositoryMock.Object,
                configurationMock.Object);

            var dto = new RegisterDto
            {
                FullName = "Sadri",
                Email = "new@test.com",
                Password = "123456"
            };

            await service.RegisterAsync(dto);

            userRepositoryMock.Verify(
                x => x.CreateAsync(It.IsAny<User>()),
                Times.Once);
        }
    }
}
