using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace OptechX.Portal.Server.Controllers.Generic
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryListController : ControllerBase
    {
        private List<string> countryList = new List<string>();

        [HttpGet]
        public IActionResult GetCountries()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.Name);
                if (!countryList.Contains(region.EnglishName))
                {
                    countryList.Add(region.EnglishName);
                }
            }

            countryList.Sort();
            countryList.Remove("World");

            countryList.Insert(0, "Select country..."); // Insert the text at index 0

            return Ok(countryList);
        }
    }
}
