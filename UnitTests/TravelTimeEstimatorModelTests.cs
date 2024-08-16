using PlanetWeights.Pages;
using System.Globalization;

namespace UnitTests
{
    public class TravelTimeEstimatorModelTests
    {
        public TravelTimeEstimatorModelTests()
        {
            // Set culture to invariant to avoid formatting issues in different environments
            CultureInfo cultureInfo = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }


        [Fact]
        public void OnPost_Should_ReturnErrorMessage_WhenSelectedPlanetIsNull()
        {
            // Arrange
            var model = new TravelTimeEstimatorModel
            {
                SelectedPlanet = null,
                Speed = 50000
            };

            // Act
            model.OnPost();

            // Assert
            Assert.Equal("Please select a planet.", model.TravelTime);
        }

        [Fact]
        public void OnPost_Should_ReturnErrorMessage_WhenSelectedPlanetIsEmpty()
        {
            // Arrange
            var model = new TravelTimeEstimatorModel
            {
                SelectedPlanet = string.Empty,
                Speed = 50000
            };

            // Act
            model.OnPost();

            // Assert
            Assert.Equal("Please select a planet.", model.TravelTime);
        }

        [Fact]
        public void OnPost_Should_ReturnErrorMessage_WhenSpeedIsZero()
        {
            // Arrange
            var model = new TravelTimeEstimatorModel
            {
                SelectedPlanet = "Mars",
                Speed = 0
            };

            // Act
            model.OnPost();

            // Assert
            Assert.Equal("Please enter a valid speed greater than 0.", model.TravelTime);
        }

        [Fact]
        public void OnPost_Should_ReturnErrorMessage_WhenSpeedIsNegative()
        {
            // Arrange
            var model = new TravelTimeEstimatorModel
            {
                SelectedPlanet = "Mars",
                Speed = -10
            };

            // Act
            model.OnPost();

            // Assert
            Assert.Equal("Please enter a valid speed greater than 0.", model.TravelTime);
        }

        [Fact]
        public void OnPost_Should_ReturnErrorMessage_WhenPlanetIsInvalid()
        {
            // Arrange
            var model = new TravelTimeEstimatorModel
            {
                SelectedPlanet = "Pluto",
                Speed = 50000
            };

            // Act
            model.OnPost();

            // Assert
            Assert.Equal("Invalid planet selection.", model.TravelTime);
        }

        [Theory]
        [InlineData("Mercury", 50000, "64.42 days (0.18 years) to reach Mercury at 50000 km/h.")]
        [InlineData("Venus", 100000, "17.25 days (0.05 years) to reach Venus at 100000 km/h.")]
        [InlineData("Mars", 25000, "130.50 days (0.36 years) to reach Mars at 25000 km/h.")]
        [InlineData("Jupiter", 100000, "261.96 days (0.72 years) to reach Jupiter at 100000 km/h.")]
        [InlineData("Saturn", 200000, "265.62 days (0.73 years) to reach Saturn at 200000 km/h.")]
        public void OnPost_Should_CalculateTravelTime_ForValidInputs(string planet, double speed, string expectedTravelTime)
        {
            // Arrange
            var model = new TravelTimeEstimatorModel
            {
                SelectedPlanet = planet,
                Speed = speed
            };

            // Act
            model.OnPost();

            // Assert
            Assert.Equal(expectedTravelTime, model.TravelTime);
        }
    }
}
