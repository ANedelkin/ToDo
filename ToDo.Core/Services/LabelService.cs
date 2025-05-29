using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Contracts;
using ToDo.Core.Models;
using ToDo.Core.Models.ViewModels;
using ToDo.Infrastructure.Data.Common;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Core.Services
{
    class LabelService : ILabelService
    {
        private readonly IRepository _repository;
        public LabelService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ListedLabel>> GetProjectLabels(string projectId)
        {
            return await _repository.AllAsNoTrackingAsync<Label>().Where(l => l.ProjectId == projectId).Select(l => new ListedLabel(l)).ToListAsync();
        }
        public async Task<LabelVM?> GetLabel(string id)
        {
            return new LabelVM(await _repository.GetByIdAsync<Label>(id));
        }
        public async System.Threading.Tasks.Task AddLabel(LabelVM label, string projectId)
        {
            await _repository.AddAsync<Label>(new Label(label.Title, label.Description, label.ColorHex, projectId));
        }
        public async System.Threading.Tasks.Task UpdateLabel(string id, LabelVM newLabel)
        {
            await _repository.UpdateAsync<Label>(id, new Label(newLabel.Title, newLabel.Description, newLabel.ColorHex, await GetLabelProjectId(id)));
        }
        public async System.Threading.Tasks.Task DeleteLabel(string id)
        {
            await _repository.DeleteByIdAsync<Label>(id);
        }
        
        private async Task<string> GetLabelProjectId(string id)
        {
            Label label = await _repository.GetByIdAsync<Label>(id);
            return label.ProjectId;
        }
    }
}
