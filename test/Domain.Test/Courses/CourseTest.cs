using System;
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
            _name = "course 1";
            _description = "new development course to TDD";
            _workload = 80;
            _audience = Audience.Student;
            _value = 20;
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
        public void course_should_not_have_value_less_than_one(double value)
        {
            Assert.Throws<ArgumentException>(() => new CourseBuilder().WithValue(value).Build()).WithMessage("Invalid Value");
        }
    }

    public enum Audience
    {
        Student,
        Developer,
        Employee,
        Director
    }
    public class Course
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Workload { get; private set; }
        public Audience Audience { get; private set; }
        public double Value { get; private set; }

        public Course(string name, string description, in double workload, Audience audience, in double value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Invalid Name");

            if (workload <= 0)
                throw new ArgumentException("Invalid Workload");

            if (value <= 1)
                throw new ArgumentException("Invalid Value");


            Name = name;
            Description = description;
            Workload = workload;
            Audience = audience;
            Value = value;
        }
    }
}