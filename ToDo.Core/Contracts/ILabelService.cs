using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Models;
using ToDo.Core.Models.ViewModels;

namespace ToDo.Core.Contracts
{
    interface ILabelService
    {
        public Task<List<ListedLabel>> GetProjectLabels(string Id);
        public Task<LabelVM> GetLabel(string Id); 
        public Task<IActionResult> UpdateLabel(string Id, LabelVM newLabel);
        public Task<IActionResult> AddLabel(LabelVM label);
        public Task<IActionResult> DeleteLabel(string labelId);
    }
}
