using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Xunit;

namespace Domain.Test._toolbox
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
