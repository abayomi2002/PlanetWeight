using TechTalk.SpecFlow;
using PlanetWeights;
namespace UnitTests;
[Binding]
public class PlanetWeightStepsTests
{
    private PlanetWeight _planetWeight = null!;
    private string _errorMessage = string.Empty;

    [Given(@"a user enters a weight of (.*) lbs")]
    public void GivenAUserEntersAWeightOfLbs(double weight)
    {
        _planetWeight = new PlanetWeight { weight = weight };
    }

    [Given(@"selects the planet ""(.*)""")]
    public void GivenSelectsThePlanet(string planetName)
    {
        Enum.TryParse(planetName.ToLower(), out Planets planet);
        _planetWeight.planet = planet;
    }

    [When(@"the weight on (.*) is calculated")]
    public void WhenTheWeightOnPlanetIsCalculated(string planetName)
    {
        // The weight calculation happens automatically in the getter of weightOnPlanet
        _ = _planetWeight.weightOnPlanet;
    }

    [Then(@"the calculated weight should be (.*) lbs")]
    public void ThenTheCalculatedWeightShouldBeLbs(double expectedWeight)
    {
        Assert.Equal(expectedWeight, _planetWeight.weightOnPlanet);
    }

    [When(@"the form is submitted")]
    public void WhenTheFormIsSubmitted()
    {
        // Simulate the form submission and validation
        if (_planetWeight.weight < PlanetWeight.weightMin || _planetWeight.weight > PlanetWeight.WeightMax)
        {
            _errorMessage = "Invalid weight - Only Available from 1 to 500 lbs";
        }
    }

    [Then(@"an error message ""(.*)"" should be displayed")]
    public void ThenAnErrorMessageShouldBeDisplayed(string expectedMessage)
    {
        Assert.Equal(expectedMessage, _errorMessage);
    }
}
