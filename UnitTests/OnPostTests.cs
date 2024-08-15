using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanetWeights;
using PlanetWeights.Pages;

namespace UnitTests;

public class OnPostTests
{

    [Fact]
    public void Test_OnPost()
    {
        // Arrange
        var planetWeightsModel = new PlanetWeightsModel();
        planetWeightsModel.planetWeight = new PlanetWeight { weight = 15 };

        // Act
        var result = planetWeightsModel.OnPost();

        // Assert
        Assert.IsType<PageResult>(result);
    }

    [Fact]
    public void Test_OnPost_WeightZero()
    {
        // Arrange
        var planetWeightsModel = new PlanetWeightsModel();
        planetWeightsModel.planetWeight = new PlanetWeight { weight = 0.0 };

        // Act
        var result = planetWeightsModel.OnPost();

        // Assert
        Assert.IsType<PageResult>(result);
        Assert.True(planetWeightsModel.ModelState.ContainsKey(""));
        Assert.Equal("You need to enter your weight", planetWeightsModel.ModelState[""].Errors[0].ErrorMessage);
    }

    [Fact]
    public void Test_OnPost_WeightNonZero()
    {
        // Arrange
        var planetWeightsModel = new PlanetWeightsModel();
        planetWeightsModel.planetWeight = new PlanetWeight { weight = 1.0 };

        // Act
        var result = planetWeightsModel.OnPost();

        // Assert
        Assert.IsType<PageResult>(result);
        Assert.False(planetWeightsModel.ModelState.ContainsKey(""));
    }

    [Fact]
    public void Test_OnPost_WeightNegative()
    {
        // Arrange
        var planetWeightsModel = new PlanetWeightsModel();
        planetWeightsModel.planetWeight = new PlanetWeight { weight = -1.0 };

        // Act
        var result = planetWeightsModel.OnPost();

        // Assert
        Assert.IsType<PageResult>(result);
        Assert.True(planetWeightsModel.ModelState.ContainsKey(""));
        Assert.Equal("You need to enter your weight", planetWeightsModel.ModelState[""].Errors[0].ErrorMessage);
    }

    [Fact]
    public void Test_OnPost_WeightPositive()
    {
        // Arrange
        var planetWeightsModel = new PlanetWeightsModel();
        planetWeightsModel.planetWeight = new PlanetWeight { weight = 1.0 };

        // Act
        var result = planetWeightsModel.OnPost();

        // Assert
        Assert.IsType<PageResult>(result);
        Assert.False(planetWeightsModel.ModelState.ContainsKey(""));
    }
}

