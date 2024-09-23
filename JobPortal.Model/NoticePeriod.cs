using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("NoticePeriods")]
    public class NoticePeriod : BaseEntity
    {
        public string NoticePeriodName { get; set; } = string.Empty;
    }
}
