using AutoMapper;
using FluentAssertions;
using Gradebook.App.Configuration.Mappings;
using Gradebook.App.Queries.Students.GetStudentByID;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Moq;

namespace Gradebook.UnitTests.Queries.Students.GetStudentByID {
    public class GetStudentByIDHandlerTest {
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly IMapper _mapper;
        public GetStudentByIDHandlerTest() {
            _studentRepositoryMock = new();
            _mapper = MapperHelper.CreateMapper(new StudentMappingProfile());
        }

        [Fact]
        public async Task Should_CallGetByIDAsyncRepository_WhenStudentQuery() {
            //Arrange
            _studentRepositoryMock.Setup(
                x => x.GetByIDAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Student());

            var handler = new GetStudentByIDQueryHandler(
                _studentRepositoryMock.Object,
                _mapper);

            //Act
            await handler.Handle(new GetStudentByIDQuery(1), default);

            //Assert
            _studentRepositoryMock.Verify(
                x => x.GetByIDAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()),
                Times.Once
                );
        }

        [Fact]
        public async Task Should_ReturnStudent_WhenGetStudentByIDQuery() {
            //Arrange

            var student = new Student() {
                ID = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "j.kowalski@gmail.com",
                DateOfBirth = DateOnly.FromDateTime(new DateTime(1990,1,1)),
                YearEnrolled = 2022,
                CreatedAt = DateTime. Now,
                UpdatedAt = DateTime. Now
            }; 

            _studentRepositoryMock.Setup(
                x => x.GetByIDAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(student);

            var handler = new GetStudentByIDQueryHandler(
                _studentRepositoryMock.Object,
                _mapper);

            //Act
            var studentDto = await handler.Handle(new GetStudentByIDQuery(1), default);

            //Assert
            studentDto.Should().NotBeNull();
            studentDto.ID.Should().Be(student.ID);
            studentDto.FirstName.Should().Be(student.FirstName);
            studentDto.LastName.Should().Be(student.LastName);
            studentDto.Email.Should().Be(student.Email);
            int studentAge = DateTime.Now.Year - student.DateOfBirth.ToDateTime(TimeOnly.Parse("00:00")).Year;
            studentDto.Age.Should().Be(studentAge);
            studentDto.YearEnrolled.Should().Be(student.YearEnrolled);
        }

        [Fact]
        public async Task Should_ReturnNull_WhenGetStudentByIDQuery() {
            //Arrange
            _studentRepositoryMock.Setup(
                x => x.GetByIDAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync((Student)null);

            var handler = new GetStudentByIDQueryHandler(
                _studentRepositoryMock.Object,
                _mapper);

            //Act
            var studentDto = await handler.Handle(new GetStudentByIDQuery(1), default);

            //Assert
            studentDto.Should().BeNull();
        }
    }
}
