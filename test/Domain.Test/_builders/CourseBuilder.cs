using System;
using Bogus;
using Domain.Courses;
using Domain.UnitTest.Courses;

namespace Domain.UnitTest._builders
{
    public class CourseBuilder
    {
        private string _name = new Faker().Name.FullName();
        private string _description = new Faker().Random.Words(5);
        private double _workload = new Faker().Random.Double(1, 2000);
        private Audience _audience = Audience.Developer;
        private double _value = new Faker().Random.Double(0, 2500);

        public static CourseBuilder New()
        {
            return new CourseBuilder();
        }

        public CourseBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CourseBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public CourseBuilder WithWorkload(double workload)
        {
            _workload = workload;
            return this;
        }

        public CourseBuilder WithAudience(Audience audience)
        {
            _audience = audience;
            return this;
        }

        public CourseBuilder WithValue(double value)
        {
            _value = value;
            return this;
        }

        public Course Build()
        {
            return new Course(_name, _description, _workload, _audience, _value);
        }


    }
}
