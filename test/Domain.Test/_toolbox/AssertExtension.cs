using System;
using Xunit;

namespace Domain.UnitTest._toolbox
{
    public static class AssertExtension
    {
        public static void WithMessage(this ArgumentException exception, string message)
        {
            if(exception.Message == message)
                Assert.True(true);
            else
                Assert.False(true, $"Expected message <<{message}>>. Received message <<{exception.Message}>>");
        }
    }
}
