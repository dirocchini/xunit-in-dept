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
        private readonly string _name;
        private readonly double _workload;
        private readonly Audience _audience;
        private readonly double _value;


        public CourseTest()
        {
            _name = "course 1";
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
                Workload = _workload,
                Audience = _audience,
                Value = _value
            };

            var course = new Course(expectedCourse.Name, expectedCourse.Workload, expectedCourse.Audience, expectedCourse.Value);
            expectedCourse.ToExpectedObject().ShouldMatch(course);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void course_name_should_not_be_empty_nor_null(string courseName)
        {
            Assert.Throws<ArgumentException>(() => new Course(courseName, _workload,_audience,_value)).WithMessage($"Invalid Name");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void course_should_not_have_workload_less_than_one(double workload)
        {
            Assert.Throws<ArgumentException>(() => new Course(_name, workload, _audience, _value)).WithMessage($"Invalid Workload");
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void course_should_not_have_value_less_than_one(double value)
        {
            Assert.Throws<ArgumentException>(() => new Course(_name, _workload, _audience, value)).WithMessage("Invalid Value");
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