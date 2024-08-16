using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace PlanetWeights.Pages
{
    public class TravelTimeEstimatorModel : PageModel
    {
        public string[] Planets { get; set; } = new string[]
            {
        "Mercury", "Venus", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"
            };

        public Dictionary<string, double> PlanetDistances { get; set; } = new Dictionary<string, double>
        {
            { "Mercury", 77.3 }, // Distance from Earth to Mercury in million km
            { "Venus", 41.4 },   // Distance from Earth to Venus in million km
            { "Mars", 78.3 },    // Distance from Earth to Mars in million km
            { "Jupiter", 628.7 }, // Distance from Earth to Jupiter in million km
            { "Saturn", 1275.0 }, // Distance from Earth to Saturn in million km
            { "Uranus", 2721.0 }, // Distance from Earth to Uranus in million km
            { "Neptune", 4351.0 } // Distance from Earth to Neptune in million km
        };

        [BindProperty]
        public string SelectedPlanet { get; set; }

        [BindProperty]
        public double Speed { get; set; }

        public string TravelTime { get; set; }

        public void OnPost()
        {
            if (string.IsNullOrEmpty(SelectedPlanet))
            {
                TravelTime = "Please select a planet.";
                return;
            }

            if (Speed <= 0)
            {
                TravelTime = "Please enter a valid speed greater than 0.";
                return;
            }

            if (PlanetDistances.TryGetValue(SelectedPlanet, out double distance))
            {
                distance *= 1_000_000; // Convert distance to km
                double timeInHours = distance / Speed;
                double timeInDays = timeInHours / 24;
                double timeInYears = timeInDays / 365;

                TravelTime = $"{timeInDays:N2} days ({timeInYears:N2} years) to reach {SelectedPlanet} at {Speed} km/h.";
            }
            else
            {
                TravelTime = "Invalid planet selection.";
            }
        }

    }
}

