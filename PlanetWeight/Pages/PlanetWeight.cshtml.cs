using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlanetWeights.Pages
{
    public class PlanetWeightsModel : PageModel
    {
        [BindProperty]      // bound on POST request
        public PlanetWeight planetWeight { get; set; }


        // POST, validate
        public IActionResult OnPost()
        {
            // extra validation (probably not that useful, but might be were additional validation can be added)
            if (planetWeight.weight <= 0.0)
            {
                ModelState.AddModelError("", "You need to enter your weight");
            }
            return Page();
        }
    }
}