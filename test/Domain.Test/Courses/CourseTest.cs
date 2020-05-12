using System;
using Bogus;
using Domain.Courses;
using Domain.UnitTest._builders;
using Domain.UnitTest._toolbox;
using ExpectedObjects;
using Xunit;

namespace Domain.UnitTest.Courses
{
    public class CourseTest
    {
        private readonly string _name;
        private readonly string _description;
        private readonly double _workload;
        private readonly Audience _audience;
        private readonly double _value;


        public CourseTest()
        {
            var faker = new Faker();
            _name = faker.Name.FullName();
            _description = faker.Random.Words(5);
            _workload = faker.Random.Double(1, 450);
            _audience = Audience.Developer;
            _value = faker.Random.Double(0, 1600);
        }


        [Fact]
        public void course_should_create()
        {
            var expectedCourse = new
            {
                Name = _name,
                Description = _description,
                Workload = _workload,
                Audience = _audience,
                Value = _value
            };

            var course = new Course(expectedCourse.Name, _description, expectedCourse.Workload, expectedCourse.Audience, expectedCourse.Value);
            expectedCourse.ToExpectedObject().ShouldMatch(course);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void course_name_should_not_be_empty_nor_null(string courseName)
        {
            Assert.Throws<ArgumentException>(() => new CourseBuilder().WithName(courseName).Build());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void course_should_not_have_workload_less_than_one(double workload)
        {
            Assert.Throws<ArgumentException>(() => new CourseBuilder().WithWorkload(workload).Build());
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void course_should_not_have_value_less_than_zero(double value)
        {
            Assert.Throws<ArgumentException>(() => new CourseBuilder().WithValue(value).Build()).WithMessage("Invalid Course Value");
        }
    }
}