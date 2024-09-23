using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public class CreateCountryDTO
    {
        [Required(ErrorMessage = "CountryName is required")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "CountryCode is required")]
        public string CountryCode { get; set; }
    }

    public class UpdateCountryDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "CountryName is required")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "CountryCode is required")]
        public string CountryCode { get; set; }
    }

    public class GetCountryDTO
    {
        public long Id { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }
    }
}
