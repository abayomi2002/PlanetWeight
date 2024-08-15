using PlanetWeights;

namespace UnitTests;

public class PlanetWeightEntityTests
{
    [Fact]
    public void Test_WeightMin()
    {
        // Arrange
        var planetWeight = new PlanetWeight();

        // Act
        var weightMin = PlanetWeight.weightMin;

        // Assert
        Assert.Equal(1, weightMin);
    }

    [Fact]
    public void Test_WeightMax()
    {
        // Arrange
        var planetWeight = new PlanetWeight();

        // Act
        var weightMax = PlanetWeight.WeightMax;

        // Assert
        Assert.Equal(500, weightMax);
    }

    [Fact]
    public void Test_Weight()
    {
        // Arrange
        var planetWeight = new PlanetWeight();

        // Act
        var weight = planetWeight.weight;

        // Assert
        Assert.Equal(0, weight);
    }

    [Fact]
    public void Test_Planet()
    {
        // Arrange
        var planetWeight = new PlanetWeight();

        // Act
        var planet = planetWeight.planet;

        // Assert
        Assert.Equal(Planets.mercury, planet);
    }

    [Fact]
    public void Test_WeightOnPlanet()
    {
        // Arrange
        var planetWeight = new PlanetWeight();

        // Act
        var weightOnPlanet = planetWeight.weightOnPlanet;

        // Assert
        Assert.Equal(0, weightOnPlanet);
    }

    [Fact]
    public void Test_PlanetsSurfaceGravity()
    {
        // Arrange
        var planetWeight = new PlanetWeight();

        // Act
        var planetsSurfaceGravity = planetWeight.planetsSurfaceGravity;

        // Assert
        Assert.Equal(0.378, planetsSurfaceGravity[0]);
        Assert.Equal(0.907, planetsSurfaceGravity[1]);
        Assert.Equal(0.166, planetsSurfaceGravity[2]);
        Assert.Equal(0.377, planetsSurfaceGravity[3]);
        Assert.Equal(2.36, planetsSurfaceGravity[4]);
        Assert.Equal(0.916, planetsSurfaceGravity[5]);
        Assert.Equal(0.889, planetsSurfaceGravity[6]);
        Assert.Equal(1.12, planetsSurfaceGravity[7]);
        Assert.Equal(0.071, planetsSurfaceGravity[8]);
    }

    [Fact]
    public void Test_WeightConverted()
    {
        // Arrange
        var planetWeight = new PlanetWeight();

        // Act
        var weightConverted = planetWeight.weight;

        // Assert
        Assert.Equal(0, weightConverted);
    }

    [Fact]
    public void Test_WeightConvertedMercury()
    {
        // Arrange
        var planetWeight = new PlanetWeight();
        planetWeight.planet = Planets.mercury;
        planetWeight.weight = 100;

        // Act
        var weightConverted = planetWeight.weightOnPlanet;

        // Assert
        Assert.Equal(37.8, weightConverted);
    }

    [Fact]
    public void Test_WeightConvertedVenus()
    {
        // Arrange
        var planetWeight = new PlanetWeight();
        planetWeight.planet = Planets.venus;
        planetWeight.weight = 100;

        // Act
        var weightConverted = planetWeight.weightOnPlanet;

        // Assert
        Assert.Equal(90.7, weightConverted);
    }
}

