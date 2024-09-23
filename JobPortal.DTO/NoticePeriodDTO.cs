using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public class CreateNoticePeriodDTO
    {
        public string NoticePeriodName { get; set; }
    }

    public class UpdateNoticePeriodDTO
    {
        public long Id { get; set; }
        public string NoticePeriodName { get; set; }
    }

    public class GetNoticePeriodDTO
    {
        public long Id { get; set; }
        public string NoticePeriodName { get; set; }
    }
}
