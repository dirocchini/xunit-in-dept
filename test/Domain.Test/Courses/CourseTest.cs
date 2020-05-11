using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
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
            Name = name;
            Workload = workload;
            Audience = audience;
            Value = value;
        }
    }
}