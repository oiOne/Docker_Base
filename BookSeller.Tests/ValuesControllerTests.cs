using System;
using Xunit;

namespace BookSeller.Tests
{
    public class ValuesControllerTests
    {
        /*
         *
         * docker-compose -f docker-compose-test.yml -f docker-compose-test.override.yml up
         */
        [Fact]
        public void Check_Tests_Availability()
        {
            var actual = 22;
            var expected = 22;

            Assert.Equal(expected, actual);
        }
    }
}
