using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Domain.Test._toolbox;
using ExpectedObjects;
using Xunit;

namespace Domain.Test.Courses
{
    public class CourseTest
    {
        [Fact]
        public void course_should_create()
        {
            var expectedCourse = new
            {
                Name = "course 1",
                Workload = (double)80,
                Audience = Audience.Student,
                Value = (double)20
            };

            var course = new Course(expectedCourse.Name, expectedCourse.Workload, expectedCourse.Audience, expectedCourse.Value);
            expectedCourse.ToExpectedObject().ShouldMatch(course);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void course_name_should_not_be_empty_nor_null(string courseName)
        {
            var expectedCourse = new
            {
                Name = courseName,
                Workload = (double)80,
                Audience = Audience.Student,
                Value = (double)20
            };

            Assert.Throws<ArgumentException>(() => new Course(expectedCourse.Name, expectedCourse.Workload, expectedCourse.Audience, expectedCourse.Value)).WithMessage($"Invalid Name");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void course_should_not_have_workload_less_than_one(double workload)
        {
            var expectedCourse = new
            {
                Name = "course 1 ",
                Workload = workload,
                Audience = Audience.Student,
                Value = (double)20
            };

            Assert.Throws<ArgumentException>(() => new Course(expectedCourse.Name, expectedCourse.Workload, expectedCourse.Audience, expectedCourse.Value)).WithMessage($"Invalid Workload");
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void course_should_not_have_value_less_than_one(double value)
        {
            var expectedCourse = new
            {
                Name = "course 1 ",
                Workload = (double)20,
                Audience = Audience.Student,
                Value = value
            };

            Assert.Throws<ArgumentException>(() => new Course(expectedCourse.Name, expectedCourse.Workload, expectedCourse.Audience, expectedCourse.Value)).WithMessage("Invalid Value");
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
        public double Workload { get; private set; }
        public Audience Audience { get; private set; }
        public double Value { get; private set; }

        public Course(string name, in double workload, Audience audience, in double value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Invalid Name");

            if (workload <= 0)
                throw new ArgumentException("Invalid Workload");

            if (value <= 1)
                throw new ArgumentException("Invalid Value");


            Name = name;
            Workload = workload;
            Audience = audience;
            Value = value;
        }
    }
}