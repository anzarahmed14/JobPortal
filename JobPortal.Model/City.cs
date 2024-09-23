using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("Cities")]
    public class City : BaseEntity
    {
        public string CityName { get; set; } = string.Empty;
        public string CityCode { get; set; } = string.Empty;


        // Foreign key to Country
        public long StateId { get; set; }
        // Navigation property for Country
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }
    }
}
