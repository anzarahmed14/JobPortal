using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{

    public class CreateDesignationDTO
    {
        [Required(ErrorMessage = "DesignationName is required")]
        public string DesignationName { get; set; }

       
    }

    public class UpdateDesignationDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "DesignationName is required")]
        public string DesignationName { get; set; }

        }

    public class GetDesignationDTO
    {
        public long Id { get; set; }
        public string DesignationName { get; set; }
       
    }
}
