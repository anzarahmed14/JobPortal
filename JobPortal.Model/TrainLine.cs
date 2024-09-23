using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("TrainLines")]
    public class TrainLine : BaseEntity
    {

        public long Id { get; set; }
        public string TrainLineName { get; set; } = string.Empty;
      

    }
}
