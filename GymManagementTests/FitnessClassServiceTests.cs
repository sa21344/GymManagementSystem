using AutoMapper;
using GymManagementAPI.DTOs;
using GymManagementAPI.Models;
using GymManagementAPI.Repositories;
using GymManagementAPI.Services;
using Moq;
using Xunit;

namespace GymManagementTests
{
    public class FitnessClassServiceTests
    {
        [Fact]
        public async Task CreateAsync_ThrowsException_WhenCapacityIsZero()
        {
            var repositoryMock = new Mock<IFitnessClassRepository>();
            var mapperMock = new Mock<IMapper>();

            var service = new FitnessClassService(
                repositoryMock.Object,
                mapperMock.Object);

            var dto = new FitnessClassCreateDto
            {
                Name = "Yoga",
                Instructor = "Sadri",
                Category = "Fitness",
                Capacity = 0,
                DurationMinutes = 60,
                ScheduledDate = DateTime.UtcNow.AddDays(1)
            };

            await Assert.ThrowsAsync<Exception>(
                () => service.CreateAsync(dto));
        }

        [Fact]
        public async Task CreateAsync_ThrowsException_WhenScheduledDateIsInPast()
        {
            var repositoryMock = new Mock<IFitnessClassRepository>();
            var mapperMock = new Mock<IMapper>();

            var service = new FitnessClassService(
                repositoryMock.Object,
                mapperMock.Object);

            var dto = new FitnessClassCreateDto
            {
                Name = "Yoga",
                Instructor = "Sadri",
                Category = "Fitness",
                Capacity = 10,
                DurationMinutes = 60,
                ScheduledDate = DateTime.UtcNow.AddDays(-1)
            };

            await Assert.ThrowsAsync<Exception>(
                () => service.CreateAsync(dto));
        }

        [Fact]
        public async Task CreateAsync_CallsRepository_WhenDataIsValid()
        {
            var repositoryMock = new Mock<IFitnessClassRepository>();
            var mapperMock = new Mock<IMapper>();

            var service = new FitnessClassService(
                repositoryMock.Object,
                mapperMock.Object);

            var dto = new FitnessClassCreateDto
            {
                Name = "Yoga",
                Instructor = "Sadri",
                Category = "Fitness",
                Capacity = 10,
                DurationMinutes = 60,
                ScheduledDate = DateTime.UtcNow.AddDays(1)
            };

            mapperMock
                .Setup(x => x.Map<FitnessClass>(It.IsAny<object>()))
                .Returns(new FitnessClass());

            mapperMock
                .Setup(x => x.Map<FitnessClassReadDto>(It.IsAny<object>()))
                .Returns(new FitnessClassReadDto());

            await service.CreateAsync(dto);

            repositoryMock.Verify(
                x => x.CreateAsync(It.IsAny<FitnessClass>()),
                Times.Once);
        }
    }
}