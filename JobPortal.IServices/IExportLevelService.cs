﻿using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IExportLevelService
    {
        Task<IEnumerable<GetExportLevelsDTO>> GetExportLevelsAsync();
    }
}
