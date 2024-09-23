using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public class CreateCityDTO
    {
        [Required(ErrorMessage = "CityName is required")]
        public string CityName { get; set; }

        //[Required(ErrorMessage = "CityCode is required")]
        //public string CityCode { get; set; }

        [Required(ErrorMessage = "StateId is required")]
        public long StateId { get; set; }
    }

    public class UpdateCityDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "CityName is required")]
        public string CityName { get; set; }

       // [Required(ErrorMessage = "CityCode is required")]
       // public string CityCode { get; set; }

        [Required(ErrorMessage = "StateId is required")]
        public long StateId { get; set; }
    }

    public class GetCityDTO
    {
        public long Id { get; set; }
        public string CityName { get; set; }
       // public string CityCode { get; set; }
       // public long StateId { get; set; }
    }
    public record CityDTO (long Id, string CityName);
}
