using System;
using Xunit;
using PlanetWeights;
using System.ComponentModel.DataAnnotations;

namespace PlanetWeights.Tests
{
    public class PlanetWeightTests
    {
        [Theory]
        [InlineData(100, Planets.mercury, 37.8)]
        [InlineData(100, Planets.venus, 90.7)]
        [InlineData(100, Planets.moon, 16.6)]
        [InlineData(100, Planets.mars, 37.7)]
        [InlineData(100, Planets.jupiter, 236)]
        [InlineData(100, Planets.saturn, 91.6)]
        [InlineData(100, Planets.uranus, 88.9)]
        [InlineData(100, Planets.neptune, 112)]
        [InlineData(100, Planets.pluto, 7.1)]
        public void TestWeightOnPlanet_ValidWeightAndPlanet_ReturnsCorrectWeightOnPlanet(double weight, Planets planet, double expectedWeightOnPlanet)
        {
            // Arrange
            var planetWeight = new PlanetWeight
            {
                weight = weight,
                planet = planet
            };

            // Act
            var result = planetWeight.weightOnPlanet;

            // Assert
            Assert.Equal(expectedWeightOnPlanet, result, 1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(501)]
        public void TestWeight_ValidationFails_ForInvalidWeights(double weight)
        {
            // Arrange
            var planetWeight = new PlanetWeight
            {
                weight = weight,
                planet = Planets.mars
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(planetWeight);
            var isValid = Validator.TryValidateObject(planetWeight, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.ErrorMessage == "Invalid weight - Only Available from 1 to 500 lbs");
        }

        [Fact]
        public void TestWeightOnPlanet_DefaultValues_ReturnsCorrectWeightOnPlanet()
        {
            // Arrange
            var planetWeight = new PlanetWeight
            {
                weight = 100,
                planet = Planets.jupiter
            };

            // Act
            var result = planetWeight.weightOnPlanet;

            // Assert
            Assert.Equal(236, result, 1);
        }
    }
}
