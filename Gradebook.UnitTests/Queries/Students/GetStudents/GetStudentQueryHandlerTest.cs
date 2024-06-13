using AutoMapper;
using FluentAssertions;
using Gradebook.App.Configuration.Mappings;
using Gradebook.App.Queries.Students.GetStudents;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gradebook.UnitTests.Queries.Students.GetStudents {
    public class GetStudentQueryHandlerTest {
        private readonly Mock<IStudentReadOnlyRepository> _studentReadOnlyRepositoryMock;
        private readonly IMapper _mapper;
        public GetStudentQueryHandlerTest() {
            _studentReadOnlyRepositoryMock = new();
            _mapper = MapperHelper.CreateMapper(new StudentMappingProfile());
        }

        [Fact]
        public async Task Should_CallGetAllAsyncRepository_WhenStudentQuery() {
            //Arrange
            _studentReadOnlyRepositoryMock.Setup(
                x => x.GetAllAsync(
                    It.IsAny<CancellationToken>())).ReturnsAsync(Enumerable.Empty<Student>);

            var handler = new GetStudentsQueryHandler(
                _studentReadOnlyRepositoryMock.Object,
                _mapper);

            //Act
            await handler.Handle(new GetStudentsQuery(), default);

            //Assert
            _studentReadOnlyRepositoryMock.Verify(
                x => x.GetAllAsync(It.IsAny<CancellationToken>()),
                Times.Once
                );
        }

        [Fact]
        public async Task Should_Return_NotEmptyCollection_WhenGetStudentsQuery() {

            //Arrange
            var students = new List<Student>() {
                new Student() {
                    ID = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Email = "j.kowalski@gmail.com",
                    DateOfBirth = DateOnly.FromDateTime(new DateTime(1990,1,1)),
                    YearEnrolled = 2022,
                    CreatedAt = DateTime. Now,
                    UpdatedAt = DateTime. Now
                },
                new Student(){
                    ID = 2,
                    FirstName = "Adam",
                    LastName = "Nowak",
                    Email = "a.nowak@gmail.com",
                    DateOfBirth = DateOnly.FromDateTime(new DateTime (1995,1,1)),
                    YearEnrolled = 2020,
                    CreatedAt = DateTime. Now,
                    UpdatedAt = DateTime.Now 
                }
            };

            _studentReadOnlyRepositoryMock.Setup(
                x => x.GetAllAsync(
                    It.IsAny<CancellationToken>())).ReturnsAsync(students);

            var handler = new GetStudentsQueryHandler(
                _studentReadOnlyRepositoryMock.Object,
                _mapper);

            //Act
            var studentsDto =  await handler.Handle(new GetStudentsQuery(), default);

            //Assert
            studentsDto.Should().NotBeNullOrEmpty();

        }
    }
}
