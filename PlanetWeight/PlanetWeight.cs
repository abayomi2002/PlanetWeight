using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlanetWeights
{
    public enum Planets
    {
        [Display(Name = "Mercury")] mercury,
        [Display(Name = "Venus")] venus,
        [Display(Name = "The Moon")] moon,
        [Display(Name = "Mars")] mars,
        [Display(Name = "Jupiter")] jupiter,
        [Display(Name = "Saturn")] saturn,
        [Display(Name = "Uranus")] uranus,
        [Display(Name = "Neptune")] neptune,
        [Display(Name = "Pluto")] pluto
    }


    //Class to present to the Internet
    public class PlanetWeight
    {
        private readonly List<double> planetsSurfaceGravity = new List<double> { 0.378, 0.907, 0.166, 0.377, 2.36, 0.916, 0.889, 1.12, 0.071 };

        public const int weightMin = 1;
        public const int WeightMax = 500;

        [Range(weightMin, WeightMax, ErrorMessage = "Invalid weight - Only Available from 1 to 500 lbs")]
        [DisplayName("Enter Your Weight (KGs/LBs):")]
        public double weight { get; set; }
        
        [DisplayName("Select A Planet:")]
        public Planets planet { get; set; }

        // calculate weight mercury
        [DisplayName("Your Weight on that Planet:")]
        public double weightOnPlanet
        {
            get
            {
                double weightConverted = this.weight;

                if (planet.Equals(Planets.mercury))
                {
                    weightConverted = this.weight * planetsSurfaceGravity[(int)Planets.mercury];
                }
                else if (planet.Equals(Planets.venus))
                {
                    weightConverted = this.weight * planetsSurfaceGravity[(int)Planets.venus];
                }
                else if (planet.Equals(Planets.moon))
                {
                    weightConverted = this.weight * planetsSurfaceGravity[(int)Planets.moon];
                }
                else if (planet.Equals(Planets.mars))
                {
                    weightConverted = this.weight * planetsSurfaceGravity[(int)Planets.mars];
                }
                else if (planet.Equals(Planets.jupiter))
                {
                    weightConverted = this.weight * planetsSurfaceGravity[(int)Planets.jupiter];
                }
                else if (planet.Equals(Planets.saturn))
                {
                    weightConverted = this.weight * planetsSurfaceGravity[(int)Planets.saturn];
                }
                else if (planet.Equals(Planets.uranus))
                {
                    weightConverted = this.weight * planetsSurfaceGravity[(int)Planets.uranus];
                }
                else if (planet.Equals(Planets.neptune))
                {
                    weightConverted = this.weight * planetsSurfaceGravity[(int)Planets.neptune];
                }
                else if (planet.Equals(Planets.pluto))
                {
                    weightConverted = this.weight * planetsSurfaceGravity[(int)Planets.pluto];
                }
                return weightConverted;
            }
        }
    }
}
