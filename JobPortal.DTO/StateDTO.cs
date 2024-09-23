using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public class CreateStateDTO
    {
        [Required(ErrorMessage = "StateName is required")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "StateCode is required")]
        public string StateCode { get; set; }

        [Required(ErrorMessage = "CountryId is required")]
        public long CountryId { get; set; }
    }

    public class UpdateStateDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "StateName is required")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "StateCode is required")]
        public string StateCode { get; set; }

        [Required(ErrorMessage = "CountryId is required")]
        public long CountryId { get; set; }
    }

    public class GetStateDTO
    {
        public long Id { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public long CountryId { get; set; }
    }
}
