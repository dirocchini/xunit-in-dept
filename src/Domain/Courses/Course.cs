using System;

namespace Domain.Courses
{
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

            if (workload <= 1)
                throw new ArgumentException("Invalid Workload");

            if (value <= 0)
                throw new ArgumentException("Invalid Course Value");


            Name = name;
            Description = description;
            Workload = workload;
            Audience = audience;
            Value = value;
        }
    }
}