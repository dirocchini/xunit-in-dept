using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Test
{
    public class Examples
    {
        [Fact]
        public void Model()
        {
            //ARRANGE
            var variable1 = 1;
            var variable2 = 2;

            //ACTION
            variable2 = variable1;

            //ASSERT
            Assert.Equal(variable1, variable2);
        }
    }
}
