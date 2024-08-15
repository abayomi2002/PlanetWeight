using Microsoft.Extensions.Logging;
using Moq;
using PlanetWeights.Pages;

namespace UnitTests;

/*
 tests for this:
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
 */
public class PrivacyPageTests
{
    [Fact]
    public void Test_OnGet()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<PrivacyModel>>();
        var privacyModel = new PrivacyModel(mockLogger.Object);

        // Act
        privacyModel.OnGet();

        // Assert
        // nothing to assert
    }
}
