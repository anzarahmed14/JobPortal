using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("ExportLevels")]
    [Index(nameof(ExportLevelName), IsUnique = true)]
    public class ExportLevel :BaseEntity
    {
        public string ExportLevelName { get; set; }
        public bool IsActive { get; set; } =false;
    }
}
