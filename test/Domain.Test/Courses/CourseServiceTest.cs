using System;
using System.Collections.Generic;
using System.Text;
using Bogus.Extensions;
using Domain.Courses;
using Moq;
using Xunit;

namespace Domain.UnitTest.Courses
{
    public class CourseServiceTest
    {
        [Fact]
        public static void must_add_course()
        {
            var courseDto = new CourseDto("Course A", "description course a", 90, "developer", 1600);
            var courseRepositoryMock = new Mock<ICourseRepository>();
            var courseService = new CourseService(courseRepositoryMock.Object);
            courseService.Save(courseDto);

            courseRepositoryMock.Verify(r => r.Save(It.IsAny<Course>()));
        }
    }

    public interface ICourseRepository
    {
        void Save(Course course);
    }

    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void Save(CourseDto courseDto)
        {
            var course = new Course(courseDto.Name, courseDto.Description, courseDto.Workload, Audience.Developer, courseDto.Value);
            _courseRepository.Save(course);
        }
    }

    public class CourseDto
    {
        public string Name { get; }
        public string Description { get; }
        public double Workload { get; }
        public string Audience { get; }
        public double Value { get; }

        public CourseDto(string name, string description, double workload, string audience, double value)
        {
            Name = name;
            Description = description;
            Workload = workload;
            Audience = audience;
            Value = value;
        }
    }
}
