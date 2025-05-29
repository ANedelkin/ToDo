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
        public Task<List<ListedLabel>> GetProjectLabels(string projectId);
        public Task<LabelVM?> GetLabel(string id); 
        public Task AddLabel(LabelVM label, string projectId);
        public Task UpdateLabel(string id, LabelVM newLabel);
        public Task DeleteLabel(string labelId);
    }
}
