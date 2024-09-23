using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public record GetAddressInfoDTO
    {
        public long Id { get; set; }
        public string Address { get; init; }
        public string PostalCode { get; init; }
        public long CityId { get; init; }
        public long StateId { get; init; }
        public long CountryId { get; init; }
        public long UserId { get; init; }
        public long TrainLineId { get; init; }


    }
    public record CreateAddressInfoDTO
    {
     
        public string Address { get; init; }
        public long CityId { get; init; }
        public long StateId { get; init; }
        public long CountryId { get; init; }
        public long UserId { get; init; }
        public string PostalCode { get; init; }
        public long TrainLineId { get; init; }

    }
    public record UpdateAddressInfoDTO
    {
        public long Id { get; set; }
        public string Address { get; init; }
        public long CityId { get; init; }
        public long StateId { get; init; }
        public long CountryId { get; init; }
        public long UserId { get; init; }

    }
    public record GetAddressInfoDetailDto
    {
        public long Id { get; set; }
        public string Address { get; init; }
        public string PostalCode { get; init; }
        public string CityName { get; init; }
        public string StateName { get; init; }
        public string CountryName { get; init; }
        public long UserId { get; init; }
        public string TrainLineName { get; init; }


    }
}
