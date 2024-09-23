using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public class CreateTrainLineDTO
    {
        public string TrainLineName { get; set; }
    }

    public class UpdateTrainLineDTO
    {
        public long Id { get; set; }
        public string TrainLineName { get; set; }
    }

    public class GetTrainLineDTO
    {
        public long Id { get; set; }
        public string TrainLineName { get; set; }
    }
}
