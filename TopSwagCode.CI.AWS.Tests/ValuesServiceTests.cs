using System;
using System.Collections.Generic;
using TopSwagCode.CI.AWS.WebAPI.Services;
using Xunit;

namespace TopSwagCode.CI.AWS.Tests
{
    public class ValuesServiceTests
    {
        private readonly ValuesService _valuesService;

        public ValuesServiceTests()
        {
            _valuesService = new ValuesService();
        }

        [Fact]
        public void SumOfValues_Should_Return_Sum_Of_All_Values()
        {
            // Arrange
            var values = new List<int>() {1, 2, 3};

            // Act
            var result = _valuesService.SumOfValues(values);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void SumOfValues_Should_Return_0_For_Empty_List()
        {
            // Arrange
            var values = new List<int>() { };

            // Act
            var result = _valuesService.SumOfValues(values);

            // Assert
            Assert.Equal(0, result);
        }
    }
}
