using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Job
{
    public record GetJobCityDTO(long Id
        
        , long CityId
        , long JobId
        );

    public record GetJobCityViewModelDTO(long Id

      , long CityId
       ,string CityName
      , long JobId
      );

    public record CreateJobCityDTO(long Id
        , long CityId
        , long JobId
       );

    public record UpdateJobCityDTO(long Id
        , long CityId
        , long JobId
      );
}
